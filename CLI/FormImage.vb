Imports System.Drawing.Imaging
Public Class FormImage

    Public Function ThumbnailCallback() As Boolean

        Return False
    End Function



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality

        Dim myCallback As Image.GetThumbnailImageAbort = New Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
        Dim encoder As System.Drawing.Imaging.ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
        Dim myEncoderParameters As New EncoderParameters(1)

        Dim myEncoderParameter As New EncoderParameter(myEncoder, 85&)
        myEncoderParameters.Param(0) = myEncoderParameter


        PictureBox2.Image = PictureBox1.Image.GetThumbnailImage(206, 80, myCallback, IntPtr.Zero)
        PictureBox2.Image.Save("c:\temp\test.jpg", encoder, myEncoderParameters)
    End Sub
    Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo

        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()

        Dim codec As ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing

    End Function

End Class