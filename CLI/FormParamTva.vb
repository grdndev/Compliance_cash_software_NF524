Public Class FormParamTva

    Private Sub T_code_tvaBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_code_tvaBindingNavigatorSaveItem_Click.Click
        Me.Validate()
        Me.T_code_tvaBindingSource.EndEdit()

        ' ✅ NF525 : Logger toutes les modifications de taux TVA AVANT la sauvegarde
        ' Obligatoire NF525 : toute modification de taux doit être tracée dans le JET avec ancien/nouveau
        Try
            Dim dt As Data.DataTable = Me.CLIDataSet.T_code_tva
            For Each row As Data.DataRow In dt.Rows
                If row.RowState = Data.DataRowState.Modified Then
                    Dim codeTVA As String = row("code_tva", Data.DataRowVersion.Current).ToString()
                    Dim ancienTaux As Decimal = 0D
                    Dim nouveauTaux As Decimal = 0D
                    Try
                        ancienTaux = Convert.ToDecimal(row("taux", Data.DataRowVersion.Original))
                        nouveauTaux = Convert.ToDecimal(row("taux", Data.DataRowVersion.Current))
                    Catch
                    End Try
                    If ancienTaux <> nouveauTaux Then
                        LogModificationTVA(codeTVA, ancienTaux, nouveauTaux)
                    End If
                ElseIf row.RowState = Data.DataRowState.Added Then
                    Dim codeTVA As String = row("code_tva").ToString()
                    Dim taux As Decimal = 0D
                    Try : taux = Convert.ToDecimal(row("taux")) : Catch : End Try
                    LogCreationTVA(codeTVA, taux)
                End If
            Next
        Catch exLog As Exception
            ' Ne jamais bloquer la sauvegarde si le log échoue
            Debug.WriteLine("NF525 - Erreur log TVA : " & exLog.Message)
        End Try

        Me.T_code_tvaTableAdapter.Update(Me.CLIDataSet.T_code_tva)

    End Sub

    Private Sub FormParamTva_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.T_code_tvaTableAdapter.Fill(Me.CLIDataSet.T_code_tva)

    End Sub
End Class
