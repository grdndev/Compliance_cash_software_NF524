Imports System.ComponentModel
Imports CompletIT.Windows.Forms.Export.Pdf
Public Class FormEcheanceRecherche
    Public bs As New BindingSource
    Public vref As String = ""



    Private Sub FormEcheanceRecherche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'CLIDataSet.V_Recherche_Echeance'. Vous pouvez la déplacer ou la supprimer selon les besoins.
        Me.V_Recherche_EcheanceTableAdapter.Fill(Me.CLIDataSet.V_Recherche_Echeance)
        'TODO: cette ligne de code charge les données dans la table 'CLIDataSet.V_Recherche_Echeance'. Vous pouvez la déplacer ou la supprimer selon les besoins.



        Raz()


        ToolStripStatusLabelNbEnregistrements.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", "0")

    End Sub






    Private Sub V_Recherche_ArticleDataGridView_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGview.CellMouseDoubleClick
        'If Not e.RowIndex = -1 And e.Button = Windows.Forms.MouseButtons.Left Then
        '    If Me.Modal Then
        '        vref = DGview.Rows(e.RowIndex).Cells("Ref").Value.ToString
        '        Me.DialogResult = Windows.Forms.DialogResult.OK
        '        Me.Close()
        '    Else
        '        Dim index As Integer = e.RowIndex
        '        OuvertureFiche(index)
        '    End If

        'End If

    End Sub

    Private Sub BT_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Go.Click

        If Me.Modal Then
            Recherche(False, False)
        Else
            Recherche(False, True)
        End If


    End Sub

    Private Sub I_MoyenPaiement_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles I_MoyenPaiement.DropDown
        I_MoyenPaiement.DataSource = Nothing
        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()
        Dim bs As New BindingSource
        Dim command As New SqlClient.SqlCommand
        command.CommandText = " SELECT distinct [Moyen paiement] as mdp FROM [V_Recherche_Echeance]"
        command.Connection = cnn
        Dim reader As SqlClient.SqlDataReader = command.ExecuteReader
        bs.DataSource = reader
        I_MoyenPaiement.DataSource = bs
        I_MoyenPaiement.DisplayMember = "mdp"
        cnn.Close()
    End Sub

    Private Sub BT_RAZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_RAZ.Click
        Raz()

    End Sub
    Public Sub Recherche(Optional ByVal bNouveau As Boolean = False, Optional ByVal bAutoOpen As Boolean = True, Optional ByVal id_t_article_entete As String = "", Optional ByVal id_t_article_detail As String = "", Optional ByVal bOngletArticle As Boolean = False)
        Cursor = Cursors.WaitCursor
        Dim cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
        cnn.Open()



        Dim strsql_recherche As String

        strsql_recherche = "select * from v_recherche_echeance where 1=1"


        Dim strsql As String = ""



        If IsNumeric(I_RefClient.Text) Then
            strsql = strsql & " and [Ref Client] =" & I_RefClient.Text
        Else
            I_RefClient.Text = ""
        End If

        If IsNumeric(I_RefCommande.Text) Then
            strsql = strsql & " and [Ref Commande] =" & I_RefCommande.Text
        Else
            I_RefCommande.Text = ""
        End If

        If IsNumeric(I_EchanceMin.Text) Then
            strsql = strsql & " and [Montant] >=" & I_EchanceMin.Text
        Else
            I_EchanceMin.Text = ""
        End If
        If IsNumeric(I_EcheanceMax.Text) Then
            strsql = strsql & " and [Montant]  <=" & I_EcheanceMax.Text
        Else
            I_EcheanceMax.Text = ""
        End If

        If I_DateCommande_debut.Checked Then
            strsql = strsql & " and [Date Commande]  >='" & FormatDateTime(I_DateCommande_debut.Value, DateFormat.ShortDate) & "'"
        End If

        If I_DateCommande_fin.Checked Then
            strsql = strsql & " and [Date Commande]  <='" & FormatDateTime(I_DateCommande_fin.Value, DateFormat.ShortDate) & "'"
        End If

        If I_echeance_debut.Checked Then
            strsql = strsql & " and [Echéance]  >='" & FormatDateTime(I_echeance_debut.Value, DateFormat.ShortDate) & "'"
        End If

        If I_echeance_fin.Checked Then
            strsql = strsql & " and [Echéance]  <='" & FormatDateTime(I_echeance_fin.Value, DateFormat.ShortDate) & "'"
        End If

        If Not String.IsNullOrEmpty(Trim(I_Societe.Text)) Then
            strsql = strsql & " and [Société] like '%" & I_Societe.Text & "%'"
        End If


        If Not String.IsNullOrEmpty(Trim(I_Nom.Text)) Then
            strsql = strsql & " and [Nom] like '%" & I_Nom.Text & "%'"
        End If

        If Not String.IsNullOrEmpty(Trim(I_Prenom.Text)) Then
            strsql = strsql & " and [Prénom] like '%" & I_Prenom.Text & "%'"
        End If

        If Not String.IsNullOrEmpty(Trim(I_MoyenPaiement.Text)) Then
            strsql = strsql & " and [Moyen Paiement] like '" & I_MoyenPaiement.Text & "'"
        End If






fin:

        Dim oSqlDataAdapter As New Data.SqlClient.SqlDataAdapter(strsql_recherche & strsql, cnn)
        Dim oDataSet As New DataSet("RechercheDataset")

        oSqlDataAdapter.Fill(oDataSet, "Recherche")
        ToolStripStatusLabelNbEnregistrements.Text = System.String.Format("{0} enregistrement(s) sélectionné(s)", oDataSet.Tables("Recherche").Rows.Count.ToString)

        bs.DataSource = oDataSet.Tables("Recherche")


        I_TotalEcheances.Text = 0
        For Each r As DataRow In oDataSet.Tables("Recherche").Rows
            If IsNumeric(r("Montant").ToString) Then
                I_TotalEcheances.Text = I_TotalEcheances.Text + r("Montant")
            End If

        Next

        I_TotalEcheances.Text = Format(I_TotalEcheances.Text, "Currency")

        DGview.DataSource = bs

        cnn.Close()


        Cursor = Cursors.Default
    End Sub
    Private Sub Raz()
        DGview.DataSource = Nothing

        I_DateCommande_debut.Checked = False
        I_DateCommande_fin.Checked = False

        I_echeance_debut.Checked = False
        I_echeance_fin.Checked = False

        I_RefCommande.Text = ""

        I_EchanceMin.Text = ""
        I_EcheanceMax.Text = ""

        I_RefClient.Text = ""
        I_Societe.Text = ""
        I_Nom.Text = ""
        I_Prenom.Text = ""
        I_MoyenPaiement.Text = ""




    End Sub

    Private Sub DGview_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGview.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right And e.RowIndex <> -1 Then
            bs.Position = e.RowIndex

        End If
    End Sub

    Private Sub BT_Nouvel_Article_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Nouvelle_Fiche()
    End Sub
    Public Sub Nouvelle_Fiche()

        Recherche(True, False)

    End Sub
    Private Sub I_Reference_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.text = ""
    End Sub

    Private Sub BT_Fermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Fermer.Click
        Me.Close()
    End Sub

    Private Sub SuppressionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub BT_Impression_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Impression.Click, BT_Email.Click

        Dim critere As String = ""
        Dim settings As New CompletIT.Windows.Forms.Printing.DGVEPrintSettings


        Dim PdfExporter As DGVEPdfExporter = New DGVEPdfExporter()
        Dim ExportSettings As DGVEPdfExportSettings = New DGVEPdfExportSettings()

        settings.PrintHeaderText = True

        If IsNumeric(I_RefClient.Text) Then
            critere = critere & vbCrLf & "Ref Client : " & I_RefClient.Text
        End If

        If IsNumeric(I_RefCommande.Text) Then
            critere = critere & vbCrLf & "Ref Commande : " & I_RefCommande.Text
        End If

        If I_DateCommande_debut.Checked Then
            critere = critere & vbCrLf & "Date Commande du " & FormatDateTime(I_DateCommande_debut.Value, DateFormat.ShortDate)
        End If

        If I_DateCommande_fin.Checked Then
            critere = critere & vbCrLf & "Date Commande au " & FormatDateTime(I_DateCommande_fin.Value, DateFormat.ShortDate)
        End If

        If I_echeance_debut.Checked Then
            critere = critere & vbCrLf & "Date Echéance du " & FormatDateTime(I_echeance_debut.Value, DateFormat.ShortDate)
        End If

        If I_echeance_fin.Checked Then
            critere = critere & vbCrLf & "Date Echéance au " & FormatDateTime(I_echeance_fin.Value, DateFormat.ShortDate)
        End If




        If I_EchanceMin.Text <> "" Then
            critere = critere & vbCrLf & "Montant échéances min : " & I_EchanceMin.Text
        End If

        If I_EcheanceMax.Text <> "" Then
            critere = critere & vbCrLf & "Montant échéances max : " & I_EcheanceMax.Text
        End If

        If I_Societe.Text <> "" Then
            critere = critere & vbCrLf & "Société : " & I_Societe.Text
        End If
        If I_Nom.Text <> "" Then
            critere = critere & vbCrLf & "Nom : " & I_Nom.Text
        End If
        If I_Prenom.Text <> "" Then
            critere = critere & vbCrLf & "Prénom : " & I_Prenom.Text
        End If

        If I_MoyenPaiement.Text <> "" Then
            critere = critere & vbCrLf & "Moyen de paiement : " & I_MoyenPaiement.Text
        End If


        critere = critere & vbCrLf & "Total écheances : " & I_TotalEcheances.Text


        Dim f As New DialogImpression
        f.pDgview = DGview

        If f.ShowDialog = Windows.Forms.DialogResult.OK Then
            settings.HeaderText = "CLI : Listing des clients" & critere & vbCrLf & vbCrLf & "Impression le " & Now()
            settings.PrintRowHeaders = False
            ExportSettings.HeaderText = "CLI : Listing des clients" & critere & vbCrLf & vbCrLf & "Impression le " & Now()
            ExportSettings.ExportRowHeaders = False

            f.ComboBoxOrientation.SelectedIndex = 1

            If f.ComboBoxOrientation.SelectedIndex = 1 Then
                settings.Landscape = True
                ExportSettings.Landscape = True
            Else
                settings.Landscape = False
                ExportSettings.Landscape = False
            End If





            For Each r As DataGridViewRow In f.DataGridViewColonnes.Rows
                If Not r.Cells(1).Value Then
                    DGview.Columns(r.Cells(2).Value).visible = False

                End If
            Next
            settings.MarginLeft = 50
            settings.MarginRight = 50
            settings.PrintVisualStyles = False
            ExportSettings.MarginLeft = 50
            ExportSettings.MarginRight = 50

            ExportSettings.MarginLeft = 50
            ExportSettings.MarginRight = 50
            ExportSettings.ExportHeaderText = True

            ExportSettings.ExportFileName = gChemin_local_piece_jointe 'Absolute path to the export file
            ExportSettings.OpenFileAfterGeneration = False 'Open generated file after export
            ExportSettings.OpenFolderAfterGeneration = False
            ExportSettings.ExportHiddenColumns = False

            Select Case sender.name
                Case "BT_Impression"
                    CompletIT.Windows.Forms.Printing.DGVEPrintManager.PrintPreview(DGview, settings)
                Case "BT_Email"
                    PdfExporter.Export(DGview, ExportSettings)
                    Dim fmail As New FormMail
                    fmail.Text = "Envoi d'email"
                    fmail.I_From.Text = gEmailFacture
                    fmail.I_smtp.Text = gSmtp
                    fmail.I_subject.Text = "Listing  www.chinook-leucate.com"
                    fmail.I_message.Text = "Madame, Monsieur," & vbCrLf & "Veuillez-trouver ci-joint le listing en pièce jointe" & vbCrLf & "Cordialement," & vbCrLf & "L'équipe www.chinook-leucate.com"

                    If fmail.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        MessageBox.Show("Message envoyé", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Message annulé", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
            End Select




            For Each r As DataGridViewRow In f.DataGridViewColonnes.Rows
                If Not r.Cells(1).Value Then
                    DGview.Columns(r.Cells(2).Value).visible = True

                End If
            Next
        End If
    End Sub

End Class