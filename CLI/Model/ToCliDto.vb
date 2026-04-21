Public Class ToCliDto
    Public Id As Long
    Public Id_T_Famille As Long
    Public Reference As String = ""
    Public Force As Boolean = False
    Public AssociatedAddress As Boolean = False
    Public AssociatedCartRule As Boolean = False
    Public AssociatedLegacyImages As Boolean = False
    Public OnlyErrors As Boolean = False
    Public OnlyNewSync As Boolean = False
    Public UpdatedDateFrom As Date? = Nothing
    Public ImportStock As Boolean = False
    Public DeleteBeforeImport As Boolean = False
    Public Image As String = ""
    Public FactureData As Byte()
    Public DefaultImageId As Long
    Public ToDeleteImages As List(Of Long)
    Public ToAddImages As List(Of ImageData)
    Public Number As Int16
    'Pour gérer les produits en masse
    Public Ids As List(Of Long)
    Public CurrentMessage As String = ""
    Public NewMessage As String = ""
End Class
