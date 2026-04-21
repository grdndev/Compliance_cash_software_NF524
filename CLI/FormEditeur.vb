Public Class FormEditeur

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RichTextBox1.SelectionFont = New Font("arial", "20", FontStyle.Bold, GraphicsUnit.Point, 0)
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        RichTextBox1.SelectionFont = New Font("arial", RichTextBox1.SelectionFont.Size, FontStyle.Strikeout, GraphicsUnit.Pixel, 0)
    End Sub
End Class