Public Class FormAttaques

    Private Sub T_attaquesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_attaquesBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_attaquesBindingSource.EndEdit()
        Me.T_attaquesTableAdapter.Update(Me.CLIDataSet.T_attaques)

    End Sub

    Private Sub FormAttaques_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_attaques'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_attaquesTableAdapter.Fill(Me.CLIDataSet.T_attaques)

    End Sub
End Class