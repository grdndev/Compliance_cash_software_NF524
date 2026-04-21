Imports System.Windows.Forms

Public Class DialogImpression
    Public pDgview As DataGridView
    Public pDepot As Boolean = False
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DialogImpression_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        For Each c As DataGridViewColumn In pDgview.Columns
            If c.Visible Then
                If pDepot Then
                    If c.HeaderText = "Ref" Or c.HeaderText = "Description courte" Or c.HeaderText = "PV Remisé TTC" Or c.HeaderText = "Stock" Then
                        DataGridViewColonnes.Rows.Add(c.HeaderText, True, c.Name)
                    Else
                        DataGridViewColonnes.Rows.Add(c.HeaderText, False, c.Name)
                    End If
                Else
                        DataGridViewColonnes.Rows.Add(c.HeaderText, True, c.Name)
                End If

            End If
        Next
        'For Each r As DataGridViewRow In pDgview.Rows

        '    r.Visible = r.Cells("Active_on").Value

        'Next


        ComboBoxOrientation.SelectedIndex = 0
    End Sub
End Class
