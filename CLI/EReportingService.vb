' =============================================
' NF525 REFORME 2026 - E-REPORTING SERVICE
' =============================================
' Date: 2026-02-16
' Auteur: Antigravity
' Description: 
'   Service de génération et transmission des données E-Reporting (B2C)
'   Source: T_Cloture (Tickets Z)
'   Format: XML DGFIP (Synthèse)
' =============================================

Imports System.Data.SqlClient
Imports System.Xml
Imports System.IO
Imports System.Text

Public Class EReportingService

    Private _connectionString As String

    Public Sub New(connectionString As String)
        _connectionString = connectionString
    End Sub

    ''' <summary>
    ''' Génère le rapport pour une période donnée (ex: décade)
    ''' </summary>
    Public Function GenerateReport(dateDebut As DateTime, dateFin As DateTime) As String
        Try
            ' 1. Récupérer les données Z
            Dim dt As DataTable = GetDonneesCloture(dateDebut, dateFin)
            
            If dt.Rows.Count = 0 Then Return "AUCUNE_DONNEE"

            ' 2. Construire XML
            Dim xmlDoc As New XmlDocument()
            Dim root As XmlElement = xmlDoc.CreateElement("EReporting", "urn:dgfip:ereporting:v1")
            xmlDoc.AppendChild(root)

            ' Header
            Dim header As XmlElement = xmlDoc.CreateElement("Header")
            header.AppendChild(CreateNode(xmlDoc, "PeriodStart", dateDebut.ToString("yyyy-MM-dd")))
            header.AppendChild(CreateNode(xmlDoc, "PeriodEnd", dateFin.ToString("yyyy-MM-dd")))
            header.AppendChild(CreateNode(xmlDoc, "Siret", "48450148100010")) ' TODO: Param
            root.AppendChild(header)

            ' Transactions (Agrégées par jour)
            Dim transactions As XmlElement = xmlDoc.CreateElement("Transactions")
            
            For Each row As DataRow In dt.Rows
                Dim trans As XmlElement = xmlDoc.CreateElement("Transaction")
                trans.SetAttribute("Date", CType(row("DateCloture"), DateTime).ToString("yyyy-MM-dd"))
                
                ' Totaux
                trans.AppendChild(CreateNode(xmlDoc, "TotalTTC", row("MontantTotal_Jour_TTC").ToString()))
                ' Note: Dans un vrai cas, il faut ventiler par taux TVA
                ' Ici on suppose que T_Cloture a juste le total, 
                ' il faudrait idéalement requêter T_Reglement pour le détail TVA
                
                transactions.AppendChild(trans)
            Next
            
            root.AppendChild(transactions)
            
            ' Signature NF525 du rapport (pour intégrité)
            Dim signature As String = ComputeHash(xmlDoc.OuterXml)
            root.AppendChild(CreateNode(xmlDoc, "ReportSignature", signature))

            Return FormatXml(xmlDoc)

        Catch ex As Exception
            Return "ERREUR: " & ex.Message
        End Try
    End Function

    ''' <summary>
    ''' Simule l'envoi à la PDP
    ''' </summary>
    Public Function TransmitReport(xmlContent As String) As Boolean
        ' TODO: Implémenter appel API PDP
        ' Pour l'instant on sauvegarde sur disque
        Try
            Dim filename As String = "EReporting_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xml"
            File.WriteAllText(Path.Combine(Application.StartupPath, "Exports", filename), xmlContent)
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Function GetDonneesCloture(startD As DateTime, endD As DateTime) As DataTable
        Dim dt As New DataTable()
        Using cnn As New SqlConnection(_connectionString)
            cnn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM T_Cloture WHERE DateCloture BETWEEN @Start AND @End ORDER BY DateCloture", cnn)
            cmd.Parameters.AddWithValue("@Start", startD)
            cmd.Parameters.AddWithValue("@End", endD)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
        End Using
        Return dt
    End Function

    Private Function CreateNode(doc As XmlDocument, name As String, value As String) As XmlElement
        Dim el As XmlElement = doc.CreateElement(name)
        el.InnerText = value
        Return el
    End Function

    Private Function FormatXml(doc As XmlDocument) As String
        Dim sb As New StringBuilder()
        Dim settings As New XmlWriterSettings()
        settings.Indent = True
        Using writer As XmlWriter = XmlWriter.Create(sb, settings)
            doc.Save(writer)
        End Using
        Return sb.ToString()
    End Function

    Private Function ComputeHash(input As String) As String
        ' Simulation SHA256 pour signature interne
        Using sha As New System.Security.Cryptography.SHA256Managed()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(input)
            Dim hash As Byte() = sha.ComputeHash(bytes)
            Return Convert.ToBase64String(hash)
        End Using
    End Function

End Class
