




Public Class FormImport
    Private Sub BT_import_Click(sender As Object, e As EventArgs) Handles BT_Charger.Click
        If FolderBrowserDialog1.ShowDialog() Then
            If FolderBrowserDialog1.SelectedPath <> "" Then



                Dim path As String = FolderBrowserDialog1.SelectedPath
                Dim importnum As String = Now.Ticks
                Dim creepar As String = "Import" & importnum
                'vérification que les 3 fichiers sont présents
                If Not My.Computer.FileSystem.FileExists(path & "/entete.csv") Then
                    MessageBox.Show("le fichier entete.csv est introuvable", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub

                End If

                If Not My.Computer.FileSystem.FileExists(path & "/detail.csv") Then
                    MessageBox.Show("le fichier detail.csv est introuvable", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If Not My.Computer.FileSystem.FileExists(path & "/version.csv") Then
                    MessageBox.Show("le fichier version.csv est introuvable", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If





                'chargement des 3 fichiers en memoire

                Dim separator As Char = ","
                Dim r As LumenWorks.Framework.IO.Csv.CsvReader

                'Dim dtttt = DataAccess.DataTable.[New].ReadCsv("/entete.csv")


                r = New LumenWorks.Framework.IO.Csv.CachedCsvReader(New StreamReader(path & "/entete.csv", System.Text.Encoding.UTF7), True, separator)
                r.SupportsMultiline = True

                Dim dtEnteteTemp As New Data.DataTable
                'For Each c As String In r.GetFieldHeaders()
                '    dtEnteteTemp.Columns.Add(c)
                'Next
                'Do While r.ReadNextRecord
                '    r.SupportsMultiline = True
                '    Dim newrow As DataRow = dtEnteteTemp.NewRow
                '    Dim i As Integer = 0
                '    For Each c As DataColumn In dtEnteteTemp.Columns
                '        newrow(c.ColumnName) = r(i)
                '        i = i + 1
                '    Next


                '    dtEnteteTemp.Rows.Add(newrow)
                'Loop

                dtEnteteTemp.Load(r)





                r = New LumenWorks.Framework.IO.Csv.CsvReader(New StreamReader(path & "/detail.csv", System.Text.Encoding.UTF7), True, separator)
                Dim dtDetailTemp As New Data.DataTable

                dtDetailTemp.Load(r)

                r = New LumenWorks.Framework.IO.Csv.CsvReader(New StreamReader(path & "/version.csv", System.Text.Encoding.UTF7), True, separator)
                Dim dtVersionTemp As New Data.DataTable
                dtVersionTemp.Load(r)



                'insertion dans la base
                Dim ds As New ImportDataset
                Dim ta As New ImportDatasetTableAdapters.TableAdapterManager
                ta.Connection = gCnn
                ta.T_Article_EnteteTableAdapter = New ImportDatasetTableAdapters.T_Article_EnteteTableAdapter
                ta.T_Article_DetailTableAdapter = New ImportDatasetTableAdapters.T_Article_DetailTableAdapter
                ta.T_Article_versionTableAdapter = New ImportDatasetTableAdapters.T_Article_versionTableAdapter

                Try
                    For Each rtempEntete As DataRow In dtEnteteTemp.Rows
                        Dim dtEnteteRowInsert As ImportDataset.T_Article_EnteteRow = ds.T_Article_Entete.NewT_Article_EnteteRow
                        For Each c As DataColumn In dtEnteteTemp.Columns()
                            If c.ColumnName.ToUpper <> "ID_T_ARTICLE_ENTETE" Then
                                If Not IsDBNull(rtempEntete(c.ColumnName)) Then
                                    If ds.T_Article_Entete.Columns(c.ColumnName).DataType.Name.ToString = "Double" Or ds.T_Article_Entete.Columns(c.ColumnName).DataType.Name.ToString = "Decimal" Then
                                        dtEnteteRowInsert.Item(c.ColumnName) = rtempEntete(c.ColumnName).ToString.Replace(".", ",")
                                    Else
                                        If ds.T_Article_Entete.Columns(c.ColumnName).DataType.Name.ToString = "Boolean" Then
                                            Select Case rtempEntete(c.ColumnName)
                                                Case "1"
                                                    dtEnteteRowInsert.Item(c.ColumnName) = True
                                                Case "0"
                                                    dtEnteteRowInsert.Item(c.ColumnName) = False
                                            End Select

                                        Else
                                            dtEnteteRowInsert.Item(c.ColumnName) = rtempEntete(c.ColumnName).ToString.Replace(vbLf, vbCrLf)
                                        End If



                                    End If





                                End If

                            End If

                        Next
                        dtEnteteRowInsert.CreeLe = Now()
                        dtEnteteRowInsert.CreePar = creepar
                        ds.T_Article_Entete.AddT_Article_EnteteRow(dtEnteteRowInsert)

                        For Each rtempDetail As DataRow In dtDetailTemp.Rows
                            'ajout des details qui correspondent
                            If rtempDetail("ID_T_ARTICLE_ENTETE") = rtempEntete("ID_T_ARTICLE_ENTETE") Then
                                Dim dtDetailRowInsert As ImportDataset.T_Article_DetailRow = ds.T_Article_Detail.NewT_Article_DetailRow
                                dtDetailRowInsert.Item("ID_T_ARTICLE_ENTETE") = ds.T_Article_Entete.Rows(ds.T_Article_Entete.Rows.Count() - 1)("ID_T_ARTICLE_ENTETE")
                                For Each c As DataColumn In dtDetailTemp.Columns()
                                    If c.ColumnName.ToUpper <> "ID_T_ARTICLE_DETAIL" And c.ColumnName.ToUpper <> "ID_T_ARTICLE_ENTETE" Then
                                        If Not IsDBNull(rtempDetail(c.ColumnName)) Then

                                            If ds.T_Article_Detail.Columns(c.ColumnName).DataType.Name.ToString = "Double" Or ds.T_Article_Detail.Columns(c.ColumnName).DataType.Name.ToString = "Decimal" Then
                                                dtDetailRowInsert.Item(c.ColumnName) = rtempDetail(c.ColumnName).ToString.Replace(".", ",")
                                            Else
                                                If ds.T_Article_Detail.Columns(c.ColumnName).DataType.Name.ToString = "Boolean" Then
                                                    Select Case rtempDetail(c.ColumnName)
                                                        Case "1"
                                                            dtDetailRowInsert.Item(c.ColumnName) = True
                                                        Case "0"
                                                            dtDetailRowInsert.Item(c.ColumnName) = False
                                                    End Select

                                                Else
                                                    dtDetailRowInsert.Item(c.ColumnName) = rtempDetail(c.ColumnName).ToString.Replace(vbLf, vbCrLf)
                                                End If



                                            End If





                                        End If

                                    End If

                                Next
                                dtDetailRowInsert.CreeLe = Now()
                                dtDetailRowInsert.CreePar = creepar
                                ds.T_Article_Detail.AddT_Article_DetailRow(dtDetailRowInsert)



                                For Each rtempVersion As DataRow In dtVersionTemp.Rows
                                    'ajout des versions qui correspondent
                                    If rtempDetail("ID_T_ARTICLE_DETAIL") = rtempVersion("ID_T_ARTICLE_DETAIL") Then
                                        Dim dtVersionRowInsert As ImportDataset.T_Article_versionRow = ds.T_Article_version.NewT_Article_versionRow
                                        dtVersionRowInsert.Item("ID_T_ARTICLE_DETAIL") = ds.T_Article_Detail.Rows(ds.T_Article_Detail.Rows.Count() - 1)("ID_T_ARTICLE_DETAIL")
                                        For Each c As DataColumn In dtVersionTemp.Columns()
                                            If c.ColumnName.ToUpper <> "ID_T_ARTICLE_DETAIL" And c.ColumnName.ToUpper <> "ID_T_ARTICLE_VERSION" Then
                                                If Not IsDBNull(rtempVersion(c.ColumnName)) Then

                                                    If ds.T_Article_version.Columns(c.ColumnName).DataType.Name.ToString = "Double" Or ds.T_Article_version.Columns(c.ColumnName).DataType.Name.ToString = "Decimal" Then
                                                        dtVersionRowInsert.Item(c.ColumnName) = rtempVersion(c.ColumnName).ToString.Replace(".", ",")
                                                    Else
                                                        If ds.T_Article_version.Columns(c.ColumnName).DataType.Name.ToString = "Boolean" Then
                                                            Select Case rtempVersion(c.ColumnName)
                                                                Case "1"
                                                                    dtVersionRowInsert.Item(c.ColumnName) = True
                                                                Case "0"
                                                                    dtVersionRowInsert.Item(c.ColumnName) = False
                                                            End Select

                                                        Else
                                                            dtVersionRowInsert.Item(c.ColumnName) = rtempVersion(c.ColumnName).ToString.Replace(vbLf, vbCrLf)
                                                        End If



                                                    End If








                                                End If

                                            End If

                                        Next
                                        dtVersionRowInsert.CreeLe = Now()
                                        dtVersionRowInsert.CreePar = creepar
                                        ds.T_Article_version.AddT_Article_versionRow(dtVersionRowInsert)









                                    End If



                                Next






                            End If



                        Next




                    Next
                Catch ex As Exception
                    MessageBox.Show("Echec Opération (parser) : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try


                If MessageBox.Show("Etes-vous sûr de vouloir importer ces " & ds.T_Article_version.Rows.Count & " articles ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Try
                        ta.UpdateAll(ds)
                        I_import.Text = creepar
                        MessageBox.Show("Import réussi", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("Echec Opération (update) : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                Else
                    MessageBox.Show("Opération annulée", "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End If




            End If


        End If
    End Sub
End Class