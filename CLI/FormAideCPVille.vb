Imports System.Windows.Forms

Public Class FormAideCPVille

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub I_CP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_CP.GotFocus
        I_Ville.Clear()
    End Sub

    Private Sub I_CP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles I_CP.TextChanged
        Dim vVilleCP As New DataTable
        If I_CP.Text.Length >= 2 Then
            vVilleCP = ExecuteRequeteR("select codepostal as [CodePostal], ville as [Ville] from t_cpvilleFR where codepostal like '%" & sender.text & "%' order by codepostal", My.Settings.CLIConnectionString)
        End If
        DGV.DataSource = vVilleCP
    End Sub

    Private Sub FormAideCPVille_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



     
    End Sub

    Private Sub I_Ville_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Ville.GotFocus
        I_CP.Clear()
    End Sub

    Private Sub I_Ville_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles I_Ville.TextChanged
        Dim vVilleCP As New DataTable
        ' If I_Ville.Text.Length >= 2 Then
        vVilleCP = ExecuteRequeteR("select codepostal as [CodePostal], ville as [Ville] from t_cpvilleFR where ville like '%" & sender.text & "%' order by codepostal", My.Settings.CLIConnectionString)
        ' End If
        IL_Enregistrements.Text = vVilleCP.Rows.Count & " enregistrements correspondants"
        DGV.DataSource = vVilleCP


    End Sub
End Class
