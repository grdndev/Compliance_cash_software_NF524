Public Class FormPays

    Private Sub T_PaysBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_PaysBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_PaysBindingSource.EndEdit()
        Me.T_PaysTableAdapter.Update(Me.CLIDataSet.T_Pays)

    End Sub

    Private Sub FormPays_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Pays'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_PaysTableAdapter.Fill(Me.CLIDataSet.T_Pays)

    End Sub
End Class