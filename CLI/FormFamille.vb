Public Class FormFamille

    Private Sub T_FamilleBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_FamilleBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_FamilleBindingSource.EndEdit()
        Me.T_FamilleTableAdapter.Update(Me.CLIDataSet.T_Famille)

    End Sub

    Private Sub FormFamille_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Famille'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_FamilleTableAdapter.Fill(Me.CLIDataSet.T_Famille)

    End Sub
End Class