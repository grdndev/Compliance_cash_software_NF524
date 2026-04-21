Imports System.Data.SqlClient
Imports System.IO
Imports System.Text

''' <summary>
''' Module d'export DPD pour CargoNET Station.NET — Format V110 (version 5.7c)
'''
''' Génère un fichier d'interface texte à longueur fixe (3128 caractères + CR/LF par colis)
''' déposé dans le répertoire surveillé par Station.NET (mode semi-automatique).
'''
''' Station.NET détecte le fichier sous 0,2 secondes, charge les données,
''' et le vendeur complète le poids + sélectionne le compte DPD manuellement.
'''
''' Comptes DPD Chinook Leucate :
'''   - Classic  (Pro)       : 066-7485
'''   - Predict  (Particuliers) : 066-7486
'''   - Relais   (Sur choix) : 066-7487
'''
''' Documentation : Station.NET Dessin d'enregistrement Type V110 — cargoNET 12/2024
''' </summary>
Public Module ModuleDPD

#Region "Constantes"

    ''' <summary>Longueur d'un enregistrement data (hors CR/LF)</summary>
    Private Const RECORD_LENGTH As Integer = 3126

    ''' <summary>En-tête obligatoire du fichier V110</summary>
    Private Const HEADER_LINE As String = "$VERSION=110"

    ''' <summary>
    ''' Dossier par défaut surveillé par Station.NET.
    ''' Configurable via My.Settings.DPDStationNetFolder.
    ''' </summary>
    Private Const DEFAULT_DPD_FOLDER As String = "C:\DPD\Import\"

#End Region

#Region "Export principal"

    ''' <summary>
    ''' Génère et dépose le fichier V110 pour une commande.
    ''' Appelé depuis FormCaisse.Expedier() lorsque le transporteur sélectionné est DPD.
    ''' </summary>
    ''' <param name="idCommandeVente">ID de la commande dans T_CommandeVente</param>
    ''' <returns>Chemin complet du fichier créé</returns>
    Public Function ExporterDPD(idCommandeVente As Integer) As String
        Try
            ' ── 1. Lire les données de la commande ────────────────────────────
            Dim data As CommandeDPD = LireCommandeDPD(idCommandeVente)
            If data Is Nothing Then
                Throw New Exception("Commande #" & idCommandeVente & " introuvable pour export DPD.")
            End If

            ' ── 2. Construire l'enregistrement V110 ───────────────────────────
            Dim ligneData As String = BuildV110Record(data)

            ' ── 3. Construire le contenu du fichier ───────────────────────────
            Dim sb As New StringBuilder()
            sb.AppendLine(HEADER_LINE)           ' Ligne d'en-tête obligatoire
            sb.Append(ligneData)                 ' Enregistrement (1 colis)
            sb.Append(vbCrLf)                    ' Fin d'enregistrement obligatoire

            ' ── 4. Écrire le fichier dans le dossier Station.NET ──────────────
            Dim dossier As String = GetDPDFolder()
            If Not Directory.Exists(dossier) Then Directory.CreateDirectory(dossier)

            ' Nommer le fichier : CLI_<idCde>_<timestamp>.dat
            ' Station.NET surveille tous fichiers sauf .bak/.tmp
            Dim nomFichier As String = "CLI_" & idCommandeVente.ToString("D8") & "_" &
                                       Now.ToString("yyyyMMddHHmmss") & ".dat"
            Dim cheminFichier As String = Path.Combine(dossier, nomFichier)

            ' Créer d'abord sous nom temporaire, renommer ensuite
            ' (bonne pratique Station.NET : évite lecture partielle)
            Dim cheminTemp As String = Path.Combine(dossier, nomFichier & ".tmp")
            File.WriteAllText(cheminTemp, sb.ToString(), Encoding.GetEncoding("iso-8859-1"))
            File.Move(cheminTemp, cheminFichier)

            Return cheminFichier

        Catch ex As Exception
            Throw New Exception("Erreur export DPD : " & ex.Message, ex)
        End Try
    End Function

#End Region

#Region "Lecture données commande"

    ''' <summary>Structure interne pour les données d'une commande DPD.</summary>
    Private Class CommandeDPD
        Public IdCommande As Integer
        Public Prenom As String = ""
        Public Nom As String = ""
        Public Societe As String = ""
        Public AdresseL1 As String = ""
        Public AdresseL2 As String = ""
        Public AdresseL3 As String = ""
        Public CodePostal As String = ""
        Public Ville As String = ""
        Public CodePays As String = "FR"
        Public Tel As String = ""
        Public Mobile As String = ""
        Public Email As String = ""
    End Class

    ''' <summary>Lit les données d'une commande depuis la base pour l'export DPD.</summary>
    Private Function LireCommandeDPD(idCommandeVente As Integer) As CommandeDPD
        Dim sql As String =
            "SELECT cv.ID_T_CommandeVente, " &
            "       cv.Prénom, cv.Nom, cv.Société, " &
            "       cv.AdresseL1, cv.AdresseL2, cv.AdresseL3, " &
            "       cv.CodePostal, cv.Ville, " &
            "       cv.Tel, cv.Mobile, cv.Email, " &
            "       ISNULL(p.code_pays, 'FR') AS CodePays " &
            "FROM T_CommandeVente cv " &
            "LEFT JOIN T_Pays p ON p.libelle = cv.Pays " &
            "WHERE cv.ID_T_CommandeVente = @Id"

        Using cnn As New SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            Using cmd As New SqlCommand(sql, cnn)
                cmd.Parameters.AddWithValue("@Id", idCommandeVente)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If Not reader.Read() Then Return Nothing
                    Dim d As New CommandeDPD()
                    d.IdCommande = idCommandeVente
                    d.Prenom = NullStr(reader, "Prénom")
                    d.Nom = NullStr(reader, "Nom")
                    d.Societe = NullStr(reader, "Société")
                    d.AdresseL1 = NullStr(reader, "AdresseL1")
                    d.AdresseL2 = NullStr(reader, "AdresseL2")
                    d.AdresseL3 = NullStr(reader, "AdresseL3")
                    d.CodePostal = NullStr(reader, "CodePostal")
                    d.Ville = NullStr(reader, "Ville")
                    d.CodePays = NullStr(reader, "CodePays")
                    If String.IsNullOrEmpty(d.CodePays) Then d.CodePays = "FR"
                    d.Tel = NullStr(reader, "Tel")
                    d.Mobile = NullStr(reader, "Mobile")
                    d.Email = NullStr(reader, "Email")
                    Return d
                End Using
            End Using
        End Using
    End Function

    Private Function NullStr(reader As SqlDataReader, colName As String) As String
        Try
            If IsDBNull(reader(colName)) Then Return ""
            Return reader(colName).ToString().Trim()
        Catch
            Return ""
        End Try
    End Function

#End Region

#Region "Construction enregistrement V110"

    ''' <summary>
    ''' Construit l'enregistrement data V110 (3126 chars).
    ''' Format : longueur fixe ASCII, AN justifié à gauche (espaces),
    '''          N justifié à droite (zéros).
    ''' </summary>
    Private Function BuildV110Record(data As CommandeDPD) As String
        ' Tableau de 3126 espaces (positions 1-3126, indices 0-3125)
        Dim rec(RECORD_LENGTH - 1) As Char
        For i As Integer = 0 To RECORD_LENGTH - 1
            rec(i) = " "c
        Next

        ' ── Référence client N°1 (pos 1-35, AN 35) ───────────────────────────
        Dim ref1 As String = "CLI" & data.IdCommande.ToString("D8")
        PlaceAN(rec, 1, 35, ref1)

        ' ── Nom destinataire (pos 61-95, AN 35) ──────────────────────────────
        ' Si société : société en gras, sinon Nom + Prénom
        Dim nomPrincipal As String
        Dim complement1 As String
        If Not String.IsNullOrEmpty(data.Societe) Then
            nomPrincipal = data.Societe
            complement1 = Trim(data.Nom & " " & data.Prenom)
        Else
            nomPrincipal = Trim(data.Nom & " " & data.Prenom)
            complement1 = ""
        End If
        PlaceAN(rec, 61, 35, nomPrincipal)

        ' ── Complément d'adresse 1 / prénom (pos 96-130, AN 35) ──────────────
        PlaceAN(rec, 96, 35, complement1)

        ' ── Complément d'adresse 2 (pos 131-165, AN 35) ──────────────────────
        PlaceAN(rec, 131, 35, data.AdresseL2)

        ' ── Complément d'adresse 3 (pos 166-200, AN 35) ──────────────────────
        PlaceAN(rec, 166, 35, data.AdresseL3)

        ' ── Code postal (pos 271-280, AN 10) ─────────────────────────────────
        PlaceAN(rec, 271, 10, data.CodePostal)

        ' ── Ville (pos 281-315, AN 35) ────────────────────────────────────────
        PlaceAN(rec, 281, 35, data.Ville)

        ' ── Rue (pos 326-360, AN 35) — AdresseL1 ─────────────────────────────
        PlaceAN(rec, 326, 35, data.AdresseL1)

        ' ── Code pays (pos 371-373, AN 3) ────────────────────────────────────
        ' ISO Alpha-2 (2 chars) + espace
        PlaceAN(rec, 371, 3, data.CodePays)

        ' ── Téléphone (pos 374-393, AN 20) ───────────────────────────────────
        ' Priorité mobile (utile pour Predict SMS), sinon fixe
        Dim tel As String = If(Not String.IsNullOrEmpty(data.Mobile), data.Mobile, data.Tel)
        PlaceAN(rec, 374, 20, tel)

        ' ── Date d'expédition (pos 902-911, AN 10) ───────────────────────────
        PlaceAN(rec, 902, 10, Now.ToString("dd/MM/yyyy"))

        ' ── N° de compte (pos 912-919, N 8) ─────────────────────────────────
        ' Laissé vide : le vendeur sélectionne Classic/Predict/Relais manuellement
        ' dans Station.NET selon le type de client
        ' (Classic: 066-7485  |  Predict: 066-7486  |  Relais: 066-7487)

        ' ── Référence client N°2 (pos 955-989, AN 35) ────────────────────────
        ' Numéro de commande pour retrouver la commande dans CLI
        PlaceAN(rec, 955, 35, "Cde#" & data.IdCommande.ToString())

        ' ── Numéro de consolidation (pos 1072-1106, AN 35) ───────────────────
        ' Même que ref N°1 pour colis unique (garantit un numéro unique sur 1 an)
        PlaceAN(rec, 1072, 35, ref1)

        ' ── E-mail destinataire (pos 1232-1311, AN 80) ───────────────────────
        PlaceAN(rec, 1232, 80, data.Email)

        ' ── GSM destinataire (pos 1312-1346, AN 35) ──────────────────────────
        PlaceAN(rec, 1312, 35, data.Mobile)

        Return New String(rec)
    End Function

    ''' <summary>
    ''' Place un champ alphanumérique (AN) dans l'enregistrement.
    ''' Justifié à gauche, tronqué si trop long, complété par des espaces.
    ''' Supprime les caractères de contrôle (CR, LF, TAB).
    ''' </summary>
    ''' <param name="rec">Tableau de caractères (0-based)</param>
    ''' <param name="pos">Position 1-based dans la spec</param>
    ''' <param name="longueur">Longueur du champ</param>
    ''' <param name="valeur">Valeur à placer</param>
    Private Sub PlaceAN(rec() As Char, pos As Integer, longueur As Integer, valeur As String)
        If String.IsNullOrEmpty(valeur) Then Return
        ' Nettoyage : supprimer les caractères non imprimables
        Dim v As String = valeur.Replace(vbCrLf, " ").Replace(vbCr, " ").Replace(vbLf, " ").Replace(vbTab, " ")
        ' Conversion accents → ASCII (compatibilité iso-8859-1)
        ' (les accents sont valides en iso-8859-1, pas besoin de translittérer)

        Dim idx As Integer = pos - 1  ' Passer de 1-based à 0-based
        For i As Integer = 0 To Math.Min(longueur, v.Length) - 1
            If idx + i >= rec.Length Then Exit For
            rec(idx + i) = v.Chars(i)
        Next
    End Sub

#End Region

#Region "Configuration"

    ''' <summary>
    ''' Retourne le dossier de dépôt Station.NET configuré.
    ''' Priorité : My.Settings.DPDStationNetFolder → dossier par défaut.
    ''' </summary>
    Private Function GetDPDFolder() As String
        Try
            Dim folder As String = My.Settings.DPDStationNetFolder
            If Not String.IsNullOrEmpty(folder) Then Return folder
        Catch
            ' Setting non présent dans cette version → valeur par défaut
        End Try
        Return DEFAULT_DPD_FOLDER
    End Function

#End Region

End Module
