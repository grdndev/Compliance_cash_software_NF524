Public Class FormParamsCodesPortPays

    Private Sub T_liste_code_port_paysBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T_liste_code_port_paysBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.T_liste_code_port_paysBindingSource.EndEdit()
        Me.T_liste_code_port_paysTableAdapter.Update(Me.CLIDataSet.T_liste_code_port_pays)

    End Sub

    Private Sub FormParamsCodesPortPays_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO : cette ligne de code charge les données dans la table 'CLIDataSet.T_liste_code_port_pays'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
        Me.T_liste_code_port_paysTableAdapter.Fill(Me.CLIDataSet.T_liste_code_port_pays)

    End Sub
End Class