Public Class FormUser

    Private Sub T_UserBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_UserBindingNavigatorSaveItem.Click
        Me.Validate()
        Try
            Me.T_UserBindingSource.EndEdit()
            Me.T_UserTableAdapter.Update(Me.CLIDataSet.T_User)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub FormUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Profil'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_ProfilTableAdapter.Fill(Me.CLIDataSet.T_Profil)
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_User'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_UserTableAdapter.Fill(Me.CLIDataSet.T_User)

    End Sub

    Private Sub T_UserDataGridView_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles T_UserDataGridView.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Right And e.RowIndex <> -1 Then
            T_UserBindingSource.Position = e.RowIndex

        End If
    End Sub

    Private Sub T_UserDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles T_UserDataGridView.DataError
        MessageBox.Show(e.Exception.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        e.Cancel = True
    End Sub

    Private Sub ImprimerCodeBarreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerCodeBarreToolStripMenuItem.Click
        Dim DymoAddIn As New Dymo.DymoAddIn
        Dim DymoLabels As New Dymo.DymoLabels

        DymoAddIn.Open(Application.StartupPath & "\11354CodeBarrePersonnel.label")
        DymoLabels.SetField("DESCRIPTION", T_UserBindingSource.Current.item("Nom").ToString & " " & T_UserBindingSource.Current.item("Prenom").ToString)
        DymoLabels.SetField("CODE-BARRES", T_UserBindingSource.Current.item("Codebar").ToString.ToUpper)

        DymoAddIn.SelectPrinter(gNomImprimanteEtiquette)
        DymoAddIn.Print2(1, False, 2)

        
    End Sub

    
End Class