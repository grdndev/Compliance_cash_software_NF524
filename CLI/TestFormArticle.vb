Public Class TestFormArticle

    Private Sub T_Article_EnteteBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_Article_EnteteBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_Article_EnteteBindingSource.EndEdit()
        Me.T_Article_EnteteTableAdapter.Update(Me.CHINOOSURDataSet.T_Article_Entete)
        Me.T_Article_DetailTableAdapter.Update(Me.CHINOOSURDataSet.T_Article_Detail)


    End Sub

    Private Sub FormArticle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub FormArticle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        AddHandler SurfaceTextBox.DataBindings("text").Parse, AddressOf ValeurNulle
        'TODO : cette ligne de code charge les données dans la table 'CHINOOSURDataSet.V_programme'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.V_programmeTableAdapter.Fill(Me.CHINOOSURDataSet.V_programme)
        'TODO : cette ligne de code charge les données dans la table 'CHINOOSURDataSet.code_tva'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.Code_tvaTableAdapter.Fill(Me.CHINOOSURDataSet.code_tva)
        'TODO : cette ligne de code charge les données dans la table 'CHINOOSURDataSet.T_Article_Detail'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_Article_DetailTableAdapter.Fill(Me.CHINOOSURDataSet.T_Article_Detail)
        'TODO : cette ligne de code charge les données dans la table 'CHINOOSURDataSet.T_Article_Entete'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_Article_EnteteTableAdapter.Fill(Me.CHINOOSURDataSet.T_Article_Entete)

    End Sub

    Private Sub SurfaceTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SurfaceTextBox.TextChanged

    End Sub

    Private Sub SurfaceTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SurfaceTextBox.Validating

    End Sub

End Class