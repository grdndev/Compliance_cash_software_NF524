Public Class FormNewsLetter

    Private Sub NewsletterBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewsletterBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.NewsletterBindingSource.EndEdit()
        Me.NewsletterTableAdapter.Update(Me.CLIDataSet.newsletter)

    End Sub

    Private Sub FormNewsLetter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.newsletter'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.NewsletterTableAdapter.Fill(Me.CLIDataSet.newsletter)

    End Sub
End Class