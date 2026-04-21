Imports System.Security.Cryptography
Imports System.Text
Imports System.Data.SqlClient
Imports System.IO

Namespace NF525
    ''' <summary>
    ''' Helper module for NF525 Certification (Inalterability).
    ''' Handles cryptographic chaining of transactions.
    ''' </summary>
    Public Module SignatureHelper

        ' Cache interne de la clé — chargée une seule fois depuis une source externe
        Private _secretKeyCache As String = Nothing

        ''' <summary>
        ''' Récupère la clé HMAC depuis une source sécurisée externe (jamais dans le code source).
        ''' Ordre de priorité :
        '''   1. Variable d'environnement NF525_HMAC_KEY (Production / CI)
        '''   2. Fichier C:\Certificates\CHINOOK_NF525_HMAC.key (Serveur local)
        '''   3. Fichier [DossierApp]\Certificates\CHINOOK_NF525_HMAC.key (Dev)
        ''' EXIGENCE NF525 : La clé ne doit JAMAIS être stockée dans le code source.
        ''' </summary>
        Private Function GetSecretKey() As String
            If _secretKeyCache IsNot Nothing Then Return _secretKeyCache

            ' 1. Variable d'environnement (niveau utilisateur)
            Dim envKey As String = Environment.GetEnvironmentVariable("NF525_HMAC_KEY", EnvironmentVariableTarget.User)
            If Not String.IsNullOrEmpty(envKey) Then
                _secretKeyCache = envKey.Trim()
                Return _secretKeyCache
            End If

            ' 2. Variable d'environnement (niveau machine)
            envKey = Environment.GetEnvironmentVariable("NF525_HMAC_KEY", EnvironmentVariableTarget.Machine)
            If Not String.IsNullOrEmpty(envKey) Then
                _secretKeyCache = envKey.Trim()
                Return _secretKeyCache
            End If

            ' 3. Fichiers .key protégés (ACL restreintes recommandées)
            Dim candidats As String() = {
                "C:\Certificates\CHINOOK_NF525_HMAC.key",
                Path.Combine(Application.StartupPath, Path.Combine("Certificates", "CHINOOK_NF525_HMAC.key")),
                Path.Combine(Application.StartupPath, Path.Combine("..", Path.Combine("..", Path.Combine("Certificates", "CHINOOK_NF525_HMAC.key"))))
            }

            For Each cheminCle As String In candidats
                If File.Exists(cheminCle) Then
                    Try
                        Dim contenu As String = File.ReadAllText(cheminCle).Trim()
                        If Not String.IsNullOrEmpty(contenu) AndAlso contenu.Length >= 32 Then
                            _secretKeyCache = contenu
                            Return _secretKeyCache
                        End If
                    Catch ex As Exception
                        Debug.WriteLine("NF525 - Erreur lecture fichier clé HMAC : " & ex.Message)
                    End Try
                End If
            Next

            Throw New Security.SecurityException(
                "CLÉ HMAC NF525 INTROUVABLE." & vbCrLf &
                "La conformité NF525 exige que la clé ne soit pas dans le code source." & vbCrLf &
                "Solution 1 : Définir la variable d'environnement 'NF525_HMAC_KEY'." & vbCrLf &
                "Solution 2 : Créer le fichier 'C:\Certificates\CHINOOK_NF525_HMAC.key' avec la clé (32 caractères min).")
        End Function

        ''' <summary>
        ''' Réinitialise le cache de la clé (utile lors d'un changement de clé ou des tests).
        ''' </summary>
        Public Sub InvaliderCacheClé()
            _secretKeyCache = Nothing
        End Sub

        ''' <summary>
        ''' Computes the HMAC-SHA256 signature for a given input string.
        ''' </summary>
        ''' <param name="data">The string representation of the data to sign.</param>
        ''' <returns>Base64 string of the hash.</returns>
        Public Function ComputeSignature(ByVal data As String) As String
            Dim keyBytes As Byte() = Encoding.UTF8.GetBytes(GetSecretKey())
            Dim dataBytes As Byte() = Encoding.UTF8.GetBytes(data)

            Using hmac As New HMACSHA256(keyBytes)
                Dim hashBytes As Byte() = hmac.ComputeHash(dataBytes)
                Return Convert.ToBase64String(hashBytes)
            End Using
        End Function

        ''' <summary>
        ''' Retrieves the Signature of the IMMEDIATELY PRECEDING validated ticket.
        ''' Crucial for chaining.
        ''' </summary>
        ''' <param name="currentTicketId">The ID of the ticket currently being signed (to ensure we look for ID < CurrentID).</param>
        ''' <returns></returns>
        Public Function GetPreviousTicketSignature(ByVal currentTicketId As Long) As String
            Dim prevSign As String = ""
            ' SQL to get the last signature.
            ' Note: We assume T_CommandeVente has a 'Signature' column.
            ' We order by ID DESC where ID < current.
            Dim sql As String = "SELECT TOP 1 Signature FROM T_CommandeVente WHERE ID_T_CommandeVente < @Id AND Signature IS NOT NULL ORDER BY ID_T_CommandeVente DESC"

            Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlCommand(sql, cnn)
                    cmd.Parameters.AddWithValue("@Id", currentTicketId)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        prevSign = result.ToString()
                    Else
                        ' Chain Initialization (First ticket ever)
                        prevSign = "INITIAL_CHAIN_START"
                    End If
                End Using
            End Using
            Return prevSign
        End Function

        ''' <summary>
        ''' Formats the Ticket Data for signing.
        ''' Format: [ID][Date(yyyyMMddHHmmss)][TotalTTC][PreviousSignature]
        ''' </summary>
        Public Function GetStringForTicket(ByVal row As CLIDataSet.T_CommandeVenteRow, ByVal previousSignature As String) As String
            Dim sb As New StringBuilder()
            sb.Append(row.ID_T_CommandeVente.ToString())
            ' Use fixed format for dates to avoid culture issues
            If Not row.IsTicketLeNull Then
                sb.Append(row.TicketLe.ToString("yyyyMMddHHmmss"))
            Else
                sb.Append(row.CreeLe.ToString("yyyyMMddHHmmss"))
            End If
            
            ' Format Decimals ensuring consistency (e.g. 2 decimal places, dot separator)
            sb.Append(FormatDecimal(row.Total_TTC))
            
            sb.Append(previousSignature)

            Return sb.ToString()
        End Function

        ''' <summary>
        ''' Formats the Line Data for signing.
        ''' Format: [LineID][ArticleID][Qte][TotalTTC][TicketSignature]
        ''' Note: Lines are chained to the Ticket's signature or previous line.
        ''' Strategy: Link to Ticket ID for simplicity + previous line signature if deep chaining required.
        ''' For this implementation: Link to Ticket Header Data.
        ''' </summary>
        Public Function GetStringForLine(ByVal row As CLIDataSet.T_CommandeVente_LigneRow, ByVal ticketId As Long) As String
            Dim sb As New StringBuilder()
            sb.Append(row.ID_T_CommandeVente_Ligne.ToString())
            sb.Append(row.ID_t_article_version.ToString())
            sb.Append(FormatDecimal(row.Qte))
            sb.Append(FormatDecimal(row.prix_total_TTC))
            sb.Append(ticketId.ToString()) ' Link to parent
            Return sb.ToString()
        End Function

        ''' <summary>
        ''' Helper to ensure decimal consistency (force "." separator, 2 decimals).
        ''' </summary>
        Private Function FormatDecimal(ByVal val As Decimal) As String
            Return val.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
        End Function

        ''' <summary>
        ''' Main entry point to sign a Ticket and its components BEFORE saving to DB.
        ''' </summary>
        Public Sub SignTransaction(ByRef ticketRow As CLIDataSet.T_CommandeVenteRow, ByRef lines As CLIDataSet.T_CommandeVente_LigneDataTable)
            ' 1. Get Previous Chain Link
            Dim previousSign As String = GetPreviousTicketSignature(ticketRow.ID_T_CommandeVente)

            ' 2. Prepare Data String
            ' Note: requires the 'Signature' and 'PreviousSignature' columns to be added to the Dataset/DB first.
            ' Assuming they exist in the Row object (you must add them to the XSD first).
            
            ' ✅ NF525 : Enregistrer la signature précédente pour le chaînage
            ticketRow.PreviousSignature = previousSign
            Dim rawData As String = GetStringForTicket(ticketRow, previousSign)
            
            ' 3. Compute
            Dim currentSign As String = ComputeSignature(rawData)
            
            ' 4. Apply
            ' ✅ NF525 : Enregistrer la signature du ticket
            ticketRow.Signature = currentSign

            ' 5. (Optional but recommended) Sign Lines
            ' ✅ NF525 : Signer chaque ligne de vente
            For Each line As CLIDataSet.T_CommandeVente_LigneRow In lines.Rows
                Dim lineData As String = GetStringForLine(line, ticketRow.ID_T_CommandeVente)
                Dim lineSign As String = ComputeSignature(lineData)
                ' ✅ NF525 : Enregistrer la signature de la ligne
                line.Signature = lineSign
                line.PreviousSignature = ticketRow.Signature ' Chaînage ligne → ticket
            Next
        End Sub

    End Module
End Namespace
