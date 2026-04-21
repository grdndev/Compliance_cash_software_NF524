Imports Microsoft.Reporting.WinForms
Public Class FormStatVenteNb

    Private Sub FormJournalCaisse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'CLIDataSet.V_Stats_vente_nb_neuf'. Vous pouvez la déplacer ou la supprimer selon les besoins.




        I_debut.Value = Now()
        I_fin.Value = Now

        I_Famille_DropDown()

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



        Me.ReportViewer1.Reset()



        If I_Famille.SelectedIndex > 0 Then
            Me.V_Stats_vente_nb_neufTableAdapter.FillBy1(Me.CLIDataSet.V_Stats_vente_nb_neuf, FormatDateTime(I_debut.Value, DateFormat.ShortDate), FormatDateTime(I_fin.Value, DateFormat.ShortDate), I_Famille.Text)


        Else
            Me.V_Stats_vente_nb_neufTableAdapter.FillBy(Me.CLIDataSet.V_Stats_vente_nb_neuf, FormatDateTime(I_debut.Value, DateFormat.ShortDate), FormatDateTime(I_fin.Value, DateFormat.ShortDate))

        End If

        vDatasource.Value = Me.CLIDataSet.V_Stats_vente_nb_neuf
        Me.ReportViewer1.LocalReport.DataSources.Add(vDatasource)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CLI.Nb_Famille_neuf.rdlc"

        Me.ReportViewer1.LocalReport.SetParameters(params)


        Me.ReportViewer1.RefreshReport()

        Cursor = Cursors.Default
    End Sub

    Sub I_Famille_DropDown()
        I_Famille.DataSource = Nothing


        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim bs As New BindingSource
        Dim command As New SqlClient.SqlCommand
        command.CommandText = "select distinct famille from V_Stats_vente_nb_neuf   Union select '<Tous les rayons>' as famille order by famille"
        command.Connection = cnn
        Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
        bs.DataSource = reader
        I_Famille.DataSource = bs
        I_Famille.DisplayMember = "famille"


        cnn.Close()

    End Sub
End Class