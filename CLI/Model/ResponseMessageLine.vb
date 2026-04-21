Imports DocumentFormat.OpenXml.Vml.Office

Public Class ResponseMessageLine
    Public Property Type As ResponseMessageType
    Public Property Entry As String
    Public Property Detail As String

    Public Sub New(ByVal type As ResponseMessageType, ByVal entry As String, ByVal detail As String)
        Me.Type = type
        Me.Entry = entry
        Me.Detail = detail
    End Sub
End Class

Public Enum ResponseMessageType
    Information = 0
    Warning = 1
    [Error] = 2
End Enum
