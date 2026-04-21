Imports RestSharp

Public Class FormImportArticleParSousFamilleAncienSite
    Private Sub I_Famille_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_Famille.DropDown
        I_Famille.DataSource = Nothing
        I_SousFamille.DataSource = Nothing

        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim bs As New BindingSource
        Dim command As New SqlClient.SqlCommand
        command.CommandText = "select id_t_famille,libelle from t_Famille  Union select null as id_t_famille,null as libelle order by libelle"
        command.Connection = cnn
        Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
        bs.DataSource = reader
        I_Famille.DataSource = bs
        I_Famille.DisplayMember = "libelle"
        I_Famille.ValueMember = "id_t_famille"

        cnn.Close()

    End Sub
    Private Sub I_SousFamille_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_SousFamille.DropDown
        If I_Famille.Text <> "" Then
            I_SousFamille.DataSource = Nothing
            Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
            cnn.Open()
            Dim bs As New BindingSource
            Dim command As New SqlClient.SqlCommand

            command.CommandText = "select id_t_sousfamille,libelle from t_SousFamille where id_t_famille=" & Replace(I_Famille.SelectedValue, "'", "''") & " Union select null as id_t_sousfamille,null as libelle order by libelle"



            command.Connection = cnn
            Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
            bs.DataSource = reader

            I_SousFamille.DataSource = bs
            I_SousFamille.DisplayMember = "libelle"
            I_SousFamille.ValueMember = "id_t_sousfamille"
            cnn.Close()
        End If
    End Sub

    Private Sub BT_Import_Click(sender As Object, e As EventArgs) Handles BT_Import.Click
        'si une valeur est bien selectionnee pour I_SousFamille alors on appelle  CliApi.ApiCallBuffer
        'If I_SousFamille.Text <> "" Then
        Dim toCliDto As New ToCliDto
        If I_SousFamille.SelectedIndex > 0 Then
            toCliDto.Id = I_SousFamille.SelectedValue
        End If
        If I_Famille.SelectedIndex > 0 Then
            toCliDto.Id_T_Famille = I_Famille.SelectedValue
        End If
        toCliDto.ImportStock = I_ImportStock.Checked
        toCliDto.AssociatedLegacyImages = I_LegacyImage.Checked
        toCliDto.OnlyErrors = I_OnlyErrors.Checked
        toCliDto.OnlyNewSync = I_OnlyNewSync.Checked
        toCliDto.DeleteBeforeImport = I_DeleteBeforeImport.Checked

        'mets seulement la date dans le dto si la checkbox est cochee et stock la date dans le date sans les heures minutes et secondes
        toCliDto.UpdatedDateFrom = IIf(I_DateModif.Checked, DateTimePickerUpdatedDateFrom.Value.Date, Nothing)
            CliApi.ApiCallBuffer("product/ImportFromLegacySubFamilyFromCLIByIdAsync", Method.POST, toCliDto, Nothing)
            MessageBox.Show("Import en cours", "Demande d'import", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    MessageBox.Show("Veuillez selectionner une sous famille", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
    End Sub

    Private Sub I_DateModif_CheckedChanged(sender As Object, e As EventArgs) Handles I_DateModif.CheckedChanged
        DateTimePickerUpdatedDateFrom.Visible = I_DateModif.Checked
    End Sub
End Class