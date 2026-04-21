Imports System.Linq

Module ModuleCSV
    Public Function csvToDatatable_2(ByVal filename As String, ByVal separator As String) As DataTable
        Dim dt As New System.Data.DataTable
        Dim firstLine As Boolean = True
        If System.IO.File.Exists(filename) Then
            Using sr As New StreamReader(filename)
                While Not sr.EndOfStream
                    If firstLine Then
                        firstLine = False
                        Dim cols = sr.ReadLine.Split(separator)
                        For Each col As String In cols
                            dt.Columns.Add(New DataColumn(col, GetType(String)))
                        Next
                    Else
                        Dim data() As String = sr.ReadLine.Split(separator)
                        dt.Rows.Add(data.ToArray)
                    End If
                End While
            End Using
        End If


        Return dt
    End Function
End Module
