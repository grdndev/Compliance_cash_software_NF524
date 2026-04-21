Public Class FormSousFamille

    Private Sub T_SousFamilleBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_SousFamilleBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_SousFamilleBindingSource.EndEdit()
        Me.T_SousFamilleTableAdapter.Update(Me.CLIDataSet.T_SousFamille)

    End Sub

    Private Sub FormSousFamille_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Famille'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_FamilleTableAdapter.Fill(Me.CLIDataSet.T_Famille)
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_SousFamille'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_SousFamilleTableAdapter.Fill(Me.CLIDataSet.T_SousFamille)

    End Sub

    Private Sub FillByToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            Me.T_SousFamilleTableAdapter.FillBy(Me.CLIDataSet.T_SousFamille)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class