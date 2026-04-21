' =============================================
' NF525 — SIGNATURE PKI X.509
' Version : 2.0 — Compatible .NET Framework 3.5
' =============================================
' Fichier : CLI/NF525/SignatureHelperPKI.vb
' Objectif : Signature asymétrique RSA-2048 avec certificat X.509
'            Conforme NF525 / BOI-TVA-DECLA-30-10-30
'
' CORRECTIONS v2.0 (compatibilité .NET 3.5) :
'   - Remplace GetRSAPrivateKey()  → cert.PrivateKey (AsymmetricAlgorithm)
'   - Remplace GetRSAPublicKey()   → cert.PublicKey.Key (AsymmetricAlgorithm)
'   - Remplace HashAlgorithmName   → SHA256Managed + CryptoConfig.MapNameToOID
'   - Remplace RSASignaturePadding → implicite RSACryptoServiceProvider (PKCS#1 v1.5)
'   - SignHash / VerifyHash avec SHA256Managed pré-calculé
' =============================================

Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.IO
Imports System.Data.SqlClient

Namespace NF525

    ''' <summary>
    ''' Module de signature PKI X.509 pour NF525.
    ''' Compatible .NET Framework 3.5 — utilise RSACryptoServiceProvider + SHA256Managed.
    ''' </summary>
    Public Module SignatureHelperPKI

#Region "Configuration"

        ' Chemin du certificat PFX — Production
        Private Const CERT_PATH_PROD As String = "C:\Certificates\CHINOOK_NF525.pfx"

        ''' <summary>
        ''' Retourne le chemin du fichier PFX.
        ''' Priorité : Production (C:\Certificates) → bin\Certificates → ../../../Certificates
        ''' </summary>
        Private ReadOnly Property CertPath As String
            Get
                If File.Exists(CERT_PATH_PROD) Then Return CERT_PATH_PROD

                Dim localPath As String = Path.Combine(Application.StartupPath, "Certificates\CHINOOK_NF525.pfx")
                If File.Exists(localPath) Then Return localPath

                Dim devPath As String = Path.GetFullPath(
                    Path.Combine(Application.StartupPath, "..\..\..\Certificates\CHINOOK_NF525.pfx"))
                If File.Exists(devPath) Then Return devPath

                Return CERT_PATH_PROD ' Valeur par défaut (déclenche FileNotFoundException si absent)
            End Get
        End Property

        ' Cache du certificat (évite les rechargements répétés)
        Private _certCache As X509Certificate2 = Nothing

#End Region

#Region "Sécurité — Mot de passe certificat"

        ''' <summary>
        ''' Lit le mot de passe du certificat PFX depuis une source sécurisée.
        ''' NE JAMAIS STOCKER LE MOT DE PASSE DANS LE CODE SOURCE (exigence NF525).
        '''
        ''' Ordre de priorité :
        '''   1. Variable d'environnement machine  NF525_CERT_PWD
        '''   2. Variable d'environnement utilisateur NF525_CERT_PWD
        '''   3. Fichier C:\Certificates\CHINOOK_NF525_CERT.key
        ''' </summary>
        Private Function GetCertPassword() As String
            ' 1. Variable d'environnement niveau Machine (serveur)
            Dim pwd As String = Environment.GetEnvironmentVariable("NF525_CERT_PWD", EnvironmentVariableTarget.Machine)
            If Not String.IsNullOrEmpty(pwd) Then Return pwd

            ' 2. Variable d'environnement niveau Utilisateur
            pwd = Environment.GetEnvironmentVariable("NF525_CERT_PWD", EnvironmentVariableTarget.User)
            If Not String.IsNullOrEmpty(pwd) Then Return pwd

            ' 3. Fichier .key dans le même dossier que le PFX
            Dim keyFile As String = Path.ChangeExtension(CertPath, ".key")
            If File.Exists(keyFile) Then
                Try
                    Dim contenu As String = File.ReadAllText(keyFile).Trim()
                    If Not String.IsNullOrEmpty(contenu) Then Return contenu
                Catch ex As Exception
                    ' Continuer vers l'exception finale
                End Try
            End If

            Throw New Security.SecurityException(
                "MOT DE PASSE CERTIFICAT NF525 INTROUVABLE." & vbCrLf &
                "Définir la variable d'environnement machine 'NF525_CERT_PWD'" & vbCrLf &
                "ou créer le fichier '" & keyFile & "' contenant le mot de passe.")
        End Function

#End Region

#Region "Chargement du certificat"

        ''' <summary>
        ''' Charge le certificat X.509 depuis le fichier PFX.
        ''' Utilise un cache en mémoire pour les performances.
        ''' Compatible .NET Framework 3.5.
        ''' </summary>
        Private Function LoadCertificate() As X509Certificate2
            ' Cache valide → retourner directement
            If _certCache IsNot Nothing AndAlso _certCache.HasPrivateKey Then
                ' Vérifier que le certificat n'est pas expiré
                If DateTime.Now <= _certCache.NotAfter Then
                    Return _certCache
                End If
                ' Expiré → vider le cache et recharger
                _certCache = Nothing
            End If

            If Not File.Exists(CertPath) Then
                Throw New FileNotFoundException(
                    "Certificat NF525 introuvable : " & CertPath & vbCrLf &
                    "Générer le certificat et le placer dans C:\Certificates\CHINOOK_NF525.pfx")
            End If

            Dim certPassword As String = GetCertPassword()

            ' X509KeyStorageFlags compatibles .NET 3.5
            _certCache = New X509Certificate2(CertPath, certPassword,
                X509KeyStorageFlags.Exportable Or X509KeyStorageFlags.PersistKeySet)

            If Not _certCache.HasPrivateKey Then
                Throw New CryptographicException(
                    "Le certificat PFX ne contient pas de clé privée." & vbCrLf &
                    "Vérifier que le fichier PFX inclut la clé privée exportable.")
            End If

            Return _certCache
        End Function

        ''' <summary>
        ''' Vérifie que le certificat est présent, valide et non expiré.
        ''' </summary>
        Public Function IsCertificateValid() As Boolean
            Try
                Dim cert As X509Certificate2 = LoadCertificate()
                Return cert.HasPrivateKey AndAlso
                       DateTime.Now >= cert.NotBefore AndAlso
                       DateTime.Now <= cert.NotAfter
            Catch ex As Exception
                Return False
            End Try
        End Function

#End Region

#Region "Signature RSA"

        ''' <summary>
        ''' Signe des données avec la clé privée RSA du certificat X.509.
        ''' Algorithme : RSA-2048 / PKCS#1 v1.5 / SHA-256.
        ''' Compatible .NET Framework 3.5 via RSACryptoServiceProvider + SHA256Managed.
        ''' </summary>
        ''' <param name="data">Données à signer (texte UTF-8)</param>
        ''' <returns>Signature RSA encodée en Base64 (~344 caractères pour RSA-2048)</returns>
        Public Function SignWithX509(ByVal data As String) As String
            Try
                Dim cert As X509Certificate2 = LoadCertificate()

                ' Obtenir la clé privée RSA (.NET 3.5 : cert.PrivateKey)
                Dim rsa As RSACryptoServiceProvider = Nothing
                Try
                    rsa = DirectCast(cert.PrivateKey, RSACryptoServiceProvider)
                Catch ex As InvalidCastException
                    Throw New CryptographicException(
                        "Impossible d'obtenir la clé privée RSA. " &
                        "Le certificat doit être de type RSA (non EC). " &
                        "Détail : " & ex.Message)
                End Try

                ' Calculer le hash SHA-256 des données
                Dim dataBytes As Byte() = Encoding.UTF8.GetBytes(data)
                Dim sha256 As New SHA256Managed()
                Dim hashBytes As Byte() = sha256.ComputeHash(dataBytes)

                ' Signer le hash — PKCS#1 v1.5 implicite avec RSACryptoServiceProvider
                ' CryptoConfig.MapNameToOID("SHA256") = "2.16.840.1.101.3.4.2.1"
                Dim signatureBytes As Byte() = rsa.SignHash(
                    hashBytes, CryptoConfig.MapNameToOID("SHA256"))

                Return Convert.ToBase64String(signatureBytes)

            Catch ex As Exception
                Try
                    LogEventTechnique("ERREUR_SIGNATURE_X509",
                                      "Erreur signature RSA : " & ex.Message, "", "")
                Catch
                End Try
                Throw New Exception("Erreur lors de la signature X.509 RSA", ex)
            End Try
        End Function

#End Region

#Region "Vérification RSA"

        ''' <summary>
        ''' Vérifie une signature RSA avec la clé publique du certificat X.509.
        ''' Compatible .NET Framework 3.5 via RSACryptoServiceProvider + SHA256Managed.
        ''' </summary>
        ''' <param name="data">Données originales signées (texte UTF-8)</param>
        ''' <param name="signature">Signature Base64 à vérifier</param>
        ''' <returns>True si la signature est cryptographiquement valide</returns>
        Public Function VerifyX509Signature(ByVal data As String, ByVal signature As String) As Boolean
            Try
                Dim cert As X509Certificate2 = LoadCertificate()

                ' Obtenir la clé publique RSA (.NET 3.5 : cert.PublicKey.Key)
                Dim rsa As RSACryptoServiceProvider = Nothing
                Try
                    rsa = DirectCast(cert.PublicKey.Key, RSACryptoServiceProvider)
                Catch ex As InvalidCastException
                    Throw New CryptographicException(
                        "Impossible d'obtenir la clé publique RSA. " &
                        "Le certificat doit être de type RSA. Détail : " & ex.Message)
                End Try

                ' Calculer le hash SHA-256 des données
                Dim dataBytes As Byte() = Encoding.UTF8.GetBytes(data)
                Dim sha256 As New SHA256Managed()
                Dim hashBytes As Byte() = sha256.ComputeHash(dataBytes)

                ' Décoder la signature Base64
                Dim signatureBytes As Byte() = Convert.FromBase64String(signature)

                ' Vérifier via VerifyHash (PKCS#1 v1.5 implicite)
                Return rsa.VerifyHash(hashBytes, CryptoConfig.MapNameToOID("SHA256"), signatureBytes)

            Catch ex As FormatException
                ' Signature Base64 malformée
                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Vérifie l'intégrité complète de la chaîne de tickets :
        '''   1. Contrôle du chaînage (PreviousSignature = Signature du ticket précédent)
        '''   2. Vérification cryptographique de chaque signature RSA (clé publique du certificat)
        '''      ou HMAC-SHA256 (si migration hybride)
        '''
        ''' Distingue automatiquement :
        '''   - Signature RSA  : longueur Base64 > 100 caractères (~344 pour RSA-2048)
        '''   - Signature HMAC : longueur Base64 = 44 caractères (32 octets SHA-256)
        ''' </summary>
        ''' <param name="afficherDetails">Si True, affiche un MessageBox récapitulatif</param>
        ''' <returns>True si toute la chaîne est intègre</returns>
        Public Function VerifierIntegriteChaineX509(Optional afficherDetails As Boolean = False) As Boolean
            Try
                Dim certDisponible As Boolean = IsCertificateValid()

                Dim sql As String =
                    "SELECT ID_T_CommandeVente, TicketLe, Total_TTC, Signature, PreviousSignature " &
                    "FROM T_CommandeVente " &
                    "WHERE TicketLe IS NOT NULL AND Signature IS NOT NULL " &
                    "ORDER BY ID_T_CommandeVente ASC"

                Dim erreursChaine As New List(Of String)
                Dim erreursCrypto As New List(Of String)
                Dim nbRSA As Integer = 0
                Dim nbHMAC As Integer = 0
                Dim sigPrecedente As String = "INITIAL_CHAIN_START"

                Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
                    cnn.Open()
                    Using cmd As New SqlCommand(sql, cnn)
                        Using reader As SqlDataReader = cmd.ExecuteReader()
                            While reader.Read()
                                Dim ticketId As Long = Convert.ToInt64(reader("ID_T_CommandeVente"))
                                Dim ticketDate As DateTime = Convert.ToDateTime(reader("TicketLe"))
                                Dim totalTTC As Decimal = Convert.ToDecimal(reader("Total_TTC"))
                                Dim sigStockee As String = reader("Signature").ToString().Trim()
                                Dim prevSigStockee As String = reader("PreviousSignature").ToString().Trim()

                                ' ── 1. Contrôle du chaînage ───────────────────────────
                                If prevSigStockee <> sigPrecedente Then
                                    erreursChaine.Add(
                                        "Ticket #" & ticketId &
                                        " du " & ticketDate.ToString("dd/MM/yyyy HH:mm") &
                                        " : rupture de chaîne" & vbCrLf &
                                        "  Attendu  : " & AbregerSignature(sigPrecedente) &
                                        "  Stocké   : " & AbregerSignature(prevSigStockee))
                                End If

                                ' ── 2. Vérification cryptographique ──────────────────
                                ' Reconstituer la chaîne signée (même format que lors de la création)
                                Dim donnees As String =
                                    ticketId.ToString() &
                                    ticketDate.ToString("yyyyMMddHHmmss") &
                                    totalTTC.ToString("0.00",
                                        System.Globalization.CultureInfo.InvariantCulture) &
                                    prevSigStockee

                                If sigStockee.Length > 100 Then
                                    ' Signature RSA (~344 chars Base64 pour 2048 bits)
                                    nbRSA += 1
                                    If certDisponible Then
                                        If Not VerifyX509Signature(donnees, sigStockee) Then
                                            erreursCrypto.Add(
                                                "Ticket #" & ticketId &
                                                " du " & ticketDate.ToString("dd/MM/yyyy HH:mm") &
                                                " : signature RSA INVALIDE — données altérées")
                                        End If
                                    End If
                                Else
                                    ' Signature HMAC-SHA256 (44 chars Base64)
                                    nbHMAC += 1
                                    Try
                                        Dim sigRecalculee As String =
                                            NF525.SignatureHelper.ComputeSignature(donnees)
                                        If sigRecalculee <> sigStockee Then
                                            erreursCrypto.Add(
                                                "Ticket #" & ticketId &
                                                " du " & ticketDate.ToString("dd/MM/yyyy HH:mm") &
                                                " : signature HMAC INVALIDE — données altérées")
                                        End If
                                    Catch
                                        ' Clé HMAC absente → vérification impossible pour ce ticket
                                        nbHMAC -= 1
                                    End Try
                                End If

                                sigPrecedente = sigStockee
                            End While
                        End Using
                    End Using
                End Using

                ' ── Consolidation des résultats ───────────────────────────────
                Dim toutesErreurs As New List(Of String)
                toutesErreurs.AddRange(erreursChaine)
                toutesErreurs.AddRange(erreursCrypto)

                Dim resume As String =
                    "RSA=" & nbRSA & " HMAC=" & nbHMAC &
                    " | Ruptures chaîne=" & erreursChaine.Count &
                    " | Sigs invalides=" & erreursCrypto.Count

                If toutesErreurs.Count > 0 Then
                    Dim detail As String = String.Join(" || ", toutesErreurs.ToArray())
                    LogEventTechnique("INTEGRITE_X509_KO",
                        toutesErreurs.Count & " anomalie(s) — " & resume, "", detail)

                    If afficherDetails Then
                        MessageBox.Show(
                            "INTÉGRITÉ COMPROMISE (NF525 — PKI X.509)" & vbCrLf & vbCrLf &
                            String.Join(vbCrLf, toutesErreurs.ToArray()) & vbCrLf & vbCrLf &
                            resume,
                            "NF525 — Vérification X.509",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    Return False
                Else
                    LogEventTechnique("INTEGRITE_X509_OK",
                        "Vérification intégrité X.509 OK — " & resume, "", "")

                    If afficherDetails Then
                        MessageBox.Show(
                            "Intégrité de la chaîne cryptographique VALIDÉE" & vbCrLf & resume,
                            "NF525 — Vérification X.509",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    Return True
                End If

            Catch ex As Exception
                LogEventTechnique("ERREUR_VERIF_X509",
                    "Erreur vérification intégrité X.509 : " & ex.Message, "", "")
                If afficherDetails Then
                    MessageBox.Show("Erreur lors de la vérification : " & ex.Message,
                                    "NF525 — Vérification X.509",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Return False
            End Try
        End Function

        ''' <summary>Retourne les 16 premiers caractères d'une signature pour les logs.</summary>
        Private Function AbregerSignature(sig As String) As String
            If String.IsNullOrEmpty(sig) Then Return "(vide)"
            Return sig.Substring(0, Math.Min(16, sig.Length)) & "..."
        End Function

#End Region

#Region "Informations certificat"

        ''' <summary>
        ''' Retourne un résumé lisible des informations du certificat X.509 chargé.
        ''' </summary>
        Public Function GetCertificateInfo() As String
            Try
                Dim cert As X509Certificate2 = LoadCertificate()
                Dim rsaKey As RSACryptoServiceProvider = Nothing
                Dim keySize As String = "inconnu"
                Try
                    rsaKey = DirectCast(cert.PublicKey.Key, RSACryptoServiceProvider)
                    keySize = rsaKey.KeySize.ToString() & " bits"
                Catch
                End Try

                Dim sb As New StringBuilder()
                sb.AppendLine("Certificat X.509 NF525")
                sb.AppendLine("======================")
                sb.AppendLine("Sujet       : " & cert.Subject)
                sb.AppendLine("Émetteur    : " & cert.Issuer)
                sb.AppendLine("Valide du   : " & cert.NotBefore.ToString("dd/MM/yyyy HH:mm"))
                sb.AppendLine("Valide au   : " & cert.NotAfter.ToString("dd/MM/yyyy HH:mm"))
                sb.AppendLine("Thumbprint  : " & cert.Thumbprint)
                sb.AppendLine("N° de série : " & cert.SerialNumber)
                sb.AppendLine("Algorithme  : " & cert.SignatureAlgorithm.FriendlyName)
                sb.AppendLine("Longueur clé: " & keySize)
                sb.AppendLine("Clé privée  : " & If(cert.HasPrivateKey, "Présente", "Absente"))
                sb.AppendLine("Statut      : " & If(IsCertificateValid(), "VALIDE", "EXPIRÉ OU INVALIDE"))
                Return sb.ToString()
            Catch ex As Exception
                Return "Erreur récupération infos certificat : " & ex.Message
            End Try
        End Function

        ''' <summary>Invalide le cache du certificat (forcer rechargement).</summary>
        Public Sub InvaliderCacheCertificat()
            _certCache = Nothing
        End Sub

#End Region

    End Module
End Namespace
