Imports RestSharp

Public Class FormImportCommande
    Private Sub BT_Import_Click(sender As Object, e As EventArgs) Handles BT_Import.Click
        'si le numero de commande est saisi
        If I_Numero.Text <> "" Then
            'on appelle l'api pour importer la commande
            CliApi.ApiCallBuffer("/order/ImportFromPSByIdAsync", Method.POST, New ToCliDto With {.Id = I_Numero.Text, .Force = CB_Force.Checked}, Nothing)
            MessageBox.Show("Import en cours", "Demande d'import", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Veuillez saisir un numéro de commande", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
End Class