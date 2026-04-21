Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Microsoft.PointOfService
Imports System.IO
Imports System.Globalization
Imports RestSharp

Module ModuleGeneral
    Public vAfficheurImprimanteOk As Boolean = True
    Public vCashDrawerOk As Boolean = True
    Public vPosPrinterOk As Boolean = True


    'Public gCnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
    Public gCnn As New SqlClient.SqlConnection

    Public gLogin As String = ""
    Public gProfilName As String = ""
    Public gProfil As Integer = 0
    Public gServer As String = ""
    Public gDatabase As String = ""
    'Public gLogin As String = "TestMag"
    Public gFTP_host As String = GetParam("FTP_Host")
    Public gFTP_UID As String = GetParam("FTP_UID")
    Public gFTP_PWD As String = GetParam("FTP_PWD")
    Public gChemin_Vignette As String = GetParam("Chemin_Vignette")
    Public gChemin_local_vignette As String = GetParam("Chemin_local_vignette")
    Public gChemin_Facture As String = GetParam("Chemin_Facture")

    Public gThumbnailWidth As Integer = GetParam("ThumbnailWidth")
    Public gThumbnailHeight As Integer = GetParam("ThumbnailHeight")
    Public gPhotoWidth As Integer = GetParam("PhotoWidth")
    Public gPhotoHeight As Integer = GetParam("PhotoHeight")
    Public gQualiteJPG As String = GetParam("QualiteJPG")
    Public gNomImprimanteEtiquette As String = GetParam("NomImprimanteEtiquette")
    Public gChemin_local_facture As String = GetParam("Chemin_local_facture")
    Public gChemin_local_piece_jointe As String = GetParam("Chemin_local_piece_jointe")
    Public gSignature_html As String = GetParam("Signature_html")
    Public gSmtp As String = GetParam("Smtp")
    Public gSmtpLogin As String = GetParam("SmtpLogin")
    Public gSmtpPassword As String = GetParam("SmtpPassword")
    Public gSmtpPort As String = GetParam("SmtpPort")

    Public gEmailFacture As String = GetParam("Email_facture")
    Public m_Display As LineDisplay = Nothing
    Public m_Drawer As CashDrawer = Nothing
    Public m_Printer As PosPrinter = Nothing
    Public gCouleurObligatoireFond As Color = Color.FromName(GetParam("CouleurObligatoireFond"))
    Public gCouleurWebFond As Color = Color.FromName(GetParam("CouleurWebFond"))
    Public gCouleurOptionnelFond As Color = Color.FromName(GetParam("CouleurOptionnelFond"))
    Public gCouleurObligatoireEcriture As Color = Color.FromName(GetParam("CouleurObligatoireEcriture"))
    Public gCouleurWebEcriture As Color = Color.FromName(GetParam("CouleurWebEcriture"))
    Public gCouleurOptionnelEcriture As Color = Color.FromName(GetParam("CouleurOptionnelEcriture"))
    Public gMontantRepriseCodeClient As String = GetParam("MontantRepriseCodeClient")

    'droits
    Public gadmin As Boolean = False
    Public gStatistiques As Boolean = False
    Public gVente_r As Boolean = False
    Public gVente_w As Boolean = False
    Public gAchat_r As Boolean = False
    Public gAchat_w As Boolean = False
    Public gArticle_r As Boolean = False
    Public gArticle_w As Boolean = False
    Public gArticle_stock As Boolean = False
    Public gArticle_OccazOnly As Boolean = False
    Public gArticle_OccazTestOnly As Boolean = False
    Public gArticle_Web As Boolean = False
    Public gArticle_Mag As Boolean = False
    Public gTransaction As Boolean = False
    Public gmenuActivationWeb As Boolean = False
    Public gPrixStock As Boolean = False
    Public gJournalCaisseUn As Boolean = False
    Public gJournalCaisseDeux As Boolean = False



    'gestion du numéro de caisse en fonction du PC
    Public gNomPC As String = My.Computer.Name.ToUpper
    Public gNumCaisse As Integer = GetNumCaisse(My.Computer.Name)

    'gestion de l'activation du module WebCaisse
    Public gWebCaisse As Integer = GetParam("WebCaisse")

    'gestion des paramètres de webapi
    Public gCliMinimalApiUrl As String = GetParam("CliMinimalApiUrl")
    Public gCliMinimalApiXApiKey As String = GetParam("CliMinimalApiXApiKey")




    Sub main()
        SplashScreen.Show()
        Do While SplashScreen.Visible
            Application.DoEvents()
        Loop
        FormPrincipale.Show()
    End Sub

    Public Function GetParam(ByVal paramname As String) As String
        'If gCnn.ConnectionString = "" Then
        gCnn.ConnectionString = ChangeConnexion()
        'End If
        Dim cnnstate As ConnectionState = gCnn.State
        Dim strsql As String = "Select paramvalue from t_param where paramname='" & Replace(paramname, "'", "''") & "'"

        If cnnstate = ConnectionState.Closed Then
            gCnn.Open()
        End If
        Dim command As New SqlClient.SqlCommand(strsql, gCnn)
        Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
        If reader.HasRows Then
            reader.Read()
            GetParam = reader("paramvalue").ToString
        Else
            GetParam = ""
        End If
        reader.Close()
        If cnnstate = ConnectionState.Closed Then
            gCnn.Close()
        End If

    End Function


    Public Function GetNumCaisse(ByVal PC As String) As String
        'If gCnn.ConnectionString = "" Then
        gCnn.ConnectionString = ChangeConnexion()
        'End If
        Dim dt As DataTable = ExecuteRequeteR("select * from t_pcnumcaisse where pc='" & PC & "'", gCnn.ConnectionString)
        If dt.Rows.Count = 0 Then
            'caisse du magasin 1 par defaut
            Return 1
        End If

        Return dt.Rows(0)("numcaisse")


    End Function

    Public Sub ValeurNulle(ByVal sender As Object, ByVal e As ConvertEventArgs)

        If Not IsNumeric(e.Value) Then
            If e.Value.ToString = "" Then
                e.Value = System.DBNull.Value
            End If

        End If

    End Sub
    Public Sub ValeurNulleMaskedTextboxDate(ByVal sender As Object, ByVal e As ConvertEventArgs)

        If Not IsNumeric(e.Value) Then
            If e.Value.ToString = "  /  /" Then
                e.Value = System.DBNull.Value
            End If

        End If

    End Sub
    Public Function ConvertToHTML(ByVal Box As RichTextBox) As String
        Dim strHTML As String
        Dim strColeur As String
        Dim blnGras As Boolean
        Dim blnItalic As Boolean
        Dim strPolice As String
        Dim shtTaille As Short
        Dim lngDepartOriginal As Long
        Dim lngTailleOriginal As Long
        Dim intCount As Integer
        ' Si le text est vide, on sort
        If Box.Text.Length = 0 Then Exit Function
        ' Conserver la selection originale, et selectionné le debut
        lngDepartOriginal = 0
        lngTailleOriginal = Box.TextLength
        Box.Select(0, 1)
        ' Entete HTML
        strHTML = "<HTML>"
        ' Récuperer les parametres initaux
        strColeur = Box.SelectionColor.ToKnownColor.ToString
        blnGras = Box.SelectionFont.Bold
        blnItalic = Box.SelectionFont.Italic
        strPolice = Box.SelectionFont.FontFamily.Name
        shtTaille = Box.SelectionFont.Size
        ' Inclure le premier parametre HTML "Style"
        strHTML += "<SPAN style=""font-family: " & strPolice &
          "; font-size: " & shtTaille & "pt; color: " _
                          & strColeur & """>"
        ' Inclure le TAg GRAS si besoin est
        If blnGras = True Then
            strHTML += "<B>"
        End If
        ' Inclure le TAg ITALIQUE si besoin est
        If blnItalic = True Then
            strHTML += "<I>"
        End If
        ' Finalement on attaque le premier caractère
        strHTML += Box.Text.Substring(0, 1)
        ' Boucle sur le reste du texte
        For intCount = 2 To Box.Text.Length
            ' Selection du caractere
            Box.Select(intCount - 1, 1)
            ' Verifier et implementer si necessaire un changement de style
            If Box.SelectionColor.ToKnownColor.ToString <> strColeur _
                 Or Box.SelectionFont.FontFamily.Name <> strPolice _
                 Or Box.SelectionFont.Size <> shtTaille Then
                strHTML += "</SPAN><SPAN style=""font-family: " _
                  & Box.SelectionFont.FontFamily.Name &
                  "; font-size: " & Box.SelectionFont.Size &
                  "pt; color: " &
                  Box.SelectionColor.ToKnownColor.ToString & """>"
            End If
            ' Verifier changement GRAS
            If Box.SelectionFont.Bold <> blnGras Then
                If Box.SelectionFont.Bold = False Then
                    strHTML += "</B>"
                Else
                    strHTML += "<B>"
                End If
            End If
            ' Verifier changement ITALIQUE
            If Box.SelectionFont.Italic <> blnItalic Then
                If Box.SelectionFont.Italic = False Then
                    strHTML += "</I>"
                Else
                    strHTML += "<I>"
                End If
            End If
            ' Ajouter le caractere
            Select Case Box.Text.Substring(intCount - 1, 1)
                Case ControlChars.Lf ' Si c'est un LineFeed, mettre la borne <BR>
                    strHTML += "<BR>"
                Case " "
                    strHTML += "&nbsp;"
                Case ControlChars.Tab
                    strHTML += "&nbsp;&nbsp;&nbsp;&nbsp;"
                Case Else
                    strHTML += System.Web.HttpUtility.HtmlEncode(Box.Text.Substring(intCount - 1, 1))
            End Select
            ' Mise a jour du style courant
            strColeur = Box.SelectionColor.ToKnownColor.ToString
            blnGras = Box.SelectionFont.Bold
            blnItalic = Box.SelectionFont.Italic
            strPolice = Box.SelectionFont.FontFamily.Name
            shtTaille = Box.SelectionFont.Size
        Next
        ' Fermer les Tag <B> <I> si necessaire
        If blnGras = True Then strHTML += "</B>"
        If blnItalic = True Then strHTML += "</I>"
        ' Fermer le style et la page HTML
        strHTML += "</SPAN></HTML>"
        ' Restorer la selection d'origine
        Box.Select(lngDepartOriginal, lngTailleOriginal)
        ' Retourner le code HTML
        Return strHTML
    End Function
    Public Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders() As ImageCodecInfo
        encoders = ImageCodecInfo.GetImageEncoders()

        j = 0
        While j < encoders.Length
            If encoders(j).MimeType = mimeType Then
                Return encoders(j)
            End If
            j += 1
        End While
        Return Nothing

    End Function 'GetEncoderInfo
    Public Function DescriptionCodeBarre(ByVal description As String) As String
        'If Len(description) >= 33 Then
        'DescriptionCodeBarre = Left(description, 30) & "..."
        'Else
        DescriptionCodeBarre = description
        'End If

    End Function
    Public Function BarCodeCodeBarre(ByVal barcode As String) As String
        Dim NbZeroAdd As Integer = 7 - Len(barcode)
        Dim i As Integer = 0

        For i = 0 To NbZeroAdd - 1
            barcode = "0" & barcode
        Next
        BarCodeCodeBarre = "*" & barcode & "*"



    End Function
    Public Function lineDisplayinit() As Boolean
        lineDisplayinit = True
        Dim strLogicalName As String
        Dim deviceInfo As DeviceInfo
        Dim posExplorer As PosExplorer

        strLogicalName = "LineDisplay"

        'Crate PosExplorer
        posExplorer = New PosExplorer

        Try

            deviceInfo = posExplorer.GetDevice(DeviceType.LineDisplay, strLogicalName)
            m_Display = posExplorer.CreateInstance(deviceInfo)

        Catch ex As Exception


            Return lineDisplayinit = False

        End Try

        Try
            'Open the device
            m_Display.Open()

            'Get the exclusive control right for the opened device.
            'Then the device is disable from other application.
            m_Display.Claim(1000)

            'If support the CapPowerReporting, enable the Power Reporting Requirements.
            If Not m_Display.CapPowerReporting = PowerReporting.None Then

                m_Display.PowerNotify = PowerNotification.Enabled

            End If

            'Enable the device.
            m_Display.DeviceEnabled = True
            m_Display.ClearText()
        Catch ex As PosControlException
            Return lineDisplayinit = False


        End Try

    End Function
    Public Function CashDrawerInit() As Boolean
        CashDrawerInit = True
        Dim strLogicalName As String
        Dim deviceInfo As DeviceInfo
        Dim posExplorer As PosExplorer

        strLogicalName = "CashDrawer"

        'Crate PosExplorer
        posExplorer = New PosExplorer

        Try

            deviceInfo = posExplorer.GetDevice(DeviceType.CashDrawer, strLogicalName)
            m_Drawer = posExplorer.CreateInstance(deviceInfo)

        Catch ex As Exception


            Return CashDrawerInit = False

        End Try
        Try

            'Open the device
            m_Drawer.Open()

            'Get the exclusive control right for the opened device.
            'Then the device is disable from other application.
            m_Drawer.Claim(1000)

            'Enable the device.
            m_Drawer.DeviceEnabled = True

            'm_Drawer.WaitForDrawerClose(1000, 44000, 500, 1000)
        Catch ex As PosControlException


            Return CashDrawerInit = False

        End Try


    End Function
    Public Function PosPrinterInit() As Boolean
        PosPrinterInit = True
        'Use a Logical Device Name which has been set on the SetupPOS.
        Dim strLogicalName As String
        Dim deviceInfo As DeviceInfo
        Dim posExplorer As PosExplorer
        Dim strCurDir As String
        Dim strFilePath As String

        'Current Directory Path
        strCurDir = Directory.GetCurrentDirectory()

        strFilePath = Application.StartupPath

        strFilePath += "\logo_chinooksurfshop.bmp"

        strLogicalName = "PosPrinter"

        'Crate PosExplorer
        posExplorer = New PosExplorer

        m_Printer = Nothing

        Try

            deviceInfo = posExplorer.GetDevice(DeviceType.PosPrinter, strLogicalName)
            'deviceInfo = posExplorer.GetDevice("POSPrinter", strLogicalName)
            'deviceInfo = posExplorer.GetDevices("POSPrinter")(1)
            m_Printer = posExplorer.CreateInstance(deviceInfo)

        Catch ex As Exception
            PosPrinterInit = False
            Exit Function
        End Try

        Try

            'Open the device
            m_Printer.Open()

            'Get the exclusive control right for the opened device.
            'Then the device is disable from other application.
            m_Printer.Claim(1000)

            'Enable the device.
            m_Printer.DeviceEnabled = True

            '<<<step3>>>--Start

            'Output by the high quality mode
            m_Printer.RecLetterQuality = True
            Dim iRetryCount As Integer

            If m_Printer.CapRecBitmap Then
                Dim bSetBitmapSuccess As Boolean
                For iRetryCount = 0 To 5
                    Try
                        '<<<step5>>>--Start
                        m_Printer.SetBitmap(1, PrinterStation.Receipt, strFilePath,
                        m_Printer.RecLineWidth / 2, PosPrinter.PrinterBitmapCenter)
                        '<<<step5>>>--End
                        bSetBitmapSuccess = True
                        Exit For
                    Catch pce As PosControlException
                        If pce.ErrorCode = ErrorCode.Failure And pce.ErrorCodeExtended = 0 And pce.Message = "It is not initialized." Then
                            System.Threading.Thread.Sleep(1000)
                        End If
                    End Try
                Next
                If Not bSetBitmapSuccess Then
                    ' MessageBox.Show("Impossible de charger le bitmap.", "" _
                    '        , MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    PosPrinterInit = False
                End If
            End If
            '<<<strep3>>>--End

            '<<<step5>>>--Start
            'Even if using any printers, 0.01mm unit makes it possible to print neatly.
            m_Printer.MapMode = MapMode.Metric
            '<<<step5>>>--End

        Catch ex As PosControlException

            PosPrinterInit = False

        End Try

        '<<<step1>>>--End


    End Function
    Public Sub InitCombo(ByVal pCombo As Object, ByVal pConnection As String, ByVal pRequete As String, ByVal pDisplayMember As String, Optional ByVal pFirstLigne As Object = Nothing, Optional ByVal pValueMember As String = "", Optional ByVal pAffValue As Boolean = True)
        '*************************************************************************************
        '*                                   INIT COMBO                                      *
        '*  Initialise une combo avec une requete                                            *
        '* ENTREE :                                                                          *
        '*  pCombo : Nom du control combox ou multicolonnCombobox                            *
        '*  pConnection : chaine connexion pour la requete                                   *
        '*  pRequete : requete SQL pour le remplissage                                       *
        '*  pDisplayMember : nom du champ à afficher (doit etre dans la requete)             *
        '*  OPTIONNEL                                                                        *
        '*  pfirstLigne : libelle de type "<Tous>" à insérer en premier ligne                *
        '*  pvalueMember : Nom du champ à affecter en valuemember de la combo                *
        '*  pAffValue : true affiche le champ pValueMember; False n'affiche pas              * 
        '*               (uniquement dans le cadre d'une combo multicolonne)                  *
        '*************************************************************************************
        'Variables
        Dim vValueMember As String
        Dim vtable As DataTable
        Dim vKey(0) As DataColumn

        'Initialisation

        vtable = ExecuteRequeteR(pRequete, pConnection)
        If pValueMember = "" Then
            'Si pValueMember n'est pas donné on prend le premier champ de la requete
            vValueMember = vtable.Columns(0).ColumnName
            vKey(0) = vtable.Columns(0)
        Else
            vValueMember = pValueMember
            vKey(0) = vtable.Columns(pValueMember)
        End If
        If pFirstLigne Is Nothing Then vtable.PrimaryKey() = vKey

        ' ajout une ligne en debut
        If Not pFirstLigne Is Nothing Then
            If TypeOf pFirstLigne Is String Then
                Dim vLigne As DataRow
                Dim vValeur As String

                For Each vValeur In pFirstLigne.split(";")
                    vLigne = vtable.NewRow
                    vLigne.Item(pDisplayMember) = vValeur
                    If vValeur = "" Then vLigne.Item(vValueMember) = DBNull.Value
                    vtable.Rows.InsertAt(vLigne, 0)
                Next
            End If
        End If

        pCombo.DataSource = vtable

        pCombo.DisplayMember = pDisplayMember
        pCombo.ValueMember = vValueMember

        'Masquage de la colonne Value Member
        If pAffValue = False Then
            pCombo.DropDownListColumns(vtable.Columns(vValueMember).Ordinal).Visible() = pAffValue
        End If

    End Sub
    Public Function ExecuteRequeteR(ByVal pRequeteStr As String, ByVal pConnection As String) As DataTable
        '***********************************************************************
        '*                          Execute une requete SQL                    *
        '* ENTREE :                                                            *
        '*    pRequete : Requete SQL                                           *
        '*    pConnection : Chaine de connection à la base de donnée           *
        '* SORTIE :                                                            *
        '*    Un datatable rempli par la requete                               * 
        '***********************************************************************
        Dim vCnn As New SqlClient.SqlConnection(pConnection)
        Dim vDataSet As New DataSet("DatasetTempo")

        Dim SqlDataAdapter As New Data.SqlClient.SqlDataAdapter(pRequeteStr, vCnn)
        SqlDataAdapter.Fill(vDataSet, "Recherche")
        ExecuteRequeteR = vDataSet.Tables("Recherche")
        vDataSet.Dispose()
        vCnn.Close()
    End Function
    Function ChangeConnexion() As String
        Dim stringbuilder As New SqlClient.SqlConnectionStringBuilder

        stringbuilder.ConnectionString = My.Settings.CLIConnectionString

        'changement de la connexion à la base de données si le nombre d'arguments=2 : serveur et base de données
        If My.Application.CommandLineArgs.Count = 2 Then
            stringbuilder.DataSource = My.Application.CommandLineArgs(0)
            stringbuilder.InitialCatalog = My.Application.CommandLineArgs(1)


        End If

        gServer = stringbuilder.DataSource
        gDatabase = stringbuilder.InitialCatalog
        stringbuilder.PersistSecurityInfo = True
        My.Settings("CLIConnectionString") = stringbuilder.ConnectionString
        Return My.Settings("CLIConnectionString")

    End Function

    'Fonctions pour interroger le webApi


End Module
