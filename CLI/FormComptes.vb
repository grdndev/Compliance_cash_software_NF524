Public Class FormComptes

    Private Sub T_CompteBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_CompteBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_CompteBindingSource.EndEdit()
        Me.T_CompteTableAdapter.Update(Me.CLIDataSet.T_Compte)

    End Sub

    Private Sub FormComptes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Compte'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_CompteTableAdapter.Fill(Me.CLIDataSet.T_Compte)

    End Sub
End Class