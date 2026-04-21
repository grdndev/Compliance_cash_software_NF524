Imports Microsoft.Reporting.WinForms
Public Class FormStatVente_neufoccasrayonVendeur

    Private Sub FormJournalCaisse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_Stats_vente1'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_Stats_vente1'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_Stats_vente1'. Vous pouvez la déplacer ou la supprimer selon vos besoins.

        'TODO: This line of code loads data into the 'CLIDataSet.V_Stats_vente1' table. You can move, or remove it, as needed.

        I_debut.Value = Now()
        I_fin.Value = Now

    End Sub

    Private Sub BT_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Go.Click
        'TODO: This line of code loads data into the 'CLIDataSet.V_journal_caisse' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'CLIDataSet.V_journal_caisse' table. You can move, or remove it, as needed.

        Dim params(1) As ReportParameter
        params(0) = New ReportParameter("Date_debut", FormatDateTime(I_debut.Value, DateFormat.ShortDate))
        params(1) = New ReportParameter("Date_fin", FormatDateTime(I_fin.Value, DateFormat.ShortDate))


        'TODO: This line of code loads data into the 'CLIDataSet.V_journal_caisse' table. You can move, or remove it, as needed.
        Me.V_Stats_vente1TableAdapter.FillBy(Me.CLIDataSet.V_Stats_vente1, FormatDateTime(I_debut.Value, DateFormat.ShortDate), FormatDateTime(I_fin.Value, DateFormat.ShortDate))
        '        Me.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Journal_caisse_detail.rdlc"
        For Each r As DataRow In Me.CLIDataSet.V_Stats_vente1.Rows
            If r("famille").ToString = "" Then
                r("famille") = "Divers"
            End If
        Next


        Me.ReportViewer1.LocalReport.SetParameters(params)


        Me.ReportViewer1.RefreshReport()
    End Sub
End Class