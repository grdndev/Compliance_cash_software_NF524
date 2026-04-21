Public Class FormTest

    Private Sub T_Article_EnteteBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Article_EnteteBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_Article_EnteteBindingSource.EndEdit()
        Me.T_Article_EnteteTableAdapter.Update(Me.CLIDataSet.T_Article_Entete)
        Me.T_Article_DetailBindingSource.Current.item("id_t_article_entete") = Me.T_Article_EnteteBindingSource.Current.item("id_t_article_entete")
        Me.T_Article_DetailBindingSource.EndEdit()
        Me.T_Article_DetailTableAdapter.Update(Me.CLIDataSet.T_Article_Detail)
        Me.T_Article_versionBindingSource.Current.item("id_t_article_detail") = Me.T_Article_DetailBindingSource.Current.item("id_t_article_detail")
        Me.T_Article_versionBindingSource.EndEdit()
        Me.T_Article_versionTableAdapter.Update(Me.CLIDataSet.T_Article_version)
      
    End Sub

    Private Sub FormTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Article_version'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_Article_EnteteTableAdapter.Fill(Me.CLIDataSet.T_Article_Entete)
        Me.T_Article_DetailTableAdapter.Fill(Me.CLIDataSet.T_Article_Detail)
        Me.T_Article_versionTableAdapter.Fill(Me.CLIDataSet.T_Article_version)
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Article_Detail'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Article_Entete'. Vous pouvez la déplacer ou la supprimer selon vos besoins.


    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim entete As CLIDataSet.T_Article_EnteteRow = CLIDataSet.T_Article_Entete.NewT_Article_EnteteRow
        CLIDataSet.T_Article_Entete.AddT_Article_EnteteRow(entete)
        Dim detail As CLIDataSet.T_Article_DetailRow = CLIDataSet.T_Article_Detail.NewT_Article_DetailRow
        detail.T_Article_EnteteRow = entete
        CLIDataSet.T_Article_Detail.AddT_Article_DetailRow(detail)
        Dim version As CLIDataSet.T_Article_versionRow = CLIDataSet.T_Article_version.NewT_Article_versionRow
        version.T_Article_DetailRow = detail
        CLIDataSet.T_Article_version.AddT_Article_versionRow(version)


    End Sub
End Class