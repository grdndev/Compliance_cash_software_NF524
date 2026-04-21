Partial Class CLIDataSet
    Partial Public Class V_Recherche_Commande_VenteDataTable
        Private Sub V_Recherche_Commande_VenteDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.numcaisseColumn.ColumnName) Then
                'Ajoutez le code utilisateur ici
            End If

        End Sub

    End Class

    Partial Public Class T_modeReglementDataTable
        Private Sub T_modeReglementDataTable_T_modeReglementRowChanging(sender As Object, e As T_modeReglementRowChangeEvent) Handles Me.T_modeReglementRowChanging

        End Sub

    End Class

    Partial Class T_ActualiteDataTable

        Private Sub T_ActualiteDataTable_T_ActualiteRowChanging(ByVal sender As System.Object, ByVal e As T_ActualiteRowChangeEvent) Handles Me.T_ActualiteRowChanging

        End Sub

        Private Sub T_ActualiteDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("dateactualite") = Date.Now
        End Sub
    End Class

    Partial Class T_transaction_manuelleDataTable

        Private Sub T_transaction_manuelleDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.Date_encaissementColumn.ColumnName) Then
                'Ajoutez le code utilisateur ici
            End If

        End Sub
        Private Sub T_transaction_manuelleDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("dateTransaction") = Date.Now
            e.Row("date_encaissement") = Date.Now
            e.Row("Login") = gLogin
        End Sub

        Private Sub T_transaction_manuelleDataTable_T_transaction_manuelleRowChanging(ByVal sender As System.Object, ByVal e As T_transaction_manuelleRowChangeEvent) Handles Me.T_transaction_manuelleRowChanging

        End Sub

    End Class

    Partial Class V_Avoir_clientDataTable

        Private Sub V_Avoir_clientDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.UtiliseLeColumn.ColumnName) Then
                'Ajoutez le code utilisateur ici
            End If

        End Sub

    End Class

    Partial Class T_FournisseurDataTable



        Private Sub T_FournisseurDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("creeLe") = Date.Now
            e.Row("creePar") = gLogin
        End Sub
    End Class

    Partial Class T_ProfilDataTable

        Private Sub T_ProfilDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.Vente_wColumn.ColumnName) Then
                'Ajoutez le code utilisateur ici
            End If

        End Sub

    End Class

    Partial Class T_ClientDataTable
        Private Sub T_ClientDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("creeLe") = Date.Now
            e.Row("creePar") = gLogin
        End Sub
    End Class

    Partial Class T_AvoirDataTable

        Private Sub T_AvoirDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("creeLe") = Date.Now
            e.Row("creePar") = gLogin
        End Sub
    End Class
    Partial Class T_CommandeVenteDataTable

        Private Sub T_CommandeVenteDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("creeLe") = Date.Now
            e.Row("creePar") = gLogin
            e.Row("numcaisse") = gNumCaisse
        End Sub

        Private Sub T_CommandeVenteDataTable_T_CommandeVenteRowChanging(sender As Object, e As T_CommandeVenteRowChangeEvent) Handles Me.T_CommandeVenteRowChanging

        End Sub

    End Class


    Partial Class T_Article_DetailDataTable



        Private Sub T_Article_DetailDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("creeLe") = Date.Now
            e.Row("creePar") = gLogin
        End Sub
    End Class

    Partial Class T_Article_EnteteDataTable



        Private Sub T_Article_EnteteDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("creeLe") = Date.Now
            e.Row("creePar") = gLogin
        End Sub
    End Class

    Partial Class T_Article_versionDataTable

        Private Sub T_Article_versionDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles Me.TableNewRow
            e.Row("creeLe") = Date.Now
            e.Row("creePar") = gLogin
        End Sub

        Private Sub T_Article_versionDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.prix_vente_initial_TTCColumn.ColumnName) Then
                'Ajoutez le code utilisateur ici
            End If

        End Sub

    End Class
    
End Class

Namespace CLIDataSetTableAdapters


    Partial Public Class T_CommandeVente_LigneTableAdapter
    End Class

    Partial Class V_Avoir_clientTableAdapter

    End Class

    Partial Class T_UserTableAdapter

    End Class



End Namespace

Namespace CLIDataSetTableAdapters
    
    Partial Public Class T_CommandeVente_LigneTableAdapter
    End Class
End Namespace

Namespace CLIDataSetTableAdapters
    
    Partial Public Class T_ActualiteTableAdapter
    End Class
End Namespace

Namespace CLIDataSetTableAdapters
    Partial Public Class V_Recherche_EcheanceTableAdapter
    End Class
End Namespace
