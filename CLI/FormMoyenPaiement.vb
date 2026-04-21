Public Class FormMoyenPaiement
    Private Sub T_ParamBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_ParamBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_MoyenPaiementBindingSource.EndEdit()
        Me.T_MoyenPaiementTableAdapter.Update(Me.CLIDataSet.T_MoyenPaiement)

    End Sub

    Private Sub FormParams_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CLIDataSet.T_MoyenPaiement' table. You can move, or remove it, as needed.
        Me.T_MoyenPaiementTableAdapter.Fill(Me.CLIDataSet.T_MoyenPaiement)
        

    End Sub
End Class