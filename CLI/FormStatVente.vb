Imports Microsoft.Reporting.WinForms
Public Class FormStatVente

    Private Sub FormJournalCaisse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.V_Stats_vente1'. Vous pouvez la déplacer ou la supprimer selon vos besoins.


        I_debut.Value = Now()
        I_fin.Value = Now


        Dim vDatatableRapport As New DataTable

        vDatatableRapport.Columns.Add("value", System.Type.GetType("System.String"), "")
        vDatatableRapport.Columns.Add("text", System.Type.GetType("System.String"), "")
        vDatatableRapport.Rows.Add("CLI.CA_Famille.rdlc", "Familles")
        vDatatableRapport.Rows.Add("CLI.CA_NeufOccas.rdlc", "Neuf / Occas")
        vDatatableRapport.Rows.Add("CLI.CA_NeufOccasFamille.rdlc", "Neuf / Occas par Famille")
        vDatatableRapport.Rows.Add("CLI.CA_FamilleVendeur.rdlc", "Familles par Vendeur")
        vDatatableRapport.Rows.Add("CLI.CA_NeufOccasVendeur.rdlc", "Neuf / Occas par Vendeur")
        vDatatableRapport.Rows.Add("CLI.CA_NeufOccasFamilleVendeur.rdlc", "Neuf / Occas par Famille par Vendeur")


        'remplissage de liste de rapports

        I_rapport.DataSource = vDatatableRapport
        I_rapport.DisplayMember = "text"
        I_rapport.ValueMember = "value"

        I_rapport.SelectedIndex = 0


    End Sub

    Private Sub BT_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Go.Click
        Cursor = Cursors.WaitCursor
        'TODO: This line of code loads data into the 'CLIDataSet.V_journal_caisse' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'CLIDataSet.V_journal_caisse' table. You can move, or remove it, as needed.

        Dim params(1) As ReportParameter
        params(0) = New ReportParameter("Date_debut", FormatDateTime(I_debut.Value, DateFormat.ShortDate))
        params(1) = New ReportParameter("Date_fin", FormatDateTime(I_fin.Value, DateFormat.ShortDate))
        Dim vDatasource As ReportDataSource = Me.ReportViewer1.LocalReport.DataSources(0)


        'TODO: This line of code loads data into the 'CLIDataSet.V_journal_caisse' table. You can move, or remove it, as needed.
        Me.V_Stats_vente1TableAdapter.FillBy(Me.CLIDataSet.V_Stats_vente1, FormatDateTime(I_debut.Value, DateFormat.ShortDate), FormatDateTime(I_fin.Value, DateFormat.ShortDate))
        '        Me.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Journal_caisse_detail.rdlc"
        For Each r As DataRow In Me.CLIDataSet.V_Stats_vente1.Rows
            If r("famille").ToString = "" Then
                r("famille") = "Divers"
            End If

            If r("occaz").ToString = "True" Or r("depot_vente").ToString = "True" Then
                r("occaz") = 1
            Else
                r("occaz") = 0
            End If


        Next
        Me.ReportViewer1.Reset()
        Me.ReportViewer1.LocalReport.DataSources.Add(vDatasource)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = I_rapport.SelectedValue

        Me.ReportViewer1.LocalReport.SetParameters(params)


        Me.ReportViewer1.RefreshReport()

        Cursor = Cursors.Default
    End Sub
End Class