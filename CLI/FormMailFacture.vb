Imports System.Windows.Forms
Imports System.Net.Mail

Public Class FormMailFacture
    Public vNumFacture As String
    Public vEmailClient As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If I_To.Text <> "" And I_From.Text <> "" And I_subject.Text <> "" And I_message.Text <> "" Then
            Dim mail As New System.Net.Mail.MailMessage

            mail.IsBodyHtml = True
            mail.From = New MailAddress(I_From.Text)
            mail.To.Add(New MailAddress(I_To.Text))
            mail.Bcc.Add(New MailAddress(I_From.Text))
            mail.Subject = I_subject.Text
            mail.Body = I_message.Text.Replace(vbCrLf, "<br>")

            mail.Body = "<img src=""http://www.chinook-leucate.com/Images/footer/logo-footer.png""><br><br><br><br>" & mail.Body
            mail.Body = mail.Body & "<br><br><br><table style=""width:100%;""><tbody><tr> <td style=""vertical-align:bottom;text-align:left;""><a href=""https://www.facebook.com/pages/Chinook-Leucate/105406059536242"" target=""_blank""><img alt=""""  src=""http://www.chinook-leucate.com/Images/footer/FB.png"" style=""border: none""></a></td><td style=""vertical-align: bottom;""><a href=""https://chinookleucate.wordpress.com/"" target=""_blank""><img alt=""""  src=""http://www.chinook-leucate.com/Images/footer/WP.png"" style=""border:none""></a></td><td style=""vertical-align: bottom;text-align:Right();""><a href=""https://www.youtube.com/user/chinookleucate"" target=""_blank""><img alt=""""  src=""http://www.chinook-leucate.com/Images/footer/YT.png"" style=""border:none""></a></td></tr> </tbody></table>"



            Dim client As New SmtpClient

            client.Host = I_smtp.Text
            client.Credentials = New System.Net.NetworkCredential(gSmtpLogin, gSmtpPassword)
            client.Port = gSmtpPort




            Dim maPieceJointe As New Attachment(gChemin_local_facture)

            mail.Attachments.Add(maPieceJointe)
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
        I_subject.Text = "Votre facture www.chinook-leucate.com n°" & vNumFacture
        I_message.Text = "Madame, Monsieur," & vbCrLf & "Veuillez-trouver ci-jointe votre facture n°" & vNumFacture & vbCrLf & "Cordialement," & vbCrLf & "L'équipe www.chinook-leucate.com"
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start(gChemin_local_facture)
    End Sub
End Class
