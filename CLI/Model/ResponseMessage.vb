Public Class ResponseMessage
    Public Property ResponseMessageLines As List(Of ResponseMessageLine)
    Public Property ImageDatas As List(Of ImageData)
    Public Property Objects As List(Of Object)

    Public Sub New()
        ResponseMessageLines = New List(Of ResponseMessageLine)()
        ImageDatas = New List(Of ImageData)()
        Objects = New List(Of Object)()
    End Sub


End Class
