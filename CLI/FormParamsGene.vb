Public Class FormParamsGene

    Private Sub T_ParamBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_ParamBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_ParamBindingSource.EndEdit()
        Me.T_ParamTableAdapter.Update(Me.CLIDataSet.T_Param)

    End Sub

    Private Sub FormParams_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Param'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_ParamTableAdapter.Fill(Me.CLIDataSet.T_Param)

    End Sub
End Class