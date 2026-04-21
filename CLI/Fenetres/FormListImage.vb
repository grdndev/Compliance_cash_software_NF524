Imports System.Drawing.Imaging
Imports System.Linq
Imports DocumentFormat.OpenXml.Drawing.Diagrams

Public Class FormListImage
    Public _imageList As List(Of ImageData)
    Public _imageListOrigin As List(Of ImageData)
    Public _imageToDeleteList As List(Of Long)
    Public _imageToAddList As List(Of ImageData)
    Public _defaultImage As Long

    Private Sub FormListImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _imageListOrigin = New List(Of ImageData)(_imageList)
        PopulateListBox()
        For Each imageData As ImageData In _imageToAddList
            _imageList.Add(imageData)
            ListBox1.Items.Add(imageData.Id)
        Next
    End Sub
    Private Sub PopulateListBox()
        ListBox1.Items.Clear()
        For Each imageData As ImageData In _imageList
            If Not _imageToDeleteList.Contains(imageData.Id) Then
                ListBox1.Items.Add(imageData.Id)
            End If
        Next

        ' For Each imageData As ImageData In _imageToAddList
        ' ListBox1.Items.Add(imageData.Id)
        'Next
        PictureBox1.Image = Nothing
        If ListBox1.Items.Count > 0 Then
            ListBox1.SelectedIndex = 0
        End If

        I_Default.Items.Clear()
        For Each imageData As ImageData In _imageList
            If Not _imageToDeleteList.Contains(imageData.Id) Then
                I_Default.Items.Add(imageData.Id)
            End If
        Next

        If I_Default.Items.Count > 0 And _defaultImage > 0 Then
            I_Default.Text = _defaultImage
        End If

    End Sub
    Private Sub DisplayImage()
        Dim selectedItemIndex As Integer = ListBox1.SelectedIndex
        If selectedItemIndex >= 0 Then
            Dim selectedImageData As ImageData = _imageList(selectedItemIndex)
            Dim imageStream As New System.IO.MemoryStream(selectedImageData.Data)
            PictureBox1.Image = Image.FromStream(imageStream)
        Else
            PictureBox1.Image = Nothing
        End If
    End Sub
    Private Sub Reset()
        _imageToAddList.Clear()
        _imageToDeleteList.Clear()
        _imageList = New List(Of ImageData)(_imageListOrigin)

        PopulateListBox()
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        DisplayImage()
    End Sub

    Private Sub BT_Supprimer_Click(sender As Object, e As EventArgs) Handles BT_Supprimer.Click
        If ListBox1.SelectedItem > 0 Then
            _imageToDeleteList.Add(ListBox1.SelectedItem)
        End If

        For i As Integer = 0 To _imageList.Count - 1
            If _imageList(i).Id = ListBox1.SelectedItem Then
                _imageList.RemoveAt(i)
                Exit For
            End If

        Next

        PopulateListBox()
    End Sub

    Private Sub BT_Reset_Click(sender As Object, e As EventArgs) Handles BT_Reset.Click
        Reset()
    End Sub

    Private Sub BT_Fermer_Click(sender As Object, e As EventArgs) Handles BT_Fermer.Click
        Me.Close()
    End Sub

    Private Sub BT_Ajouter_Click(sender As Object, e As EventArgs) Handles BT_Ajouter.Click
        Dim myImageCodecInfo As ImageCodecInfo
        Dim myEncoder As Encoder
        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            'verification du format 4/3



            '

            Dim image_orig As New Bitmap(OpenFileDialog1.FileName)
            Dim image_big As New Bitmap(gPhotoWidth, gPhotoHeight)

            Dim g As Graphics = Graphics.FromImage(image_big)
            myImageCodecInfo = GetEncoderInfo("image/jpeg")
            myEncoder = Encoder.Quality
            myEncoderParameters = New EncoderParameters(1)
            myEncoderParameter = New EncoderParameter(myEncoder, CType(gQualiteJPG, Int32))
            myEncoderParameters.Param(0) = myEncoderParameter

            Application.DoEvents()

            If Math.Round(image_orig.Size.Width / image_orig.Size.Height, 2) = Math.Round(4 / 3, 2) Then
                'redimensionnement au bon format
                g.DrawImage(image_orig, New Rectangle(0, 0, gPhotoWidth, gPhotoHeight), 0, 0, image_orig.Width, image_orig.Height, System.Drawing.GraphicsUnit.Pixel)

                Dim byteArray As Byte()
                Dim memoryStream As New System.IO.MemoryStream()

                image_big.Save(memoryStream, myImageCodecInfo, myEncoderParameters)
                byteArray = memoryStream.ToArray()

                ' Close the memory stream
                memoryStream.Close()
                Dim IndexMin = 0
                If _imageToAddList.Count > 0 Then
                    If _imageToAddList.Min(Function(c) c.Id).MinValue Then
                        IndexMin = _imageToAddList.Min(Function(c) c.Id) - 1
                    End If
                End If

                _imageToAddList.Add(New ImageData With {.Data = byteArray, .Id = IndexMin, .ProductId = 0})
                _imageList.Add(New ImageData With {.Data = byteArray, .Id = IndexMin, .ProductId = 0})




            Else
                MessageBox.Show("Mauvais rapport hauteur largeur. Il doit être 4/3", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            image_orig.Dispose()
            PopulateListBox()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub I_Default_SelectedIndexChanged(sender As Object, e As EventArgs) Handles I_Default.SelectedIndexChanged
        If I_Default.Text <> "" Then
            _defaultImage = I_Default.Text
        End If

    End Sub
End Class