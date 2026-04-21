Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strinsert As String
        Dim mode_reglement As String
        Dim moyen_paiement As String
        Dim enregistrele As String
        Dim Encaissele As String
        Dim echeancele As String
        Dim aEncaisser As String
        Dim Encaissele1 As Date = #12/18/2008#



        'on boucle sur les commandes qui n'ont pas de reglement 
        Dim dcommande As DataTable = ExecuteRequeteR("select payele as payele2,Creele as creele2,* from t_commandevente where id_t_commandevente not in (select distinct id_t_commande_vente from t_reglement) and modereglement is not null and (MontantPaiementTTC<>0 or AvoirUtiliseMontant<>0)", My.Settings.CLIConnectionString)
        'Dim dcommande As DataTable = ExecuteRequeteR("select convert(varchar,payele) as payele2,convert(varchar,Creele) as creele2,* from t_commandevente where id_t_commandevente not in (select distinct id_t_commande_vente from t_reglement) and modereglement is not null and (MontantPaiementTTC<>0 or AvoirUtiliseMontant<>0) and id_t_commandevente=149", My.Settings.CLIConnectionString)
        'pour chaque ligne on ajoute le reglement et l'avoir si besoin
        For Each r As DataRow In dcommande.Rows
            'insertion de l'avoir
            If r.Item("AvoirUtiliseNo").ToString <> "" And r.Item("AvoirUtiliseMontant").ToString <> "0" Then
                mode_reglement = 15
                moyen_paiement = 7
                If r.Item("Payele2").ToString = "" Then

                    enregistrele = r.Item("Creele2")
                    Encaissele = r.Item("Creele2")
                    echeancele = r.Item("Creele2")
                Else
                    enregistrele = r.Item("Payele2")
                    Encaissele = r.Item("Payele2")
                    echeancele = r.Item("Payele2")
                End If

                aEncaisser = 1
                strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & r.Item("AvoirUtiliseMontant").ToString & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', '" & Encaissele & "', " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"
                ExecuteRequeteR(strinsert, My.Settings.CLIConnectionString)
                Select Case r.Item("ModeReglement").ToString.ToUpper
                    Case "Espèces".ToUpper
                        mode_reglement = 15
                        moyen_paiement = 6
                        If r.Item("Payele2").ToString = "" Then

                            enregistrele = r.Item("Creele2")
                            Encaissele = r.Item("Creele2")
                            echeancele = r.Item("Creele2")
                        Else
                            enregistrele = r.Item("Payele2")
                            Encaissele = r.Item("Payele2")
                            echeancele = r.Item("Payele2")
                        End If
                        aEncaisser = 1
                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & r.Item("MontantPaiementTTC") & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', '" & Encaissele & "', " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"
                    Case "Virement bancaire".ToUpper
                        mode_reglement = 15
                        moyen_paiement = 4
                        If r.Item("Payele2").ToString = "" Then

                            enregistrele = r.Item("Creele2")
                            Encaissele = r.Item("Creele2")
                            echeancele = r.Item("Creele2")
                        Else
                            enregistrele = r.Item("Payele2")
                            Encaissele = r.Item("Payele2")
                            echeancele = r.Item("Payele2")
                        End If
                        aEncaisser = 1
                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & r.Item("MontantPaiementTTC") & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', '" & Encaissele & "', " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"
                    Case "Chèque à la commande".ToUpper
                        mode_reglement = 15
                        moyen_paiement = 2
                        If r.Item("Payele2").ToString = "" Then

                            enregistrele = r.Item("Creele2")
                            Encaissele = r.Item("Creele2")
                            echeancele = r.Item("Creele2")
                        Else
                            enregistrele = r.Item("Payele2")
                            Encaissele = r.Item("Payele2")
                            echeancele = r.Item("Payele2")
                        End If
                        aEncaisser = 1
                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & r.Item("MontantPaiementTTC") & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', '" & Encaissele & "', " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"
                    Case "Carte Bancaire".ToUpper
                        mode_reglement = 15
                        moyen_paiement = 1
                        If r.Item("Payele2").ToString = "" Then

                            enregistrele = r.Item("Creele2")
                            Encaissele = r.Item("Creele2")
                            echeancele = r.Item("Creele2")
                        Else
                            enregistrele = r.Item("Payele2")
                            Encaissele = r.Item("Payele2")
                            echeancele = r.Item("Payele2")
                        End If
                        aEncaisser = 1
                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & r.Item("MontantPaiementTTC") & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', '" & Encaissele & "', " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"
                    Case "Contre-remboursement".ToUpper
                        mode_reglement = 15
                        moyen_paiement = 5
                        If r.Item("Payele2").ToString = "" Then

                            enregistrele = r.Item("Creele2")
                            Encaissele = r.Item("Creele2")
                            echeancele = r.Item("Creele2")
                        Else
                            enregistrele = r.Item("Payele2")
                            Encaissele = r.Item("Payele2")
                            echeancele = r.Item("Payele2")
                        End If
                        aEncaisser = 1
                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & r.Item("MontantPaiementTTC") & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', '" & Encaissele & "', " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"
                    Case "3X sans frais CB".ToUpper
                        '1ère fois
                        mode_reglement = 7
                        moyen_paiement = 1
                        If r.Item("Payele2").ToString = "" Then

                            enregistrele = r.Item("Creele2")
                            Encaissele = r.Item("Creele2")
                            echeancele = r.Item("Creele2")
                        Else
                            enregistrele = r.Item("Payele2")
                            Encaissele = r.Item("Payele2")
                            echeancele = r.Item("Payele2")
                        End If
                        aEncaisser = 1
                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & (r.Item("Total_TTC")) / 3 & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', '" & Encaissele & "', " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"
                        ExecuteRequeteR(strinsert, My.Settings.CLIConnectionString)
                        '1ère fois
                        mode_reglement = 7
                        moyen_paiement = 1


                        If r.Item("Payele2").ToString = "" Then

     
                            enregistrele = r.Item("Creele2")

                            echeancele = DateAdd(DateInterval.Month, 1, CDate(r.Item("Creele2"))).ToString("s")
                            If echeancele <= Now() Then
                                aEncaisser = 1
                                Encaissele = DateAdd(DateInterval.Month, 1, CDate(r.Item("Creele2"))).ToString("s")
                            Else
                                Encaissele = Nothing
                                aEncaisser = 0
                            End If
                        Else
                            enregistrele = r.Item("Payele2")

                            echeancele = DateAdd(DateInterval.Month, 1, CDate(r.Item("Payele2"))).ToString("s")
                            If echeancele <= Now() Then
                                aEncaisser = 1
                                Encaissele = DateAdd(DateInterval.Month, 1, CDate(r.Item("Payele2"))).ToString("s")
                            Else
                                Encaissele = Nothing
                                aEncaisser = 0
                            End If
                        End If

                       

                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & (r.Item("Total_TTC")) / 3 & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', " & IIf(Encaissele Is Nothing, "NULL", "'" & Encaissele & "'") & ", " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"
                        ExecuteRequeteR(strinsert, My.Settings.CLIConnectionString)
                        '3ème fois
                        mode_reglement = 7
                        moyen_paiement = 1
                        If r.Item("Payele2").ToString = "" Then


                            enregistrele = r.Item("Creele2")

                            echeancele = DateAdd(DateInterval.Month, 2, CDate(r.Item("Creele2"))).ToString("s")
                            If echeancele <= Now() Then
                                aEncaisser = 1
                                Encaissele = DateAdd(DateInterval.Month, 2, CDate(r.Item("Creele2"))).ToString("s")
                            Else
                                Encaissele = Nothing
                                aEncaisser = 0
                            End If
                        Else
                            enregistrele = r.Item("Payele2")

                            echeancele = DateAdd(DateInterval.Month, 2, CDate(r.Item("Payele2"))).ToString("s")
                            If echeancele <= Now() Then
                                aEncaisser = 1
                                Encaissele = DateAdd(DateInterval.Month, 2, CDate(r.Item("Payele2"))).ToString("s")
                            Else
                                Encaissele = Nothing
                                aEncaisser = 0
                            End If
                        End If
                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & Math.Round((r.Item("Total_TTC")) / 3, 3) & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', " & IIf(Encaissele Is Nothing, "NULL", "'" & Encaissele & "'") & ", " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"


                End Select
                ExecuteRequeteR(strinsert, My.Settings.CLIConnectionString)
                strinsert = "update t_commandevente set montantencaisseTTC= (select  sum(montant) from t_reglement where encaisse_le is not null and id_t_commande_vente=" & r.Item("ID_T_CommandeVente").ToString & ")  where id_t_commandevente=" & r.Item("ID_T_CommandeVente").ToString

                ExecuteRequeteR(strinsert, My.Settings.CLIConnectionString)
                strinsert = "update t_commandevente set montantPaiementTTC= (select sum(montant) from t_reglement where  id_t_commande_vente=" & r.Item("ID_T_CommandeVente").ToString & ")  where id_t_commandevente=" & r.Item("ID_T_CommandeVente").ToString

                ExecuteRequeteR(strinsert, My.Settings.CLIConnectionString)
            Else
                Select Case r.Item("ModeReglement").ToString.ToUpper
                    Case "Espèces".ToUpper
                        mode_reglement = 15
                        moyen_paiement = 6
                        If r.Item("Payele2").ToString = "" Then

                            enregistrele = r.Item("Creele2")
                            Encaissele = r.Item("Creele2")
                            echeancele = r.Item("Creele2")
                        Else
                            enregistrele = r.Item("Payele2")
                            Encaissele = r.Item("Payele2")
                            echeancele = r.Item("Payele2")
                        End If
                        aEncaisser = 1
                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & r.Item("MontantPaiementTTC") & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', '" & Encaissele & "', " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"
                    Case "Virement bancaire".ToUpper
                        mode_reglement = 15
                        moyen_paiement = 4
                        If r.Item("Payele2").ToString = "" Then

                            enregistrele = r.Item("Creele2")
                            Encaissele = r.Item("Creele2")
                            echeancele = r.Item("Creele2")
                        Else
                            enregistrele = r.Item("Payele2")
                            Encaissele = r.Item("Payele2")
                            echeancele = r.Item("Payele2")
                        End If
                        aEncaisser = 1
                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & r.Item("MontantPaiementTTC") & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', '" & Encaissele & "', " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"
                    Case "Chèque à la commande".ToUpper
                        mode_reglement = 15
                        moyen_paiement = 2
                        If r.Item("Payele2").ToString = "" Then

                            enregistrele = r.Item("Creele2")
                            Encaissele = r.Item("Creele2")
                            echeancele = r.Item("Creele2")
                        Else
                            enregistrele = r.Item("Payele2")
                            Encaissele = r.Item("Payele2")
                            echeancele = r.Item("Payele2")
                        End If
                        aEncaisser = 1
                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & r.Item("MontantPaiementTTC") & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', '" & Encaissele & "', " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"
                    Case "Carte Bancaire".ToUpper
                        mode_reglement = 15
                        moyen_paiement = 1
                        If r.Item("Payele2").ToString = "" Then

                            enregistrele = r.Item("Creele2")
                            Encaissele = r.Item("Creele2")
                            echeancele = r.Item("Creele2")
                        Else
                            enregistrele = r.Item("Payele2")
                            Encaissele = r.Item("Payele2")
                            echeancele = r.Item("Payele2")
                        End If
                        aEncaisser = 1
                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & r.Item("MontantPaiementTTC") & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', '" & Encaissele & "', " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"
                    Case "Contre-remboursement".ToUpper
                        mode_reglement = 15
                        moyen_paiement = 5
                        If r.Item("Payele2").ToString = "" Then

                            enregistrele = r.Item("Creele2")
                            Encaissele = r.Item("Creele2")
                            echeancele = r.Item("Creele2")
                        Else
                            enregistrele = r.Item("Payele2")
                            Encaissele = r.Item("Payele2")
                            echeancele = r.Item("Payele2")
                        End If
                        aEncaisser = 1
                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & r.Item("MontantPaiementTTC") & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', '" & Encaissele & "', " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"
                    Case "3X sans frais CB".ToUpper
                        '1ère fois
                        mode_reglement = 7
                        moyen_paiement = 1
                        If r.Item("Payele2").ToString = "" Then

                            enregistrele = r.Item("Creele2")
                            Encaissele = r.Item("Creele2")
                            echeancele = r.Item("Creele2")
                        Else
                            enregistrele = r.Item("Payele2")
                            Encaissele = r.Item("Payele2")
                            echeancele = r.Item("Payele2")
                        End If
                        aEncaisser = 1
                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & r.Item("Total_TTC") / 3 & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', '" & Encaissele & "', " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"
                        ExecuteRequeteR(strinsert, My.Settings.CLIConnectionString)
                        '1ère fois
                        mode_reglement = 7
                        moyen_paiement = 1
                        If r.Item("Payele2").ToString = "" Then


                            enregistrele = r.Item("Creele2")

                            echeancele = DateAdd(DateInterval.Month, 1, CDate(r.Item("Creele2"))).ToString("s")
                            If echeancele <= Now() Then
                                aEncaisser = 1
                                Encaissele = DateAdd(DateInterval.Month, 1, CDate(r.Item("Creele2"))).ToString("s")
                            Else
                                Encaissele = Nothing
                                aEncaisser = 0
                            End If
                        Else
                            enregistrele = r.Item("Payele2")

                            echeancele = DateAdd(DateInterval.Month, 1, CDate(r.Item("Payele2"))).ToString("s")
                            If echeancele <= Now() Then
                                aEncaisser = 1
                                Encaissele = DateAdd(DateInterval.Month, 1, CDate(r.Item("Payele2"))).ToString("s")
                            Else
                                Encaissele = Nothing
                                aEncaisser = 0
                            End If
                        End If

                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & r.Item("Total_TTC") / 3 & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', " & IIf(Encaissele Is Nothing, "NULL", "'" & Encaissele & "'") & ", " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"
                        ExecuteRequeteR(strinsert, My.Settings.CLIConnectionString)
                        '3ème fois
                        mode_reglement = 7
                        moyen_paiement = 1
                        If r.Item("Payele2").ToString = "" Then


                            enregistrele = r.Item("Creele2")

                            echeancele = DateAdd(DateInterval.Month, 2, CDate(r.Item("Creele2"))).ToString("s")
                            If echeancele <= Now() Then
                                aEncaisser = 1
                                Encaissele = DateAdd(DateInterval.Month, 2, CDate(r.Item("Creele2"))).ToString("s")
                            Else
                                Encaissele = Nothing
                                aEncaisser = 0
                            End If
                        Else
                            enregistrele = r.Item("Payele2")

                            echeancele = DateAdd(DateInterval.Month, 2, CDate(r.Item("Payele2"))).ToString("s")
                            If echeancele <= Now() Then
                                aEncaisser = 1
                                Encaissele = DateAdd(DateInterval.Month, 2, CDate(r.Item("Payele2"))).ToString("s")
                            Else
                                Encaissele = Nothing
                                aEncaisser = 0
                            End If
                        End If
                        strinsert = "INSERT INTO [T_Reglement]( [Condition_reglement], [Moyen_paiement], [Montant], [Reference_avoir_bon], [Enregistre_le], [Echeance_le], [Encaisse_le], [A_Encaisser], [id_t_commande_vente]) VALUES( " & mode_reglement & "," & moyen_paiement & ", " & r.Item("Total_TTC") / 3 & ", " & r.Item("AvoirUtiliseNo").ToString & ", '" & enregistrele & "', '" & echeancele & "', " & IIf(Encaissele Is Nothing, "NULL", "'" & Encaissele & "'") & ", " & aEncaisser & ", " & r.Item("ID_T_CommandeVente").ToString & ")"




                End Select
                ExecuteRequeteR(strinsert, My.Settings.CLIConnectionString)
                strinsert = "update t_commandevente set montantencaisseTTC= (select  sum(montant) from t_reglement where encaisse_le is not null and id_t_commande_vente=" & r.Item("ID_T_CommandeVente").ToString & ")  where id_t_commandevente=" & r.Item("ID_T_CommandeVente").ToString

                ExecuteRequeteR(strinsert, My.Settings.CLIConnectionString)
                strinsert = "update t_commandevente set montantPaiementTTC= (select sum(montant) from t_reglement where  id_t_commande_vente=" & r.Item("ID_T_CommandeVente").ToString & ")  where id_t_commandevente=" & r.Item("ID_T_CommandeVente").ToString

                ExecuteRequeteR(strinsert, My.Settings.CLIConnectionString)
            End If
        Next
        ExecuteRequeteR("update t_commandevente set montantpaiementTTC=0 where montantpaiementTTC is null", My.Settings.CLIConnectionString)

    End Sub
End Class
