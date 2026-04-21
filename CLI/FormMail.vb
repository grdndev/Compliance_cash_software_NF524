Imports System.Windows.Forms
Imports System.Net.Mail

Public Class FormMail
    Public vNumFacture As String
    Public vEmailClient As String
    Public vPiecejointe As Boolean = True
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If I_To.Text <> "" And I_From.Text <> "" And I_subject.Text <> "" And I_message.Text <> "" Then
            Dim mail As New System.Net.Mail.MailMessage

            mail.From = New MailAddress(I_From.Text)
            mail.To.Add(New MailAddress(I_To.Text))
            mail.Bcc.Add(New MailAddress(I_From.Text))
            mail.Subject = I_subject.Text
            ' mail.Body = I_message.Text

            Dim plainview As AlternateView = AlternateView.CreateAlternateViewFromString(I_message.Text, Nothing, "text/plain")
            '           Dim htmlview As AlternateView = AlternateView.CreateAlternateViewFromString(I_message.Text.Replace(vbCrLf, "<br>") & "<br><img src=""cid:companylogo"" /></br>" & gSignature_html, Nothing, "text/html")
            Dim htmlview As AlternateView = AlternateView.CreateAlternateViewFromString(I_message.Text.Replace(vbCrLf, "<br>") & "<br>" & gSignature_html, Nothing, "text/html")

            Dim client As New SmtpClient

            client.Host = I_smtp.Text
            client.Credentials = New System.Net.NetworkCredential(gSmtpLogin, gSmtpPassword)
            client.Port = gSmtpPort


            If vPiecejointe Then

                Dim maPieceJointe As New Attachment(gChemin_local_piece_jointe)

                mail.Attachments.Add(maPieceJointe)
            End If


            'Dim logo As New LinkedResource(Application.StartupPath & "\logoChinook.png")
            'logo.ContentId = "companylogo"

            'htmlview.LinkedResources.Add(logo)

            mail.AlternateViews.Add(plainview)
                mail.AlternateViews.Add(htmlview)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Try
                    client.Send(mail)
                Catch ex As Exception

                End Try

                Try

                Catch ex As Exception
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Finally
                    Me.Close()
                End Try
            Else
                MessageBox.Show("Merci de saisir tous les champs", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If



    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FormMailFacture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        I_To.Text = vEmailClient
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start(gChemin_local_piece_jointe)
    End Sub

    Private Sub RechercherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechercherToolStripMenuItem.Click
        Dim f As New FormClientRecherche
        Dim vref As Integer = 0

        f.ShowDialog()
        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            vref = f.vref

            I_To.Focus()
            I_To.Text = ExecuteRequeteR("select email from t_client where id_t_client=" & vref, My.Settings.CLIConnectionString).Rows(0)("email").ToString
            I_To.Focus()
        End If

    End Sub


    Private Sub RechercherFournisseurToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechercherFournisseurToolStripMenuItem.Click
        Dim f As New FormFournisseurRecherche
        Dim vref As Integer = 0

        f.ShowDialog()
        If f.DialogResult = Windows.Forms.DialogResult.OK Then
            vref = f.vref

            I_To.Focus()
            I_To.Text = ExecuteRequeteR("select email from t_fournisseur where id_t_fournisseur=" & vref, My.Settings.CLIConnectionString).Rows(0)("email").ToString
            I_To.Focus()
        End If
    End Sub
End Class
