Public Class FormInitialisation

    Private Sub FormInitialisation_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.DoEvents()
        Me.Hide()
        FormIdentification.ShowDialog()
    End Sub





    Private Sub FormInitialisation_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Application.DoEvents()
        LabelAfficheur.Text = "Initialisation Afficheur"
        vAfficheurImprimanteOk = lineDisplayinit()
        Application.DoEvents()
        If vAfficheurImprimanteOk Then
            LabelAfficheur.Text = "Afficheur Ok"
        Else
            LabelAfficheur.Text = "Pb Afficheur"
            BT_Ignorer.Visible = True
        End If
        Application.DoEvents()
        ProgressBar1.PerformStep()
        LabelImprimanteTicketCaisse.Text = "Initialisation Imprimante à ticket de caisse"
        Application.DoEvents()
        vPosPrinterOk = PosPrinterInit()
        Application.DoEvents()
        If vPosPrinterOk Then
            LabelImprimanteTicketCaisse.Text = "Imprimante à ticket de caisse Ok"
        Else
            LabelImprimanteTicketCaisse.Text = "Pb Imprimante à ticket de caisse"
            BT_Ignorer.Visible = True
        End If
        Application.DoEvents()
        ProgressBar1.PerformStep()
        Application.DoEvents()
        LabelTiroirCaisse.Text = "Initialisation Tiroir caisse"
        Application.DoEvents()
        vCashDrawerOk = CashDrawerInit()
        Application.DoEvents()
        If vCashDrawerOk Then
            LabelTiroirCaisse.Text = "Tiroir caisse Ok"
        Else
            LabelTiroirCaisse.Text = "Pb Tiroir caisse"
            BT_Ignorer.Visible = True
        End If
        Application.DoEvents()
        ProgressBar1.PerformStep()
        BT_Ignorer.Enabled = True
        If Not BT_Ignorer.Visible Then

            Me.Close()

        End If
    End Sub


    Private Sub BT_Ignorer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Ignorer.Click
        Me.Close()

    End Sub

    Private Sub FormInitialisation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class