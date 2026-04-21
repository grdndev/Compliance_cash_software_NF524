Public Class FormTransporteurs



    Private Sub FormParams_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_Transporteur'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        T_TransporteurTableAdapter.Connection.ConnectionString = My.Settings.CLIConnectionString
        Me.T_TransporteurTableAdapter.Fill(Me.CLIDataSet.T_Transporteur)


    End Sub

    Private Sub T_TransporteurBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_TransporteurBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_TransporteurBindingSource.EndEdit()
        Me.T_TransporteurTableAdapter.Update(Me.CLIDataSet.T_Transporteur)

    End Sub
End Class