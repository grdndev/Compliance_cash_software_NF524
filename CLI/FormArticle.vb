Public Class FormArticle


    Private Sub T_Article_EnteteBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Article_EnteteBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_Article_EnteteBindingSource.EndEdit()
        Me.T_Article_EnteteTableAdapter.Update(Me.CLIDataSet.T_Article_Entete)
        Me.T_Article_DetailBindingSource.EndEdit()
        Me.T_Article_DetailTableAdapter.Update(Me.CLIDataSet.T_Article_Detail)
        Me.T_Article_versionBindingSource.EndEdit()
        Me.T_Article_versionTableAdapter.Update(Me.CLIDataSet.T_Article_version)
    End Sub

    Private Sub FormArticle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Article_version'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_Article_versionTableAdapter.Fill(Me.CLIDataSet.T_Article_version)
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Article_Detail'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_Article_DetailTableAdapter.Fill(Me.CLIDataSet.T_Article_Detail)
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Article_Entete'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_Article_EnteteTableAdapter.Fill(Me.CLIDataSet.T_Article_Entete)

    End Sub
End Class