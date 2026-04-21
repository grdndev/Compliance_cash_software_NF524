Public Class FormNewsLetterView

    Private Sub NewsletterBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.NewsletterBindingSource.EndEdit()
        Me.NewsletterTableAdapter.Update(Me.CLIDataSet.newsletter)

    End Sub

    Private Sub FormNewsLetter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_Newsletter'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.V_NewsletterTableAdapter.Fill(Me.CLIDataSet.V_Newsletter)
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.newsletter'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.NewsletterTableAdapter.Fill(Me.CLIDataSet.newsletter)

    End Sub
End Class