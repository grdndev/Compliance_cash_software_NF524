Imports System.Windows.Input
Imports Newtonsoft.Json

Public Class FormLog

    Public vLogAssociatedRecordId As Long = 0
    Public vLogAssociatedRecordType As String = ""
    Private Sub FormErrorLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataRefresh()
    End Sub

    Private Sub DataRefresh()
        If vLogAssociatedRecordId <> 0 And vLogAssociatedRecordType <> "" Then
            DataGridView1.DataSource = ExecuteRequeteR("select Top(100) Id, LogDateTime, LogEntry, LogDetail,LogType,LogAssociatedRecordId,LogAssociatedRecordType,errors,LogVersionApi from V_log where LogAssociatedRecordId = " & vLogAssociatedRecordId & " and LogAssociatedRecordType = '" & vLogAssociatedRecordType & "' order by Logdatetime desc", gCnn.ConnectionString)
        Else
            DataGridView1.DataSource = ExecuteRequeteR("select Top(100) Id, LogDateTime, LogEntry, LogDetail,LogType,LogAssociatedRecordId,LogAssociatedRecordType,errors,LogVersionApi from V_log order by Logdatetime desc", gCnn.ConnectionString)

        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        'affiche le contenu de la cellule dans un formulaire avec un champ multiligne avec un scrollbar
        Dim vForm As New Form
        vForm.Size = New Size(800, 600)
        vForm.Text = "Log Detail"
        Dim vTextBox As New TextBox
        vTextBox.Multiline = True
        vTextBox.ScrollBars = ScrollBars.Vertical
        vTextBox.Dock = DockStyle.Fill
        vTextBox.Text = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        vForm.Controls.Add(vTextBox)
        vForm.ShowDialog()



    End Sub

    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DataGridView1.KeyDown

        If e.KeyData = Keys.F5 Then
            DataRefresh()
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ExporterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExporterToolStripMenuItem.Click
        'exporte le contenu de la table log dans un fichier json
        Dim vSaveFileDialog As New SaveFileDialog
        Dim dtExport As DataTable = ExecuteRequeteR("select * from t_log order by Logdatetime desc", gCnn.ConnectionString)
        vSaveFileDialog.Filter = "Json files (*.json)|*.json"

        If vSaveFileDialog.ShowDialog() = DialogResult.OK Then
            ExportDataTableToJSON(dtExport, vSaveFileDialog.FileName)
        End If


    End Sub

    Private Sub ExportDataTableToJSON(dtExport As DataTable, fileName As String)
        Dim vJson As String = ""
        vJson = JsonConvert.SerializeObject(dtExport, Formatting.Indented)
        Dim vStreamWriter As New StreamWriter(fileName)
        vStreamWriter.Write(vJson)
        vStreamWriter.Close()

    End Sub

    Private Sub ImporterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImporterToolStripMenuItem.Click
        'importe le contenu d'un fichier json dans la table log

        Dim vOpenFileDialog As New OpenFileDialog
        Dim vJson As String = ""
        vOpenFileDialog.Filter = "Json files (*.json)|*.json"
        If vOpenFileDialog.ShowDialog() = DialogResult.OK Then
            Dim vStreamReader As New StreamReader(vOpenFileDialog.FileName)
            vJson = vStreamReader.ReadToEnd
            vStreamReader.Close()
            Dim dtImport As DataTable = JsonConvert.DeserializeObject(Of DataTable)(vJson)
            ExecuteRequeteR("delete from t_log", gCnn.ConnectionString)
            For Each vRow As DataRow In dtImport.Rows
                'on remplace ' par '' pour eviter les erreurs de syntaxe
                ExecuteRequeteR("insert into t_log (LogDateTime, LogEntry, LogDetail,LogType,LogAssociatedRecordId,LogAssociatedRecordType) values ('" & vRow("LogDateTime").ToString.Replace("'", "''") & "','" & vRow("LogEntry").ToString.Replace("'", "''") & "','" & vRow("LogDetail").ToString.Replace("'", "''") & "','" & vRow("LogType").ToString.Replace("'", "''") & "'," & vRow("LogAssociatedRecordId") & ",'" & vRow("LogAssociatedRecordType").ToString.Replace("'", "''") & "')", gCnn.ConnectionString)
            Next
            DataRefresh()
        End If
    End Sub
End Class