Public Class FormTransactionManuelle

    Private Sub T_transaction_manuelleBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_transaction_manuelleBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_transaction_manuelleBindingSource.EndEdit()
        Me.T_transaction_manuelleTableAdapter.Update(Me.CLIDataSet.T_transaction_manuelle)

    End Sub

    Private Sub FormTransactionManuelle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_compte'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.V_compteTableAdapter.Fill(Me.CLIDataSet.V_compte)

        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_transaction_manuelle'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_transaction_manuelleTableAdapter.Fill(Me.CLIDataSet.T_transaction_manuelle)

    End Sub

    Private Sub T_transaction_manuelleDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T_transaction_manuelleDataGridView.CellContentClick

    End Sub

    Private Sub T_transaction_manuelleDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles T_transaction_manuelleDataGridView.DataError
        e.Cancel = True
    End Sub
End Class