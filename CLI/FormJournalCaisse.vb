Imports Microsoft.Reporting.WinForms
Public Class FormJournalCaisse

    Private Sub FormJournalCaisse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'CLIDataSet.V_journal_caisse'. Vous pouvez la déplacer ou la supprimer selon les besoins.
        ' Me.V_journal_caisseTableAdapter.Fill(Me.CLIDataSet.V_journal_caisse)

        I_debut.Value = Now()
        I_fin.Value = Now


        'droit 1: Admin, 5 : gesitonnaire
        If gProfil = 1 Or gProfil = 5 Then
            I_debut.Enabled = True
            I_fin.Enabled = True
            I_Caisse.SelectedIndex = 0
            I_Comptes5.SelectedIndex = 0
        Else

            I_Caisse.Items.RemoveAt(0)
            I_Comptes5.Items.RemoveAt(0)
            I_Comptes5.Items.RemoveAt(1)
            If gJournalCaisseUn = False Then
                I_Caisse.Items.RemoveAt(I_Caisse.FindStringExact("1"))
            End If
            If gJournalCaisseDeux = False Then
                I_Caisse.Items.RemoveAt(I_Caisse.FindStringExact("2"))
            End If
            Try
                'I_Caisse.SelectedIndex = I_Caisse.FindStringExact(gNumCaisse)
                I_Caisse.SelectedIndex = 0
                I_Comptes5.SelectedIndex = 0
            Catch ex As Exception

            End Try

        End If




    End Sub

    Private Sub BT_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Go.Click
        'TODO: This line of code loads data into the 'CLIDataSet.V_journal_caisse' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'CLIDataSet.V_journal_caisse' table. You can move, or remove it, as needed.
        Cursor = Cursors.WaitCursor

        Dim params(2) As ReportParameter
        params(0) = New ReportParameter("Date_debut", FormatDateTime(I_debut.Value, DateFormat.ShortDate))
        params(1) = New ReportParameter("Date_fin", FormatDateTime(I_fin.Value, DateFormat.ShortDate))
        params(2) = New ReportParameter("Caisse", CStr(IIf(I_Caisse.SelectedIndex = I_Caisse.FindStringExact("<Tout>"), "1,2", I_Caisse.Text)))

        Me.CLIDataSet.V_journal_caisse.Clear()



        'TODO: This line of code loads data into the 'CLIDataSet.V_journal_caisse' table. You can move, or remove it, as needed.
        ' Me.V_journal_caisse_1TableAdapter1.Connection = gCnn
        ' Me.V_journal_caisse_1TableAdapter1.FillByDate(Me.CLIDataSet.V_journal_caisse_1, FormatDateTime(I_debut.Value, DateFormat.ShortDate), FormatDateTime(I_fin.Value, DateFormat.ShortDate))
        'Dim dt As DataTable = ExecuteRequeteR("exec pJournalCaisse '" & IIf(I_Caisse.SelectedIndex = 0, "1,2", I_Caisse.Text) & "','" & FormatDateTime(I_debut.Value, DateFormat.ShortDate) & "','" & FormatDateTime(I_fin.Value, DateFormat.ShortDate) & "'", gCnn.ConnectionString)
        Dim comptes5 As String = ""
        If I_Comptes5.Text = "<Tout>" Then
            comptes5 = "ALL"
        End If
        If I_Comptes5.Text = "Sauf les comptes 5" Then
            comptes5 = "NO5"
        End If
        If I_Comptes5.Text = "Comptes 5 uniquement" Then
            comptes5 = "ONLY5"
        End If


        Dim dt As DataTable = ExecuteRequeteR("exec pJournalCaisse '" & IIf(I_Caisse.Text = "<Tout>", "1,2", I_Caisse.Text) & "','" & FormatDateTime(I_debut.Value, DateFormat.ShortDate) & "','" & FormatDateTime(I_fin.Value, DateFormat.ShortDate) & "','" & comptes5 & "'", gCnn.ConnectionString)

        For Each r As DataRow In dt.Rows
            Me.CLIDataSet.V_journal_caisse.ImportRow(r)
        Next

        '        Me.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Journal_caisse_detail.rdlc"
        Me.ReportViewer1.LocalReport.SetParameters(params)


        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer2.LocalReport.SetParameters(params)


        Me.ReportViewer2.RefreshReport()
        Cursor = Cursors.Default
    End Sub


End Class