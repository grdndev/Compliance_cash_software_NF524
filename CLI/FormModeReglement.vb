Public Class FormModeReglement
    Private Sub T_ParamBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_ParamBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_ModeReglementBindingSource.EndEdit()
        Me.T_modeReglementTableAdapter.Update(Me.CLIDataSet.T_modeReglement)

    End Sub

    Private Sub FormParams_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CLIDataSet.T_modeReglement' table. You can move, or remove it, as needed.
        Me.T_modeReglementTableAdapter.Fill(Me.CLIDataSet.T_modeReglement)
 

    End Sub
End Class