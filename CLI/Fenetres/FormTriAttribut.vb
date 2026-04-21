Imports RestSharp
Imports System.Net.Mime.MediaTypeNames

Public Class FormTriAttribut
    Private Sub FormTriAttribut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objetRetour As New Object()
        CliApi.ApiCall("product/GetAllProductOptionAsync", Method.POST, Nothing, Nothing, objetRetour)
        ComboBoxAttribut.DataSource = objetRetour
        ComboBoxAttribut.ValueMember = "id"
        ComboBoxAttribut.DisplayMember = "value"
    End Sub

    Private Sub BT_Tri_Click(sender As Object, e As EventArgs) Handles BT_Tri.Click
        CliApi.ApiCallBuffer("product/SortProductOptionValueAsync", Method.POST, New ToCliDto With {.Id = ComboBoxAttribut.SelectedValue}, Nothing)
        MessageBox.Show("Tri en cours", "Demande de tri", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class