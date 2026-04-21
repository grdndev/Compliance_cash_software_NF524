Imports System.Drawing.Printing
Imports Microsoft.Reporting.WinForms


Public Module ModPrinter
    Private gDataGridViewPrinter As New DataGridViewPrinter.DataGridViewPrinter
    '--- API de recup info imprimante (marges , taille etc....)---------------
    Private Declare Function GetDeviceCaps Lib "gdi32" (ByVal hdc As Integer, ByVal nIndex As Integer) As Integer

    ' Constantes
    Private Const HORZRES As Short = 8
    Private Const VERTRES As Short = 10
    Private Const LOGPIXELSX As Short = 88
    Private Const LOGPIXELSY As Short = 90
    Private Const PHYSICALWIDTH As Short = 110
    Private Const PHYSICALHEIGHT As Short = 111
    Private Const PHYSICALOFFSETX As Short = 112
    Private Const PHYSICALOFFSETY As Short = 113


    Public Sub LstImp(ByVal pCombo As ComboBox, Optional ByVal pDefaut As Boolean = False)
        '***************************************************************************
        '*   Initialise une combo avec la liste des imprimantes installée          *
        '* ENTREE :                                                                *
        '*    pCombo : combo à initialiser                                         *
        '*    pdefaut : true l'imprimante par default est selectionnée             *
        '***************************************************************************
        Dim vImp As String
        Dim vImpDefaut As String
        Dim vPrtDoc As New PrintDocument

        For Each vImp In PrinterSettings.InstalledPrinters
            pCombo.Items.Add(vImp)
        Next vImp

        If pDefaut Then
            ' Affiche l'imprimante par défaut dans la combobox
            vImpDefaut = vPrtDoc.PrinterSettings.PrinterName
            vPrtDoc.Dispose()
            pCombo.SelectedIndex = pCombo.FindStringExact(vImpDefaut)
        End If
    End Sub


    '****************************************************************************
    '*                   IMPRESSION DINAMYQUE D'UN DATAGRIDVIEW                 *
    '* ENTREE :                                                                 *
    '*      pTable: datagridview à imprimer                                     *
    '*      pTitre: titre de l'etat                                             *
    '*      porientation : True paysage, false portrait                         *
    '****************************************************************************
    Public Sub TableImprime(ByVal pTable As DataGridView, Optional ByVal pTitre As String = "", Optional ByVal pOrientation As Boolean = False)
        ''Variables
        Dim vPrintDocument As New PrintDocument


        If gDataGridViewPrinter.SetupThePrinting(pTable, pTitre, pOrientation) Then
            Dim vPrintPreviewdialog As New PrintPreviewDialog()
            AddHandler gDataGridViewPrinter.gPrintDocument.PrintPage, AddressOf PrintDocument_PrintPage

            vPrintPreviewdialog.Document = gDataGridViewPrinter.gPrintDocument

            vPrintPreviewdialog.ShowDialog()

        End If
    End Sub

    '***************************************************************************
    '*                EVENEMENT LORS DES L'IMPRESSION DU DATAGRID              *
    '***************************************************************************
    Private Sub PrintDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim vMore As Boolean

        vMore = gDataGridViewPrinter.DrawDataGridView(e.Graphics)
        If vMore = True Then
            e.HasMorePages = True
        End If
    End Sub

    Public Sub iApercu(ByRef pReportViewer As ReportViewer, Optional ByVal pModeImp As Byte = 0, Optional ByVal pficDest As String = "")
        '***************************************************************************
        '*              Modifie la destination d'un report viewer                  *
        '*ENTREE :                                                                 *
        '*   pReportViewer : Nom du reportviewer à traiter                         *
        '*   pModeImp   : 0 Aperçu, 1 Impression direct, 2 Création d'un pdf       *
        '*   pFicDest   : Nom du fichier de destination pour le mode 2(PDF)        *
        '***************************************************************************

        Select Case pModeImp
            Case 0 'Aperçu
                Dim vFenApercu As New Form

                'Creation de la fenetre
                vFenApercu.Text = "Aperçu"
                vFenApercu.WindowState = System.Windows.Forms.FormWindowState.Maximized

                'Creation du reportviewer
                pReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
                pReportViewer.Location = New System.Drawing.Point(0, 0)
                pReportViewer.Name = "ReportViewer1"
                pReportViewer.Size = New System.Drawing.Size(739, 309)
                pReportViewer.TabIndex = 0
                pReportViewer.SetDisplayMode(DisplayMode.PrintLayout)

                vFenApercu.Controls.Add(pReportViewer)

                vFenApercu.ShowDialog()

            Case 1 'Impression direct

            Case 2 'PDF
                'Variable pour l'impression PDF
                Dim vWarnings As Warning() = Nothing
                Dim vStreamids As String() = Nothing
                Dim vMimeType As String = Nothing
                Dim vEncoding As String = Nothing
                Dim vExtension As String = Nothing
                Dim vBytes As Byte()

                pReportViewer.SetDisplayMode(DisplayMode.PrintLayout)
                pReportViewer.RefreshReport()

                '************** GENERATION DU PDF ***************
                vBytes = pReportViewer.LocalReport.Render("PDF", Nothing, vMimeType, _
                    vEncoding, vExtension, vStreamids, vWarnings)

                Dim vficDest As String
                vficDest = pficDest

                If vficDest = "" Then
                    Dim vFiledialog As New SaveFileDialog

                    '*** Demande un fichier ***
                    'recupération d'un fichier
                    vFiledialog.Title = "Selectionnez un fichier"
                    vFiledialog.Filter = "PDF (*.pdf)|*.pdf"
                    vFiledialog.FilterIndex = 1

                    If vFiledialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        vficDest = vFiledialog.FileName
                    End If
                End If

                Dim fs As New FileStream(vficDest, FileMode.Create)
                fs.Write(vBytes, 0, vBytes.Length)
                fs.Close()

        End Select
    End Sub

    Public Sub AddRupture(ByVal pDocXML As Xml.XmlDocument, ByVal pRupture As String, Optional ByVal pCouleur As String = "NavajoWhite", Optional ByVal pNumTable As Integer = 0)
        '***********************************************************************************
        '**                                     ADDRUPTURE                                **
        '**                 Entrées :                                                     **
        '**                     - pDocXML : Document XML à modifier                       **
        '**                     - pRupture : Nom du Champs de la rupture                  **
        '**                     - pCouleur : Couleur de la rupture                        **
        '**                     - pNumTable : Numéro de la table sur laquelle doit        **
        '**                     s'effectuer la rupture (0 étant la première table)        **
        '***********************************************************************************

        ' Variables
        Dim vTable As Xml.XmlElement
        Dim vTableGroups As Xml.XmlElement
        Dim vTableGroup As Xml.XmlElement
        Dim vGrouping As Xml.XmlElement
        Dim vRuptureName As String
        Dim vGrAttName As Xml.XmlAttribute
        Dim vGroupExpressions As Xml.XmlElement
        Dim vGroupExpression As Xml.XmlElement
        Dim vHeader As Xml.XmlElement
        Dim vTableRows As Xml.XmlElement
        Dim vTableRow As Xml.XmlElement
        Dim vTableCells As Xml.XmlElement
        Dim vTableCell As Xml.XmlElement
        Dim vColSpan As Xml.XmlElement
        Dim vReportItems As Xml.XmlElement
        Dim vTextBox As Xml.XmlElement
        Dim vTextBoxAttName As Xml.XmlAttribute
        Dim vStyle As Xml.XmlElement
        Dim vBackgroundColor As Xml.XmlElement
        Dim vPaddingLeft As Xml.XmlElement
        Dim vPaddingRight As Xml.XmlElement
        Dim vPaddingTop As Xml.XmlElement
        Dim vPaddingBottom As Xml.XmlElement
        Dim vPaddingValue As String = "2pt"
        Dim vPaddingLeftValue As String = "10pt"
        Dim vFontSize As Xml.XmlElement
        Dim vFontSizeValue As String = "12pt"
        Dim vFontWeight As Xml.XmlElement
        Dim vFontWeightValue As String = "700"
        Dim vTextAlign As Xml.XmlElement
        Dim vTextAlignValue As String = "Left"
        Dim vVerticalAlign As Xml.XmlElement
        Dim vVerticalAlignValue As String = "Middle"
        Dim vZIndex As Xml.XmlElement
        Dim vZIndexValue As Integer = 0
        Dim vCanGrow As Xml.XmlElement
        Dim vCanGrowValue As String = "true"
        Dim vValue As Xml.XmlElement
        Dim vHeight As Xml.XmlElement
        Dim vHeightValue As Double = 0.5
        Dim vRepeatOnNewPage As Xml.XmlElement
        Dim vRepeatOnNewPageValue As String = "true"

        Dim vNameSpace As String = pDocXML.GetElementsByTagName("Report").Item(0).NamespaceURI

        ' Création de tous les éléments

        If Not pDocXML.GetElementsByTagName("Table").Item(pNumTable) Is Nothing Then
            vTable = pDocXML.GetElementsByTagName("Table").Item(pNumTable)

            ' <TableGroups>
            If vTable.GetElementsByTagName("TableGroups").Count < 1 Then
                vTableGroups = pDocXML.CreateElement("TableGroups", vNameSpace)
            Else
                vTableGroups = vTable.GetElementsByTagName("TableGroups").Item(0)
            End If

            ' <TableGroup>
            vTableGroup = pDocXML.CreateElement("TableGroup", vNameSpace)

            ' <Grouping Name = 'vGrAttName'>
            vGrouping = pDocXML.CreateElement("Grouping", vNameSpace)
            vGrAttName = pDocXML.CreateAttribute("Name")
            vRuptureName = "I_Tab" & pNumTable & "_Rupture" & vTable.GetElementsByTagName("Grouping").Count
            vGrAttName.Value = vRuptureName
            vGrouping.SetAttributeNode(vGrAttName)

            ' <GroupExpressions>
            vGroupExpressions = pDocXML.CreateElement("GroupExpressions", vNameSpace)

            ' <vGroupExpression>
            vGroupExpression = pDocXML.CreateElement("GroupExpression", vNameSpace)
            vGroupExpression.InnerText = "=Fields!" & pRupture & ".Value"
            ' </vGroupExpression>

            ' </GroupExpressions>

            ' </Grouping>

            ' <Header>
            vHeader = pDocXML.CreateElement("Header", vNameSpace)

            '  <TableRows>
            vTableRows = pDocXML.CreateElement("TableRows", vNameSpace)

            '    <TableRow>
            vTableRow = pDocXML.CreateElement("TableRow", vNameSpace)

            '      <TableCells>
            vTableCells = pDocXML.CreateElement("TableCells", vNameSpace)

            '        <TableCell>
            vTableCell = pDocXML.CreateElement("TableCell", vNameSpace)

            '          <ColSpan>
            vColSpan = pDocXML.CreateElement("ColSpan", vNameSpace)
            vColSpan.InnerText = vTable.GetElementsByTagName("TableColumns").Item(0).ChildNodes.Count
            '          </ColSpan>

            '          <ReportItems>
            vReportItems = pDocXML.CreateElement("ReportItems", vNameSpace)

            '            <Textbox Name="textbox4">
            vTextBox = pDocXML.CreateElement("Textbox", vNameSpace)
            vTextBoxAttName = pDocXML.CreateAttribute("Name")
            vTextBoxAttName.Value = vRuptureName & "Titre"
            vTextBox.SetAttributeNode(vTextBoxAttName)

            '              <Style>
            vStyle = pDocXML.CreateElement("Style", vNameSpace)

            '                <BackgroundColor>
            vBackgroundColor = pDocXML.CreateElement("BackgroundColor", vNameSpace)
            vBackgroundColor.InnerText = pCouleur
            '                </BackgroundColor>

            '                <FontSize>
            vFontSize = pDocXML.CreateElement("FontSize", vNameSpace)
            vFontSize.InnerText = vFontSizeValue
            '                </FontSize>

            '                <FontWeight>
            vFontWeight = pDocXML.CreateElement("FontWeight", vNameSpace)
            vFontWeight.InnerText = vFontWeightValue
            '                </FontWeight>

            '                <TextAlign>
            vTextAlign = pDocXML.CreateElement("TextAlign", vNameSpace)
            vTextAlign.InnerText = vTextAlignValue
            '                </TextAlign>

            '                <VerticalAlign>
            vVerticalAlign = pDocXML.CreateElement("VerticalAlign", vNameSpace)
            vVerticalAlign.InnerText = vVerticalAlignValue
            '                </VerticalAlign>

            '                <PaddingLeft>
            vPaddingLeft = pDocXML.CreateElement("PaddingLeft", vNameSpace)
            vPaddingLeft.InnerText = vPaddingLeftValue
            '                </PaddingLeft>

            '                <PaddingRight>
            vPaddingRight = pDocXML.CreateElement("PaddingRight", vNameSpace)
            vPaddingRight.InnerText = vPaddingValue
            '                </PaddingRight>

            '                <PaddingTop>
            vPaddingTop = pDocXML.CreateElement("PaddingTop", vNameSpace)
            vPaddingTop.InnerText = vPaddingValue
            '                </PaddingTop>

            '                <PaddingBottom>
            vPaddingBottom = pDocXML.CreateElement("PaddingBottom", vNameSpace)
            vPaddingBottom.InnerText = vPaddingValue
            '                </PaddingBottom>

            '              </Style>

            '              <ZIndex>
            vZIndex = pDocXML.CreateElement("ZIndex", vNameSpace)
            vZIndex.InnerText = pDocXML.GetElementsByTagName("ZIndex").Count + 1
            '              </ZIndex>

            '              <CanGrow>
            vCanGrow = pDocXML.CreateElement("CanGrow", vNameSpace)
            vCanGrow.InnerText = vCanGrowValue
            '              </CanGrow>

            '              <Value>
            vValue = pDocXML.CreateElement("Value", vNameSpace)
            vValue.InnerText = "=Fields!" & pRupture & ".Value"
            '              </Value>

            '            </Textbox>
            '          </ReportItems>
            '        </TableCell>
            '      </TableCells>

            '      <Height>
            vHeight = pDocXML.CreateElement("Height", vNameSpace)
            vHeight.InnerText = vHeightValue & "cm"
            '       </Height>

            '    </TableRow>
            '  </TableRows>

            '  <RepeatOnNewPage>
            vRepeatOnNewPage = pDocXML.CreateElement("RepeatOnNewPage", vNameSpace)
            vRepeatOnNewPage.InnerText = vRepeatOnNewPageValue
            '  </RepeatOnNewPage>

            '</Header>
            ' </TableGroup>
            ' </TableGroups>


            ' Imbrication des éléments

            ' Constitution du bloc Grouping
            vGroupExpressions.AppendChild(vGroupExpression)
            vGrouping.AppendChild(vGroupExpressions)

            ' Constition du Bloc Header
            '       Bloc Style
            vStyle.AppendChild(vBackgroundColor)
            vStyle.AppendChild(vFontSize)
            vStyle.AppendChild(vFontWeight)
            vStyle.AppendChild(vTextAlign)
            vStyle.AppendChild(vVerticalAlign)
            vStyle.AppendChild(vPaddingLeft)
            vStyle.AppendChild(vPaddingRight)
            vStyle.AppendChild(vPaddingTop)
            vStyle.AppendChild(vPaddingBottom)
            '       Bloc TextBox
            vTextBox.AppendChild(vStyle)
            vTextBox.AppendChild(vZIndex)
            vTextBox.AppendChild(vCanGrow)
            vTextBox.AppendChild(vValue)

            vReportItems.AppendChild(vTextBox)
            vTableCell.AppendChild(vColSpan)
            vTableCell.AppendChild(vReportItems)
            vTableCells.AppendChild(vTableCell)
            vTableRow.AppendChild(vTableCells)
            vTableRow.AppendChild(vHeight)
            vTableRows.AppendChild(vTableRow)

            vHeader.AppendChild(vTableRows)
            vHeader.AppendChild(vRepeatOnNewPage)

            ' Ajout des enfants de TableGroup
            vTableGroup.AppendChild(vGrouping)
            vTableGroup.AppendChild(vHeader)

            vTableGroups.AppendChild(vTableGroup)
            If vTable.GetElementsByTagName("TableGroups").Count < 1 Then
                vTable.InsertAfter(vTableGroups, vTable.GetElementsByTagName("DataSetName").Item(0))
            End If
        End If
    End Sub

    'Public Sub ImpListe(ByVal pEtat As String, ByVal pParcours As Parcours, ByVal pRequete As Requete)
    '    Dim vParam As New Generic.List(Of ReportParameter)
    '    Dim vReportViewer As New ReportViewer

    '    Dim vfichier As String

    '    Dim vDoc As New Xml.XmlDocument
    '    If pEtat.StartsWith("\") Then
    '        vfichier = ParamLect("REP_ETAT")
    '    Else
    '        vfichier = ParamLect("REP_ETAT") & "\"
    '    End If
    '    vfichier += pEtat
    '    vDoc.Load(vfichier)

    '    pParcours.FiltreCreation(pRequete, pParcours.FenPrinc)

    '    ' Creation des rupture
    '    pParcours.CreationRupture(vDoc, pRequete)

    '    '******************* IMPRESSION *********************
    '    Dim vTemp As String = My.Computer.FileSystem.GetTempFileName.Replace(".tmp", ".rdlc")
    '    vDoc.Save(vTemp)
    '    Try
    '        Dim vStream As New System.IO.StreamReader(vTemp)
    '        vReportViewer.LocalReport.LoadReportDefinition(vStream)
    '        vStream.Close()
    '        My.Computer.FileSystem.DeleteFile(vTemp)
    '        '*** Affectation des parametres de l'Etat ***
    '        vParam.Add(New ReportParameter("pFiltreStr", pRequete.filtreLitteral))
    '        vReportViewer.LocalReport.SetParameters(vParam)

    '        '*** Generation des donnée sous forme d'un dataTable ***
    '        vReportViewer.LocalReport.DataSources.Clear()
    '        vReportViewer.LocalReport.DataSources.Add(New ReportDataSource("SELECTION", ExecuteRequeteR(pRequete.ToString, gConnectionALSPERS)))

    '        iApercu(vReportViewer, 0)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
End Module
