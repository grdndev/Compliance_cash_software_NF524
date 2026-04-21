Public Class FormGuideTaille



    Private Sub FormComptes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_GuideTaille'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        Dim dt As DataTable = ExecuteRequeteR("select ID_T_SousFamille,T_Famille.Libelle + ' ' + T_SousFamille.Libelle as libelle from T_Famille, t_sousfamille where T_Famille.ID_T_Famille=t_sousfamille.ID_T_Famille order by T_Famille.Libelle,T_sousFamille.Libelle", My.Settings.CLIConnectionString)

        I_combo.DataSource = dt
        I_combo.ValueMember = "ID_T_SousFamille"
        I_combo.DisplayMember = "libelle"

        Me.T_GuideTailleTableAdapter.Fill(Me.CLIDataSet.T_GuideTaille)




     

    End Sub

    Private Sub T_GuideTailleBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_GuideTailleBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_GuideTailleBindingSource.EndEdit()
        Me.T_GuideTailleTableAdapter.Update(Me.CLIDataSet.T_GuideTaille)

    End Sub

    Private Sub T_GuideTailleDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T_GuideTailleDataGridView.CellContentClick

    End Sub
End Class