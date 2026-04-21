Imports System
Imports System.Text
Imports System.Collections
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Data
Imports System.Windows.Forms

Namespace DataGridViewPrinter
    Public Class DataGridViewPrinter

        Private gTheDataFont As Font
        Private gTheDataColor As Color

        Private gDataGridView As DataGridView
        ' The DataGridView Control which will be printed
        Public gPrintDocument As PrintDocument
        ' The PrintDocument to be used for printing
        Private gIsCenterOnPage As Boolean
        ' Determine if the report will be printed in the Top-Center of the page
        Private gIsWithTitle As Boolean
        ' Determine if the page contain title text
        Private TheTitleText As String
        ' The title text to be printed in each page (if IsWithTitle is set to true)
        Private TheTitleFont As Font
        ' The font to be used with the title text (if IsWithTitle is set to true)
        Private TheTitleColor As Color
        ' The color to be used with the title text (if IsWithTitle is set to true)
        Private gIsWithPaging As Boolean
        ' Determine if paging is used
        Shared CurrentRow As Integer
        ' A static parameter that keep track on which Row (in the DataGridView control) that should be printed
        Public Shared gPageNumber As Integer
        Public Shared gCalculFait As Boolean

        Private gPageWidth As Integer
        Private gPageHeight As Integer
        Private gLeftMargin As Integer
        Private gTopMargin As Integer
        Private gRightMargin As Integer
        Private gBottomMargin As Integer

        Private CurrentY As Single
        ' A parameter that keep track on the y coordinate of the page, so the next object to be printed will start from this y coordinate
        Private gRowHeaderHeight As Single
        Private gRowsHeight As List(Of Single)
        Private gColumnsWidth As List(Of Single)
        Private gTheDataGridViewWidth As Single

        ' Maintain a generic list to hold start/stop points for the column printing
        ' This will be used for wrapping in situations where the DataGridView will not fit on a single page
        Private mColumnPoints As List(Of Integer())
        Private mColumnPointsWidth As List(Of Single)
        Private mColumnPoint As Integer

        Private Shared PrintTitle As String = ""               ' Header of pages
        Private Shared gSelectedColumns As New List(Of String)  ' The Columns Selected by user to print.
        Private Shared AvailableColumns As New List(Of String) ' All Columns avaiable in DataGridView   
        Private Shared SelectedRows As New List(Of Integer) ' All Columns avaiable in DataGridView

        Private PrintRowColors As Boolean = False 'modification according mabrouklepoux

        Public Sub New()
        End Sub
        ' The class constructor
        Public Sub New(ByVal aDataGridView As DataGridView, ByVal aPrintDocument As PrintDocument, ByVal CenterOnPage As Boolean, ByVal WithTitle As Boolean, ByVal aTitleText As String, ByVal aTitleFont As Font, _
                       ByVal aTitleColor As Color, ByVal aDataFont As Font, ByVal aDataColor As Color, ByVal WithPaging As Boolean)
            Init_Parameters(aDataGridView, aPrintDocument, CenterOnPage, WithTitle, aTitleText, aTitleFont, aTitleColor, aDataFont, aDataColor, WithPaging)
        End Sub

        '= Old Constructor
        Private Sub Init_Parameters(ByVal pDataGridView As DataGridView, ByVal pPrintDocument As PrintDocument, ByVal CenterOnPage As Boolean, ByVal WithTitle As Boolean, ByVal aTitleText As String, ByVal aTitleFont As Font, _
         ByVal aTitleColor As Color, ByVal aDataFont As Font, ByVal aDataColor As Color, ByVal WithPaging As Boolean)
            gDataGridView = pDataGridView
            gPrintDocument = pPrintDocument
            gIsCenterOnPage = CenterOnPage
            gIsWithTitle = WithTitle
            TheTitleText = aTitleText
            TheTitleFont = aTitleFont
            TheTitleColor = aTitleColor
            gTheDataFont = aDataFont
            gTheDataColor = aDataColor
            gIsWithPaging = WithPaging

            gPageNumber = 0
            gCalculFait = False

            gRowsHeight = New List(Of Single)()
            gColumnsWidth = New List(Of Single)()

            mColumnPoints = New List(Of Integer())()
            mColumnPointsWidth = New List(Of Single)()

            ' récupére la hauteur et la largeur de la page
            If Not gPrintDocument.DefaultPageSettings.Landscape Then
                gPageWidth = gPrintDocument.DefaultPageSettings.PaperSize.Width
                gPageHeight = gPrintDocument.DefaultPageSettings.PaperSize.Height
            Else
                gPageHeight = gPrintDocument.DefaultPageSettings.PaperSize.Width
                gPageWidth = gPrintDocument.DefaultPageSettings.PaperSize.Height
            End If

            ' Récupération des marges
            gLeftMargin = gPrintDocument.DefaultPageSettings.Margins.Left
            gTopMargin = gPrintDocument.DefaultPageSettings.Margins.Top
            gRightMargin = gPrintDocument.DefaultPageSettings.Margins.Right
            gBottomMargin = gPrintDocument.DefaultPageSettings.Margins.Bottom

            ' First, the current row to be printed is the first row in the DataGridView control
            CurrentRow = 0
        End Sub

        '**************************************************************************************************
        '*                               PROCEDURE EST FONCTION                                           *
        '**************************************************************************************************
        Private Sub Calculate(ByVal g As Graphics)
            '**********************************************************************
            '*                              CALCULATE                             *
            '*   calcule : la hauteur de chaque ligne (entete comprise)           *
            '*             la largeur de chaque colonne (entete comprise          *
            '*             la largeur total du datagridview                       *
            '**********************************************************************
            If Not gCalculFait Then 'calculé une seul fois
                'Variables
                Dim tmpSize As New SizeF()
                Dim tmpFont As Font
                Dim tmpWidth As Single

                gCalculFait = True '*** Modification CCt réinitialisation du N° de page

                gTheDataGridViewWidth = 0
                For i As Integer = 0 To gDataGridView.Columns.Count - 1
                    'tmpFont = TheDataGridView.ColumnHeadersDefaultCellStyle.Font
                    tmpFont = gTheDataFont

                    If tmpFont Is Nothing Then
                        tmpFont = gDataGridView.DefaultCellStyle.Font
                        ' If there is no special HeaderFont style, then use the default DataGridView font style
                    End If

                    tmpSize = g.MeasureString(gDataGridView.Columns(i).HeaderText, tmpFont)
                    tmpWidth = tmpSize.Width
                    gRowHeaderHeight = tmpSize.Height
                    For j As Integer = 0 To gDataGridView.Rows.Count - 1
                        If Not gDataGridView.Rows(j).IsNewRow Then
                            'tmpFont = TheDataGridView.Rows(j).DefaultCellStyle.Font
                            tmpFont = gTheDataFont
                            If tmpFont Is Nothing Then
                                tmpFont = gDataGridView.DefaultCellStyle.Font
                                ' If the there is no special font style of the CurrentRow, then use the default one associated with the DataGridView control
                            End If

                            tmpSize = g.MeasureString("Anything", tmpFont)
                            gRowsHeight.Add(tmpSize.Height)

                            tmpSize = g.MeasureString(gDataGridView.Rows(j).Cells(i).EditedFormattedValue.ToString(), tmpFont)
                            If tmpSize.Width > tmpWidth Then
                                tmpWidth = tmpSize.Width
                            End If
                        End If
                    Next
                    If gDataGridView.Columns(i).Visible Then
                        gTheDataGridViewWidth += tmpWidth
                    End If
                    gColumnsWidth.Add(tmpWidth)
                Next

                ' Define the start/stop column points based on the page width and the DataGridView Width
                ' We will use this to determine the columns which are drawn on each page and how wrapping will be handled
                ' By default, the wrapping will occurr such that the maximum number of columns for a page will be determine
                Dim k As Integer
                Dim mStartPoint As Integer = 0
                For k = 0 To gDataGridView.Columns.Count - 1
                    If gDataGridView.Columns(k).Visible Then
                        mStartPoint = k
                        Exit For
                    End If
                Next

                Dim mEndPoint As Integer = gDataGridView.Columns.Count
                For k = gDataGridView.Columns.Count - 1 To 0 Step -1
                    If gDataGridView.Columns(k).Visible Then
                        mEndPoint = k + 1
                        Exit For
                    End If
                Next

                Dim mTempWidth As Single = gTheDataGridViewWidth
                Dim mTempPrintArea As Single = CSng(gPageWidth) - CSng(gLeftMargin) - CSng(gRightMargin)

                ' vérification que la totalité du datagridview tien dans la zone d'impression
                If gTheDataGridViewWidth > mTempPrintArea Then
                    mTempWidth = 0.0F
                    For k = 0 To gDataGridView.Columns.Count - 1
                        If gDataGridView.Columns(k).Visible Then
                            mTempWidth += gColumnsWidth(k)
                            ' If the width is bigger than the page area, then define a new column print range
                            If mTempWidth > mTempPrintArea Then
                                mTempWidth -= gColumnsWidth(k)
                                mColumnPoints.Add(New Integer() {mStartPoint, mEndPoint})
                                mColumnPointsWidth.Add(mTempWidth)
                                mStartPoint = k
                                mTempWidth = gColumnsWidth(k)
                            End If
                        End If
                        ' Our end point is actually one index above the current index
                        mEndPoint = k + 1
                    Next
                End If
                ' Add the last set of columns
                mColumnPoints.Add(New Integer() {mStartPoint, mEndPoint})
                mColumnPointsWidth.Add(mTempWidth)
                mColumnPoint = 0
            End If
        End Sub

        Private Sub DrawHeader(ByVal pZGraphImp As Graphics)
            '*********************************************************************************
            '*                                    DRAW HEADER                                *
            '*        FONCTION d'impression du titre, N° de page, et entete de colonne       *
            '* ENTREE :                                                                      *
            '*    pZGraphImp : Zone graphique d'impression                                   *
            '*********************************************************************************

            CurrentY = CSng(gTopMargin)

            '****  Impression du N° de page si demandé ****
            If gIsWithPaging Then
                'Variables
                Dim vPageNumChaine As String
                Dim vPageNumFormat As New StringFormat()
                Dim vPageNumPolice As New Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point)
                Dim vPageNumCadre As RectangleF

                gPageNumber += 1
                vPageNumChaine = "Page " + gPageNumber.ToString()
                vPageNumFormat.Trimming = StringTrimming.Word
                vPageNumFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
                vPageNumFormat.Alignment = StringAlignment.Far
                vPageNumCadre = New RectangleF(CSng(gLeftMargin), CurrentY, CSng(gPageWidth) - CSng(gRightMargin) - CSng(gLeftMargin), pZGraphImp.MeasureString(vPageNumChaine, vPageNumPolice).Height)

                pZGraphImp.DrawString(vPageNumChaine, vPageNumPolice, New SolidBrush(Color.Black), vPageNumCadre, vPageNumFormat)
                CurrentY += pZGraphImp.MeasureString(vPageNumChaine, vPageNumPolice).Height
            End If

            '**** Impression du titre si demandé ****
            If gIsWithTitle Then
                'Variables
                Dim TitleFormat As New StringFormat()
                Dim vtitreCadre As RectangleF

                TitleFormat.Trimming = StringTrimming.Word
                TitleFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
                If gIsCenterOnPage Then
                    TitleFormat.Alignment = StringAlignment.Center
                Else
                    TitleFormat.Alignment = StringAlignment.Near
                End If

                vtitreCadre = New RectangleF(CSng(gLeftMargin), CurrentY, CSng(gPageWidth) - CSng(gRightMargin) - CSng(gLeftMargin), pZGraphImp.MeasureString(TheTitleText, TheTitleFont).Height)
                pZGraphImp.DrawString(TheTitleText, TheTitleFont, New SolidBrush(TheTitleColor), vtitreCadre, TitleFormat)
                CurrentY += pZGraphImp.MeasureString(TheTitleText, TheTitleFont).Height
            End If

            ' Calculating the starting x coordinate that the printing process will start from
            Dim CurrentX As Single = CSng(gLeftMargin)
            If gIsCenterOnPage Then
                CurrentX += ((CSng(gPageWidth) - CSng(gRightMargin) - CSng(gLeftMargin)) - mColumnPointsWidth(mColumnPoint)) / 2.0F
            End If

            ' Setting the HeaderFore style
            Dim HeaderForeColor As Color = gDataGridView.ColumnHeadersDefaultCellStyle.ForeColor
            If HeaderForeColor.IsEmpty Then
                HeaderForeColor = gDataGridView.DefaultCellStyle.ForeColor
                ' If there is no special HeaderFore style, then use the default DataGridView style
            End If
            Dim HeaderForeBrush As New SolidBrush(HeaderForeColor)

            ' Setting the HeaderBack style
            Dim HeaderBackColor As Color = gDataGridView.ColumnHeadersDefaultCellStyle.BackColor
            If HeaderBackColor.IsEmpty Then
                HeaderBackColor = gDataGridView.DefaultCellStyle.BackColor
                ' If there is no special HeaderBack style, then use the default DataGridView style
            End If
            Dim HeaderBackBrush As New SolidBrush(HeaderBackColor)

            ' Setting the LinePen that will be used to draw lines and rectangles (derived from the GridColor property of the DataGridView control)
            Dim TheLinePen As New Pen(gDataGridView.GridColor, 1)

            ' Setting the HeaderFont style
            'Dim HeaderFont As Font = TheDataGridView.ColumnHeadersDefaultCellStyle.Font
            Dim HeaderFont = gTheDataFont
            If HeaderFont Is Nothing Then
                HeaderFont = gDataGridView.DefaultCellStyle.Font
                ' If there is no special HeaderFont style, then use the default DataGridView font style
            End If

            ' Calculating and drawing the HeaderBounds        
            Dim HeaderBounds As New RectangleF(CurrentX, CurrentY, mColumnPointsWidth(mColumnPoint), gRowHeaderHeight)
            pZGraphImp.FillRectangle(HeaderBackBrush, HeaderBounds)

            ' Setting the format that will be used to print each cell of the header row
            Dim CellFormat As New StringFormat()
            CellFormat.Trimming = StringTrimming.Word
            CellFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit Or StringFormatFlags.NoClip

            '***** Impression des libéllées de colonnes *****
            Dim CellBounds As RectangleF
            Dim ColumnWidth As Single
            For i As Integer = CInt(mColumnPoints(mColumnPoint).GetValue(0)) To CInt(mColumnPoints(mColumnPoint).GetValue(1)) - 1
                If Not gDataGridView.Columns(i).Visible Then
                    Continue For
                End If
                ' If the column is not visible then ignore this iteration
                ColumnWidth = gColumnsWidth(i)

                ' Check the CurrentCell alignment and apply it to the CellFormat
                If gDataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Right") Then
                    CellFormat.Alignment = StringAlignment.Far
                ElseIf gDataGridView.ColumnHeadersDefaultCellStyle.Alignment.ToString().Contains("Center") Then
                    CellFormat.Alignment = StringAlignment.Center
                Else
                    CellFormat.Alignment = StringAlignment.Near
                End If

                CellBounds = New RectangleF(CurrentX, CurrentY, ColumnWidth, gRowHeaderHeight)

                ' Printing the cell text
                pZGraphImp.DrawString(gDataGridView.Columns(i).HeaderText, HeaderFont, HeaderForeBrush, CellBounds, CellFormat)

                ' Drawing the cell bounds
                If gDataGridView.RowHeadersBorderStyle <> DataGridViewHeaderBorderStyle.None Then
                    pZGraphImp.DrawRectangle(TheLinePen, CurrentX, CurrentY, ColumnWidth, gRowHeaderHeight)
                    ' Draw the cell border only if the HeaderBorderStyle is not None
                End If

                CurrentX += ColumnWidth
            Next

            CurrentY += gRowHeaderHeight
        End Sub

        Private Function DrawRows(ByVal pGraph As Graphics) As Boolean
            '**********************************************************************
            '*                             DRAWROWS                               *
            '* Imprime une page de ligne                                          *
            '* ENTREE :                                                           *
            '*  pGraph : zone graphique                                           *
            '* SORTIE :                                                           *
            '*  True : il reste des lignes à imprimer                             *
            '*  False: Tous les lignes sont imprimée                              *
            '**********************************************************************
            ' Setting the LinePen that will be used to draw lines and rectangles (derived from the GridColor property of the DataGridView control)
            Dim TheLinePen As New Pen(gDataGridView.GridColor, 1)

            ' The style paramters that will be used to print each cell
            Dim vRowFont As Font
            Dim vRowForeColor As Color
            Dim vRowBackColor As Color
            Dim vRowForeBrush As SolidBrush
            Dim vRowBackBrush As SolidBrush
            Dim vRowAlternatingBackBrush As SolidBrush

            ' Défini le format à utiliser pour chaque cellule
            Dim vCellFormat As New StringFormat()
            vCellFormat.Trimming = StringTrimming.Word
            vCellFormat.FormatFlags = StringFormatFlags.NoWrap Or StringFormatFlags.LineLimit

            ' imprime chaque cellule visible
            Dim RowBounds As RectangleF
            Dim CurrentX As Single
            Dim ColumnWidth As Single
            While CurrentRow < gDataGridView.Rows.Count
                If gDataGridView.Rows(CurrentRow).Visible And Not gDataGridView.Rows(CurrentRow).IsNewRow Then
                    ' Print the cells of the CurrentRow only if that row is visible

                    'utilise la police spécié sinon celle du datagridview
                    vRowFont = gTheDataFont
                    If vRowFont Is Nothing Then
                        vRowFont = gDataGridView.DefaultCellStyle.Font
                    End If

                    'utilise la couleur de fond spécifié sinon celle du datagridview
                    vRowForeColor = gTheDataColor
                    If vRowForeColor.IsEmpty Then
                        vRowForeColor = gDataGridView.DefaultCellStyle.ForeColor
                    End If

                    vRowForeBrush = New SolidBrush(vRowForeColor)

                    ' Setting the RowBack (for even rows) and the RowAlternatingBack (for odd rows) styles
                    vRowBackColor = gDataGridView.Rows(CurrentRow).DefaultCellStyle.BackColor
                    If vRowBackColor.IsEmpty Then
                        ' If the there is no special RowBack style of the CurrentRow, then use the default one associated with the DataGridView control
                        vRowBackBrush = New SolidBrush(gDataGridView.DefaultCellStyle.BackColor)
                        vRowAlternatingBackBrush = New SolidBrush(gDataGridView.AlternatingRowsDefaultCellStyle.BackColor)
                    Else
                        ' If the there is a special RowBack style of the CurrentRow, then use it for both the RowBack and the RowAlternatingBack styles
                        vRowBackBrush = New SolidBrush(vRowBackColor)
                        vRowAlternatingBackBrush = New SolidBrush(vRowBackColor)
                    End If

                    ' Calculating the starting x coordinate that the printing process will start from
                    CurrentX = CSng(gLeftMargin)
                    If gIsCenterOnPage Then
                        CurrentX += ((CSng(gPageWidth) - CSng(gRightMargin) - CSng(gLeftMargin)) - mColumnPointsWidth(mColumnPoint)) / 2.0F
                    End If

                    ' Calculating the entire CurrentRow bounds                
                    RowBounds = New RectangleF(CurrentX, CurrentY, mColumnPointsWidth(mColumnPoint), gRowsHeight(CurrentRow))

                    ' Filling the back of the CurrentRow
                    If Me.PrintRowColors = False Then 'modification according mabrouklepoux
                        If CurrentRow Mod 2 = 0 Then
                            pGraph.FillRectangle(vRowBackBrush, RowBounds)
                        Else
                            pGraph.FillRectangle(vRowAlternatingBackBrush, RowBounds)
                        End If
                    End If
                    For CurrentCell As Integer = CInt(mColumnPoints(mColumnPoint).GetValue(0)) To CInt(mColumnPoints(mColumnPoint).GetValue(1)) - 1

                        ' Printing each visible cell of the CurrentRow                
                        If Not gDataGridView.Columns(CurrentCell).Visible Then
                            Continue For
                        End If
                        ' If the cell is belong to invisible column, then ignore this iteration
                        ' Check the CurrentCell alignment and apply it to the CellFormat
                        If gDataGridView.Columns(CurrentCell).DefaultCellStyle.Alignment.ToString().Contains("Right") Then
                            vCellFormat.Alignment = StringAlignment.Far
                        ElseIf gDataGridView.Columns(CurrentCell).DefaultCellStyle.Alignment.ToString().Contains("Center") Then
                            vCellFormat.Alignment = StringAlignment.Center
                        Else
                            vCellFormat.Alignment = StringAlignment.Near
                        End If

                        ColumnWidth = gColumnsWidth(CurrentCell)
                        Dim CellBounds As New RectangleF(CurrentX, CurrentY, ColumnWidth, gRowsHeight(CurrentRow))
                        If PrintRowColors = True Then 'block added by mabrouklepoux
                            ' printing the cell backcolor 
                            pGraph.FillRectangle(New SolidBrush(gDataGridView.Rows(CurrentRow).Cells(CurrentCell).Style.BackColor), CellBounds)
                        End If

                        ' *** Imprime le text de la cellule ***
                        pGraph.DrawString(gDataGridView.Rows(CurrentRow).Cells(CurrentCell).EditedFormattedValue.ToString(), vRowFont, vRowForeBrush, CellBounds, vCellFormat)
                        ' *** imprime le cadre de la cellule ****
                        If gDataGridView.CellBorderStyle <> DataGridViewCellBorderStyle.None Then
                            pGraph.DrawRectangle(TheLinePen, CurrentX, CurrentY, ColumnWidth, gRowsHeight(CurrentRow))
                            ' Draw the cell border only if the CellBorderStyle is not None
                        End If
                        CurrentX += ColumnWidth

                    Next
                    CurrentY += gRowsHeight(CurrentRow)

                    ' Checking if the CurrentY is exceeds the page boundries
                    ' If so then exit the function and returning true meaning another PagePrint action is required
                    If CInt(CurrentY) > (gPageHeight - gTopMargin - gBottomMargin) Then
                        CurrentRow += 1
                        Return True
                    End If
                End If
                CurrentRow += 1
            End While

            CurrentRow = 0
            mColumnPoint += 1
            ' Continue to print the next group of columns
            If mColumnPoint = mColumnPoints.Count Then
                ' Which means all columns are printed
                mColumnPoint = 0
                gPageNumber = 0 '*** Modification CCt réinitialisation du N° de page
                Return False
            Else
                Return True
            End If
        End Function

        Public Function DrawDataGridView(ByVal pZgraphImp As Graphics) As Boolean
            '**********************************************************************
            '*                     METHODE DRAWDataGridView                       *
            '*           The method that calls all other functions                *
            '**********************************************************************
            Dim vcontinue As Boolean

            Try
                Calculate(pZgraphImp)
                DrawHeader(pZgraphImp)
                vcontinue = DrawRows(pZgraphImp)
                Return vcontinue

            Catch ex As Exception
                MessageBox.Show("Operation failed: " + ex.Message.ToString(), Application.ProductName + " - Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End Try
        End Function

        Public Function SetupThePrinting(ByVal pDataGridView As DataGridView, Optional ByVal TitleText As String = "", Optional ByVal pPaysage As Boolean = False) As Boolean
            '**********************************************************************
            '*                     METHODE SetupThePrinting                       *
            '*           Définition des parametres d'impression graphique         *
            '**********************************************************************
            Dim vDataGridViewPrint As New DataGridView
            Dim iRow As Integer
            Dim iCol As Integer = 0
            Dim RowCount As Integer = 0
            Dim IsMultiselected As Boolean = pDataGridView.SelectedRows.Count > 1

            AvailableColumns.Clear()
            gSelectedColumns.Clear()
            SelectedRows.Clear()

            '***************************************
            '* Change la couleur des entetes       *
            '***************************************
            With vDataGridViewPrint
                With .ColumnHeadersDefaultCellStyle
                    .BackColor = Color.Navy
                    .ForeColor = Color.White
                    .Font = New Font(vDataGridViewPrint.Font, FontStyle.Bold)
                End With
                .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                .CellBorderStyle = DataGridViewCellBorderStyle.Single
                .GridColor = Color.Black
                ' Set the selection background color for all the cells.
                .DefaultCellStyle.SelectionBackColor = Color.Yellow 'Color.White
                .DefaultCellStyle.SelectionForeColor = Color.Navy   'Color.Black

                ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
                ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
                .RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

                ' Set the background color for all rows and for alternating rows. 
                ' The value for alternating rows overrides the value for all rows. 
                .RowsDefaultCellStyle.BackColor = Color.LightGray
                .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke  'Color.DarkGray
            End With


            'récupére la liste des colonnes du datagridview à imprimer
            For Each c As DataGridViewColumn In pDataGridView.Columns
                If c.Displayed Then AvailableColumns.Add(c.HeaderText) 'Modification CCT n'intégre pas les colonnes masquée
            Next

            ' Affiche la fenetre des options
            Dim dlg As New PrintOptions(TitleText, AvailableColumns, Not IsMultiselected)
            If pPaysage Then
                dlg.IC_Paysage.Checked = True
            Else
                dlg.IC_Portrait.Checked = True
            End If
            If dlg.ShowDialog() <> DialogResult.OK Then Exit Function
            gSelectedColumns = dlg.GetSelectedColumns

            Dim SelectedColumnsName As New List(Of String)
            Dim vCol As String

            For Each vCol In gSelectedColumns
                For Each column As DataGridViewColumn In pDataGridView.Columns
                    If column.HeaderText = vCol Then SelectedColumnsName.Add(column.Name & Chr(9) & column.HeaderText) 'Modification cct
                Next
            Next

            'Création d'un tableau intermediaire en fonction de la selection des colonnes et des lignes.
            For iRow = 0 To pDataGridView.Rows.Count - 1
                If Not pDataGridView.Rows(iRow).IsNewRow Then
                    If Not dlg.PrintAllRows Then
                        If pDataGridView.Rows(iRow).Selected = True Then
                            SelectedRows.Add(iRow)
                            RowCount += 1
                        End If
                    Else
                        SelectedRows.Add(iRow)
                        RowCount += 1
                    End If
                End If
            Next
            vDataGridViewPrint.ColumnCount = gSelectedColumns.Count
            vDataGridViewPrint.Rows.Add(RowCount)

            Dim iRow2 As Integer = 0
            Dim vchamp(1) As String
            For Each i As String In SelectedColumnsName  'Bug corrected SelectedColumns
                vchamp = i.Split(Chr(9))
                vDataGridViewPrint.Columns(iCol).Name = vchamp(0) ' modification cCT
                vDataGridViewPrint.Columns(iCol).HeaderText = vchamp(1) ' modification cCT
                vDataGridViewPrint.Columns(iCol).DefaultCellStyle.Alignment = pDataGridView.Columns(vchamp(0)).InheritedStyle.Alignment 'Modification Fransk Tetu

                For iRow = 0 To RowCount - 1
                    vDataGridViewPrint.Rows(iRow).Cells(iCol).Style = pDataGridView.Rows(SelectedRows(iRow)).Cells(vchamp(0)).Style 'Modification cct
                    vDataGridViewPrint.Rows(iRow).Cells(iCol).Value = pDataGridView.Rows(SelectedRows(iRow)).Cells(vchamp(0)).EditedFormattedValue 'Modification cct
                Next
                iCol += 1
            Next

            Me.PrintRowColors = dlg.PrintRowColors  'modification according mabrouklepoux
            gPrintDocument = New PrintDocument

            gPrintDocument.DocumentName = dlg.PrintTitle
            gPrintDocument.PrinterSettings.PrinterName = dlg.I_Imprimante.Text
            gPrintDocument.DefaultPageSettings.Landscape = dlg.IC_Paysage.Checked
            gPrintDocument.DefaultPageSettings.Margins = New Margins(50, 50, 50, 50)

            Init_Parameters(vDataGridViewPrint, gPrintDocument, dlg.PrintCenterReportOnPage, True, gPrintDocument.DocumentName, New Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Point), Color.Black, dlg.PrintFont, dlg.PrintFontColor, True)
            Return True
        End Function
    End Class
End Namespace