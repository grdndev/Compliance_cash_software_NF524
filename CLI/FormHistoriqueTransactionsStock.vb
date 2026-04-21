
Public Class FormHistoriqueTransactionsStock

    Public vId As Integer
    Public vDu As String
    Public vAu As String


    Private Sub FormHistoriqueTransactionsStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Affiche()
        Initialisation()
    End Sub
    Public Sub Affiche(Optional ByVal pFilter As String = "")
        T_Article_StockTableAdapter.FillByIdTArticleVersion(CLIDataSet.T_Article_Stock, vId)
        TextBoxTotalEntree.Text = CLIDataSet.T_Article_Stock.Compute("sum(operation)", "operation>0" & pFilter).ToString
        TextBoxTotalSortie.Text = CLIDataSet.T_Article_Stock.Compute("sum(operation)", "operation<0" & pFilter).ToString
        T_Article_StockBindingSource.Filter = "id_t_article_stock>0" & pFilter
    End Sub
    Public Sub Initialisation()
        vDu = CLIDataSet.T_Article_Stock.Compute("min(date)", "").ToString
        vAu = CLIDataSet.T_Article_Stock.Compute("Max(date)", "").ToString
        If vDu <> "" Then
            DateTimePickerDu.Text = vDu
        Else
            DateTimePickerDu.Text = Now
        End If
        If vAu <> "" Then
            DateTimePickerAu.Text = vAu
        Else
            DateTimePickerAu.Text = Now

        End If
    End Sub

    Private Sub BT_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_OK.Click
        Affiche("and date >='" & DateTimePickerDu.Text & " 00:00:00' and date <='" & DateTimePickerAu.Text & " 23:59:59'")

    End Sub
End Class