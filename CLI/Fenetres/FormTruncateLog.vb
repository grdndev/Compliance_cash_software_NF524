Imports RestSharp

Public Class FormTruncateLog
    Private Sub BT_Tronquer_Click(sender As Object, e As EventArgs) Handles BT_Tronquer.Click
        CliApi.ApiCallBuffer("log/EraseExceptLast", Method.POST, New ToCliDto With {.Number = I_Number.Text}, Nothing)
        MessageBox.Show("Effactement en cours", "Demande d'effacement log", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class