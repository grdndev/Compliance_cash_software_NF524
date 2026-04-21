
Namespace CLI
    Partial Class FormCloture
        Inherits System.Windows.Forms.Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub FormCloture_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RefreshData()
        End Sub

        Private Sub RefreshData()
            Try
                lblLastCloture.Text = "Dernière clôture : " & GetLastClotureId()
                lblGrandTotal.Text = "Grand Total : " & GetGrandTotalActuel().ToString("N2") & " €"
                
                ' Calculer le CA non clôturé pour aujourd'hui
                Dim caJour As Decimal = GetCAJour()
                lblCAJour.Text = "CA de la journée : " & caJour.ToString("N2") & " €"
                
                If caJour = 0 Then
                    btnCloturer.Enabled = False
                    lblInfo.Text = "Aucune vente à clôturer pour aujourd'hui."
                Else
                    btnCloturer.Enabled = True
                    lblInfo.Text = "Prêt pour la clôture journalière."
                End If
            Catch ex As Exception
                MessageBox.Show("Erreur chargement : " & ex.Message)
            End Try
        End Sub

        Private Function GetCAJour() As Decimal
            Dim sql As String = "SELECT ISNULL(SUM(Total_TTC), 0) FROM T_CommandeVente " &
                              "WHERE CAST(TicketLe AS DATE) = CAST(GETDATE() AS DATE) AND ID_EtatCommandeVente >= 20"
            Using cnn As New SqlClient.SqlConnection(My.Settings.CLIConnectionString)
                cnn.Open()
                Using cmd As New SqlClient.SqlCommand(sql, cnn)
                    Return Convert.ToDecimal(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

        Private Sub btnCloturer_Click(sender As Object, e As EventArgs) Handles btnCloturer.Click
            If MessageBox.Show("Voulez-vous vraiment effectuer la clôture journalière (Z) ?" & vbCrLf &
                               "Cette opération est irréversible.", "NF525 - Clôture",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Try
                    Dim idZ As Long = ClotureJournaliere()
                    MessageBox.Show("Clôture Z n°" & idZ & " effectuée avec succès !", "NF525", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' ✅ NF525 — Impression obligatoire du Ticket Z après chaque clôture journalière
                    ' False = aperçu écran (l'opérateur confirme l'impression)
                    ' Passer True pour impression directe sans aperçu
                    Try
                        ImprimerTicketZ(idZ, imprimerDirectement:=False)
                    Catch exPrint As Exception
                        ' L'impression ne doit pas bloquer la clôture déjà effectuée
                        MessageBox.Show("Clôture enregistrée, mais erreur d'impression Ticket Z :" & vbCrLf &
                                        exPrint.Message & vbCrLf & vbCrLf &
                                        "Vous pouvez réimprimer depuis Administration → Clôtures → Réimprimer.",
                                        "NF525 - Impression Ticket Z", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try

                    Me.Close()
                Catch ex As Exception
                    MessageBox.Show("Erreur lors de la clôture : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub

        Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
            Me.Close()
        End Sub
    End Class
End Namespace
