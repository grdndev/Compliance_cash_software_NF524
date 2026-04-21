Public Class FormActualite



    Private Sub FormFamille_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Actualite'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_ActualiteTableAdapter.Fill(Me.CLIDataSet.T_Actualite)


    End Sub

    Private Sub T_ActualiteBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_ActualiteBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_ActualiteBindingSource.EndEdit()
        Me.T_ActualiteTableAdapter.Update(Me.CLIDataSet.T_Actualite)

    End Sub
End Class