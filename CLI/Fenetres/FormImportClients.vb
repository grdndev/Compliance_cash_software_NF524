Imports Newtonsoft.Json

Public Class FormImportClients
    Private Sub BT_Importer_Click(sender As Object, e As EventArgs) Handles BT_Importer.Click
        Dim toCliDto As New ToCliDto
        toCliDto.AssociatedAddress = CheckBoxAdresses.Checked
        toCliDto.AssociatedCartRule = CheckBoxAvoirs.Checked
        toCliDto.OnlyErrors = I_OnlyErrors.Checked
        'mets seulement la date dans le dto si la checkbox est cochee et stock la date dans le date sans les heures minutes et secondes
        toCliDto.UpdatedDateFrom = IIf(I_DateModif.Checked, DateTimePickerUpdatedDateFrom.Value.Date, Nothing)

        CliApi.CustomerImportFromCLIAsync(toCliDto)
        MessageBox.Show("Import en cours", "Demande d'import", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BT_ExportRef_Click(sender As Object, e As EventArgs) Handles BT_ExportRef.Click
        'export la table t_client, colonne id_t_client et idCustomerPrestashop dans un fichier json
        Dim vSaveFileDialog As New SaveFileDialog
        Dim dtExport As DataTable = ExecuteRequeteR("select id_t_client,idCustomerPrestashop from t_client", gCnn.ConnectionString)
        vSaveFileDialog.Filter = "Json files (*.json)|*.json"

        If vSaveFileDialog.ShowDialog() = DialogResult.OK Then
            ExportDataTableToJSON(dtExport, vSaveFileDialog.FileName)
        End If
    End Sub


    Private Sub BT_ImportRef_Click(sender As Object, e As EventArgs) Handles BT_ImportRef.Click
        'met à jour la table t_client , colonne refClientPrestashop depuis un fichier json
        Dim vOpenFileDialog As New OpenFileDialog
        Dim vJson As String = ""
        vOpenFileDialog.Filter = "Json files (*.json)|*.json"
        If vOpenFileDialog.ShowDialog() = DialogResult.OK Then
            Dim vStreamReader As New StreamReader(vOpenFileDialog.FileName)
            vJson = vStreamReader.ReadToEnd
            vStreamReader.Close()
            Dim dtImport As DataTable = JsonConvert.DeserializeObject(Of DataTable)(vJson)
            For Each vRow As DataRow In dtImport.Rows
                If vRow("idCustomerPrestashop") Is DBNull.Value Or vRow("idCustomerPrestashop").ToString = "" Then
                Else
                    ExecuteRequeteR("update t_client set idCustomerPrestashop='" & vRow("idCustomerPrestashop").ToString.Replace("'", "''") & "'  where id_t_client=" & vRow("id_t_client"), gCnn.ConnectionString)

                End If
                'on remplace ' par '' pour eviter les erreurs de syntaxe
            Next
        End If

    End Sub
    Private Sub ExportDataTableToJSON(dtExport As DataTable, fileName As String)
        Dim vJson As String = ""
        vJson = JsonConvert.SerializeObject(dtExport, Formatting.Indented)
        Dim vStreamWriter As New StreamWriter(fileName)
        vStreamWriter.Write(vJson)
        vStreamWriter.Close()

    End Sub
End Class