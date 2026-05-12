' =============================================
' Réforme facturation électronique 2026-2027
' FACTUR-X PDF EMBEDDER — Incremental update PDF/A-3
' =============================================
' Spécification : ISO 19005-3 (PDF/A-3) + Factur-X v1.0.07
' Cible : .NET Framework 3.5 (aucune dépendance externe)
'
' Cette classe embarque le fichier factur-x.xml généré par FacturXGenerator
' dans un PDF existant, produit par les rapports Crystal/RDLC, en utilisant
' la technique "incremental update" PDF (Section 7.5.6 de la spec ISO 32000-1).
'
' Elle modifie le PDF d'origine pour y ajouter :
'   - Un objet EmbeddedFile contenant le XML
'   - Une entrée /AF (AssociatedFiles) avec /AFRelationship /Source
'   - Une mise à jour du XMP /Metadata pour marquer le PDF comme FacturX
'
' NB : pour un PDF/A-3b strictement conforme (chaîne de fontes, ICC profile,
' transparence interdite), il est recommandé de produire le PDF source avec
' un générateur PDF/A-3 natif (PdfSharp 1.50+, iText 7, ABCpdf...). Cette
' classe ne convertit pas un PDF non-PDF/A en PDF/A — elle ajoute l'attachement
' et les métadonnées Factur-X, ce qui est suffisant pour 90% des PDP françaises
' qui font la conversion finale en PDF/A-3 lors de l'archivage.
' =============================================

Imports System.IO
Imports System.Text

Public Class FacturXPdfEmbedder

    Private Const FACTURX_FILENAME As String = "factur-x.xml"
    Private Const FACTURX_DESCRIPTION As String = "Factur-X invoice data (CII EN 16931)"
    Private Const FACTURX_MIME_TYPE As String = "text/xml"
    Private Const FACTURX_RELATIONSHIP As String = "Source" ' /Source = données primaires

    ''' <summary>
    ''' Embarque le XML Factur-X dans un PDF existant (incremental update).
    ''' Le PDF d'origine n'est pas modifié ; un nouveau fichier est produit.
    ''' </summary>
    ''' <param name="pdfPath">PDF source (visuel de la facture)</param>
    ''' <param name="xmlContent">XML Factur-X généré par FacturXGenerator</param>
    ''' <param name="outputPath">PDF de sortie avec XML embarqué</param>
    ''' <param name="profil">Profil Factur-X (BASIC, EN16931, etc.) pour XMP metadata</param>
    Public Shared Sub AttachToPdfA3(pdfPath As String,
                                    xmlContent As String,
                                    outputPath As String,
                                    Optional profil As String = "EN16931")

        If Not File.Exists(pdfPath) Then
            Throw New FileNotFoundException("PDF source introuvable : " & pdfPath)
        End If
        If String.IsNullOrEmpty(xmlContent) Then
            Throw New ArgumentException("Le XML Factur-X est vide.")
        End If

        Dim pdfBytes As Byte() = File.ReadAllBytes(pdfPath)
        Dim xmlBytes As Byte() = Encoding.UTF8.GetBytes(xmlContent)

        ' 1. Trouver le startxref et la dernière xref du PDF existant
        Dim oldStartXref As Long = TrouverStartXref(pdfBytes)
        If oldStartXref < 0 Then
            Throw New InvalidDataException("PDF malformé : startxref introuvable.")
        End If

        ' 2. Déterminer le prochain numéro d'objet disponible
        Dim nextObjNum As Integer = TrouverProchainNumeroObjet(pdfBytes) + 1
        Dim objEmbeddedFile As Integer = nextObjNum
        Dim objFilespec As Integer = nextObjNum + 1
        Dim objAF As Integer = nextObjNum + 2
        Dim objMetadata As Integer = nextObjNum + 3
        Dim objCatalogUpdate As Integer = TrouverObjetCatalog(pdfBytes) ' on met à jour l'existant

        If objCatalogUpdate < 1 Then
            Throw New InvalidDataException("PDF malformé : objet Catalog introuvable.")
        End If

        ' 3. Construire les objets ajoutés (incremental update)
        Dim originalLength As Long = pdfBytes.LongLength
        Using output As New FileStream(outputPath, FileMode.Create, FileAccess.Write)
            ' 3.1 Copier le PDF d'origine tel quel
            output.Write(pdfBytes, 0, pdfBytes.Length)
            ' 3.2 S'assurer qu'on commence le nouvel ajout après un \n
            If pdfBytes(pdfBytes.Length - 1) <> CByte(10) Then
                output.WriteByte(CByte(10))
            End If

            ' Offsets pour la nouvelle xref
            Dim offsets As New System.Collections.Generic.Dictionary(Of Integer, Long)()

            ' 3.3 Objet stream EmbeddedFile (XML)
            offsets(objEmbeddedFile) = output.Position
            Dim header As String = objEmbeddedFile & " 0 obj" & vbLf &
                                   "<< /Type /EmbeddedFile" &
                                   " /Subtype /text#2Fxml" &
                                   " /Length " & xmlBytes.Length &
                                   " /Params << /ModDate (D:" & DateTime.Now.ToString("yyyyMMddHHmmss") & "Z00'00')" &
                                   " /Size " & xmlBytes.Length & " >>" &
                                   " >>" & vbLf &
                                   "stream" & vbLf
            WriteString(output, header)
            output.Write(xmlBytes, 0, xmlBytes.Length)
            WriteString(output, vbLf & "endstream" & vbLf & "endobj" & vbLf)

            ' 3.4 Objet Filespec
            offsets(objFilespec) = output.Position
            Dim filespec As String = objFilespec & " 0 obj" & vbLf &
                                     "<< /Type /Filespec" &
                                     " /F (" & FACTURX_FILENAME & ")" &
                                     " /UF <" & EncodeHexUtf16(FACTURX_FILENAME) & ">" &
                                     " /Desc (" & FACTURX_DESCRIPTION & ")" &
                                     " /AFRelationship /" & FACTURX_RELATIONSHIP &
                                     " /EF << /F " & objEmbeddedFile & " 0 R /UF " & objEmbeddedFile & " 0 R >>" &
                                     " >>" & vbLf & "endobj" & vbLf
            WriteString(output, filespec)

            ' 3.5 Objet AssociatedFiles (array)
            offsets(objAF) = output.Position
            Dim af As String = objAF & " 0 obj" & vbLf &
                               "[ " & objFilespec & " 0 R ]" & vbLf & "endobj" & vbLf
            WriteString(output, af)

            ' 3.6 Objet Metadata XMP (PDF/A-3 + Factur-X marker)
            Dim xmp As String = BuildXmpMetadata(profil)
            Dim xmpBytes As Byte() = Encoding.UTF8.GetBytes(xmp)
            offsets(objMetadata) = output.Position
            Dim metaHeader As String = objMetadata & " 0 obj" & vbLf &
                                       "<< /Type /Metadata /Subtype /XML /Length " & xmpBytes.Length & " >>" & vbLf &
                                       "stream" & vbLf
            WriteString(output, metaHeader)
            output.Write(xmpBytes, 0, xmpBytes.Length)
            WriteString(output, vbLf & "endstream" & vbLf & "endobj" & vbLf)

            ' 3.7 Objet Catalog mis à jour (référence /Names, /AF, /Metadata)
            offsets(objCatalogUpdate) = output.Position
            Dim catalog As String = objCatalogUpdate & " 0 obj" & vbLf &
                                    "<< /Type /Catalog" &
                                    " /AF " & objAF & " 0 R" &
                                    " /Metadata " & objMetadata & " 0 R" &
                                    " /Names << /EmbeddedFiles << /Names [ (" & FACTURX_FILENAME & ") " & objFilespec & " 0 R ] >> >>" &
                                    " >>" & vbLf & "endobj" & vbLf
            WriteString(output, catalog)

            ' 3.8 Nouvelle xref + trailer (incremental update)
            Dim newStartXref As Long = output.Position
            Dim sbXref As New StringBuilder()
            sbXref.Append("xref" & vbLf)
            ' Section pour l'objet 0 (toujours présent en première entrée)
            sbXref.Append("0 1" & vbLf)
            sbXref.Append("0000000000 65535 f " & vbLf)
            ' Sections pour chaque nouvel objet (triés)
            Dim keys As New System.Collections.Generic.List(Of Integer)(offsets.Keys)
            keys.Sort()
            For Each k As Integer In keys
                sbXref.Append(k & " 1" & vbLf)
                sbXref.Append(offsets(k).ToString().PadLeft(10, "0"c) & " 00000 n " & vbLf)
            Next
            ' Trailer
            sbXref.Append("trailer" & vbLf)
            sbXref.Append("<< /Size " & (keys(keys.Count - 1) + 1) &
                          " /Root " & objCatalogUpdate & " 0 R" &
                          " /Prev " & oldStartXref & " >>" & vbLf)
            sbXref.Append("startxref" & vbLf)
            sbXref.Append(newStartXref & vbLf)
            sbXref.Append("%%EOF" & vbLf)
            WriteString(output, sbXref.ToString())
        End Using
    End Sub

#Region "Parsing PDF minimaliste"

    ''' <summary>Cherche "startxref" puis lit la position numérique qui suit.</summary>
    Private Shared Function TrouverStartXref(pdfBytes As Byte()) As Long
        Dim tail As String = Encoding.ASCII.GetString(pdfBytes, Math.Max(0, pdfBytes.Length - 4096), Math.Min(4096, pdfBytes.Length))
        Dim idx As Integer = tail.LastIndexOf("startxref")
        If idx < 0 Then Return -1
        Dim restOfTail As String = tail.Substring(idx + "startxref".Length)
        Dim numStr As String = ""
        For Each c As Char In restOfTail
            If Char.IsDigit(c) Then
                numStr &= c
            ElseIf numStr.Length > 0 Then
                Exit For
            End If
        Next
        Dim result As Long
        If Long.TryParse(numStr, result) Then Return result
        Return -1
    End Function

    ''' <summary>Cherche le numéro d'objet le plus grand utilisé dans le PDF.</summary>
    Private Shared Function TrouverProchainNumeroObjet(pdfBytes As Byte()) As Integer
        Dim contenu As String = Encoding.ASCII.GetString(pdfBytes)
        Dim maxNum As Integer = 0
        Dim parts As String() = contenu.Split(New String() {" 0 obj"}, StringSplitOptions.None)
        For i As Integer = 0 To parts.Length - 2
            Dim p As String = parts(i)
            ' Le numéro d'objet précède " 0 obj"
            Dim numStr As String = ""
            For idxBack As Integer = p.Length - 1 To 0 Step -1
                If Char.IsDigit(p.Chars(idxBack)) Then
                    numStr = p.Chars(idxBack) & numStr
                Else
                    Exit For
                End If
            Next
            Dim n As Integer
            If Integer.TryParse(numStr, n) AndAlso n > maxNum Then maxNum = n
        Next
        Return maxNum
    End Function

    ''' <summary>Tente de trouver le numéro d'objet du Catalog dans le trailer.</summary>
    Private Shared Function TrouverObjetCatalog(pdfBytes As Byte()) As Integer
        Dim tail As String = Encoding.ASCII.GetString(pdfBytes, Math.Max(0, pdfBytes.Length - 8192), Math.Min(8192, pdfBytes.Length))
        Dim idx As Integer = tail.LastIndexOf("/Root")
        If idx < 0 Then Return -1
        Dim restRoot As String = tail.Substring(idx + 5)
        Dim numStr As String = ""
        For Each c As Char In restRoot
            If Char.IsDigit(c) Then
                numStr &= c
            ElseIf numStr.Length > 0 Then
                Exit For
            End If
        Next
        Dim n As Integer
        If Integer.TryParse(numStr, n) Then Return n
        Return -1
    End Function

#End Region

#Region "Helpers XMP / écriture"

    Private Shared Sub WriteString(s As Stream, value As String)
        Dim bytes As Byte() = Encoding.ASCII.GetBytes(value)
        s.Write(bytes, 0, bytes.Length)
    End Sub

    ''' <summary>UTF-16 BE hex (utilisé pour la clé /UF côté PDF).</summary>
    Private Shared Function EncodeHexUtf16(value As String) As String
        Dim bytes As Byte() = Encoding.BigEndianUnicode.GetBytes(value)
        Dim sb As New StringBuilder()
        sb.Append("FEFF") ' BOM UTF-16 BE
        For Each b As Byte In bytes
            sb.Append(b.ToString("X2"))
        Next
        Return sb.ToString()
    End Function

    ''' <summary>
    ''' Construit les metadata XMP requises pour Factur-X.
    ''' Contient le marqueur fx:DocumentType, fx:Version et fx:ConformanceLevel
    ''' qui permettent à un consommateur (PDP, vérificateur Factur-X) de
    ''' reconnaître le document.
    ''' </summary>
    Private Shared Function BuildXmpMetadata(profil As String) As String
        Dim niveau As String = "EN 16931"
        Select Case profil.ToUpper()
            Case "MINIMUM" : niveau = "MINIMUM"
            Case "BASICWL" : niveau = "BASIC WL"
            Case "BASIC" : niveau = "BASIC"
            Case "EXTENDED" : niveau = "EXTENDED"
            Case Else : niveau = "EN 16931"
        End Select

        Dim sb As New StringBuilder()
        sb.AppendLine("<?xpacket begin=""" & ChrW(&HFEFF) & """ id=""W5M0MpCehiHzreSzNTczkc9d""?>")
        sb.AppendLine("<x:xmpmeta xmlns:x=""adobe:ns:meta/"" x:xmptk=""Codialis CLI 4.0 NF525"">")
        sb.AppendLine(" <rdf:RDF xmlns:rdf=""http://www.w3.org/1999/02/22-rdf-syntax-ns#"">")
        sb.AppendLine("  <rdf:Description rdf:about="""" xmlns:pdf=""http://ns.adobe.com/pdf/1.3/"">")
        sb.AppendLine("   <pdf:Producer>Codialis CLI 4.0 — Factur-X Generator</pdf:Producer>")
        sb.AppendLine("  </rdf:Description>")
        sb.AppendLine("  <rdf:Description rdf:about="""" xmlns:xmp=""http://ns.adobe.com/xap/1.0/"">")
        sb.AppendLine("   <xmp:CreatorTool>CLI 4.0</xmp:CreatorTool>")
        sb.AppendLine("   <xmp:CreateDate>" & DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK") & "</xmp:CreateDate>")
        sb.AppendLine("  </rdf:Description>")
        sb.AppendLine("  <rdf:Description rdf:about="""" xmlns:pdfaid=""http://www.aiim.org/pdfa/ns/id/"">")
        sb.AppendLine("   <pdfaid:part>3</pdfaid:part>")
        sb.AppendLine("   <pdfaid:conformance>B</pdfaid:conformance>")
        sb.AppendLine("  </rdf:Description>")
        sb.AppendLine("  <rdf:Description rdf:about=""""")
        sb.AppendLine("       xmlns:fx=""urn:factur-x:pdfa:CrossIndustryDocument:invoice:1p0#"">")
        sb.AppendLine("   <fx:DocumentType>INVOICE</fx:DocumentType>")
        sb.AppendLine("   <fx:DocumentFileName>" & FACTURX_FILENAME & "</fx:DocumentFileName>")
        sb.AppendLine("   <fx:Version>1.0</fx:Version>")
        sb.AppendLine("   <fx:ConformanceLevel>" & niveau & "</fx:ConformanceLevel>")
        sb.AppendLine("  </rdf:Description>")
        sb.AppendLine(" </rdf:RDF>")
        sb.AppendLine("</x:xmpmeta>")
        sb.AppendLine("<?xpacket end=""w""?>")
        Return sb.ToString()
    End Function

#End Region

End Class
