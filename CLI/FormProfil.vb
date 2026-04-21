Public Class FormProfil

    Private Sub T_ProfilBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_ProfilBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_ProfilBindingSource.EndEdit()
        Me.T_ProfilTableAdapter.Update(Me.CLIDataSet.T_Profil)

    End Sub

    Private Sub FormProfil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Profil'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_ProfilTableAdapter.Fill(Me.CLIDataSet.T_Profil)

    End Sub
End Class