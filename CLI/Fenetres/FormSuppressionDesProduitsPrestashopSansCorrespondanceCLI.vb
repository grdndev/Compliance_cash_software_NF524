Imports RestSharp

Public Class FormSuppressionDesProduitsPrestashopSansCorrespondanceCLI
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("Êtes-vous sûr ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            CliApi.ApiCallBuffer("product/DeleteProductFromPSWithNoMatchCLIAsync", Method.POST, Nothing, Nothing)
            MessageBox.Show("Suppression en cours", "Demande de suppression", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If




    End Sub
End Class