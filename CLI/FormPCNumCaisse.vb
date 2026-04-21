Public Class FormPCNumCaisse
    Private Sub T_PCnumcaisseBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles T_PCnumcaisseBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_PCnumcaisseBindingSource.EndEdit()
        Me.T_PCnumcaisseTableAdapter.Update(Me.CLIDataSet.T_PCnumcaisse)

    End Sub

    Private Sub FormPCNumCaisse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'CLIDataSet.T_PCnumcaisse'. Vous pouvez la déplacer ou la supprimer selon les besoins.
        Me.T_PCnumcaisseTableAdapter.Fill(Me.CLIDataSet.T_PCnumcaisse)

    End Sub
End Class