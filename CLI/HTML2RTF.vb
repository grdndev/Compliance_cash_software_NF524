Imports System.IO
Imports System.Text

Public Class HTML2RTF
    'html à parser
    Private m_InputHtml As StringReader
    'générateur de rtf
    Private m_RtfGenerator As RtfAnsiTextWriter
    'stream de sortie du rtf
    Private m_OutputStream As New MemoryStream
    'écrit le contenu texte du rtf dans le stream rtf
    Private m_OutputRTF As StreamWriter
    'pile des font (police, couleur, bg...) utilisés (pour savoir ce que l'on ferme avec un </font>)
    Private m_StackFont As New Stack(Of String)

    Private m_DefaultFont As Font
    ''' <summary>
    ''' Police par défaut
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DefaultFont() As Font
        Get
            Return m_DefaultFont
        End Get
        Set(ByVal value As Font)
            m_DefaultFont = value
        End Set
    End Property

    ''' <summary>
    ''' Parse un pseudo html pour produire du RTF
    ''' </summary>
    ''' <param name="html">pseudo html à parser</param>
    ''' <param name="defaultFont">police par défaut</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal html As String, ByVal defaultFont As Font)
        m_InputHtml = New StringReader(html)
        m_OutputRTF = New StreamWriter(m_OutputStream)
        Me.DefaultFont = defaultFont
        m_RtfGenerator = New RtfAnsiTextWriter(m_OutputRTF, Me.DefaultFont)
        ProcessHTML()
    End Sub

    'parse une couleur au format HTML #RRGGBB ou par le nom de couleur
    Private Function ParseColor(ByVal strColor As String) As Color
        If (strColor.StartsWith("#")) Then
            Return Color.FromArgb(Convert.ToInt32(strColor.Substring(1), 16))
        Else
            Return Color.FromName(strColor)
        End If
    End Function

    ''' <summary>
    ''' convertit le pseudo html en rtf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcessHTML()
        Dim in_ul As Boolean = False
        Dim in_ol As Boolean = False
        While m_InputHtml.Peek() <> -1
            'début de tag
            If (m_InputHtml.Peek() = AscW("<")) Then
                Dim tagHtml As New StringBuilder
                Dim c As Char = ChrW(m_InputHtml.Read())
                Do
                    'lit le tag jusqu'au ">"
                    tagHtml.Append(c)
                    c = ChrW(m_InputHtml.Read)
                Loop While c <> ">"c AndAlso c <> ChrW(-1)
                Dim html As String = tagHtml.ToString()
                Dim end_html As Boolean = False
                Dim arg As String = String.Empty
                'si le tag est un tag fermant
                If html(1) = "/"c Then
                    html = html.Substring(1)
                    end_html = True
                End If
                'si le tag a un argument ou que c'est un tag "<tag />"
                If html.IndexOf(" "c) <> -1 Then
                    arg = html.Substring(html.IndexOf("="c) + 2)
                    'si c'est un tag autonome
                    If arg.IndexOf(""""c) = -1 AndAlso arg(arg.Length - 1) = "/"c Then
                        arg = String.Empty
                        html = html.Substring(1, html.Length - 1 - 2)
                        'si c'est un tag avec argument "<tag prop="value">"
                    Else
                        arg = arg.Substring(0, arg.IndexOf(""""c))
                        html = html.Substring(1, html.IndexOf("="c) - 1)
                    End If
                Else
                    'sinon un tag "<tag>", on retire le "<"
                    html = html.Substring(1)
                End If
                'génère le rtf en fct du tag
                Select Case html
                    'couleur de fond
                    Case "font bgcolor"
                        m_RtfGenerator.BackColor = ParseColor(arg)
                        m_StackFont.Push("bgcolor")
                        'liste à puce/point
                    Case "ul"
                        If Not end_html Then
                            m_RtfGenerator.StartBulletList()
                            in_ul = True
                        Else
                            m_RtfGenerator.EndBulletList()
                            in_ul = False
                        End If
                        'liste numérotée
                    Case "ol"
                        If Not end_html Then
                            in_ol = True
                        Else
                            m_RtfGenerator.EndNumberedListEntry()
                            in_ol = False
                        End If
                        'item de liste
                    Case "li"
                        If Not end_html Then
                            If in_ul Then
                                m_RtfGenerator.NewBulletListEntry()
                            ElseIf in_ol Then
                                m_RtfGenerator.StartNumberedListEntry(1, RtfAnsiTextWriter.Numbering.UpperRoman)
                            End If
                        Else
                            m_RtfGenerator.NewParagraph()
                        End If
                        'gras
                    Case "b"
                        m_RtfGenerator.Bold = Not end_html
                        'taille de police
                    Case "font size"
                        m_RtfGenerator.FontSize = Integer.Parse(arg)
                        m_StackFont.Push("size")
                        'police de caractère
                    Case "font name"
                        m_RtfGenerator.Font = New Font(arg, m_RtfGenerator.FontSize)
                        m_StackFont.Push("name")
                        'couleur de police
                    Case "font color"
                        m_RtfGenerator.ForeColor = ParseColor(arg)
                        m_StackFont.Push("color")
                        'image
                    Case "img src"
                        m_RtfGenerator.InsertImage(Image.FromFile(arg))
                        'italique
                    Case "i"
                        m_RtfGenerator.Italic = Not end_html
                        'smallcaps
                    Case "sc"
                        m_RtfGenerator.SmallCaps = Not end_html
                        'barré
                    Case "strike"
                        m_RtfGenerator.Strikeout = Not end_html
                        'alignement de paragraph
                    Case "div align"
                        Select Case arg
                            Case "right"
                                'aligné à droite
                                m_RtfGenerator.NewParagraph(RtfAnsiTextWriter.Align.Right)
                            Case "center"
                                'centré
                                m_RtfGenerator.NewParagraph(RtfAnsiTextWriter.Align.Center)
                            Case "justify"
                                'justifié
                                m_RtfGenerator.NewParagraph(RtfAnsiTextWriter.Align.Justify)
                            Case Else
                                'aligné à gauche
                                m_RtfGenerator.NewParagraph(RtfAnsiTextWriter.Align.Left)
                        End Select
                        'centré
                    Case "center"
                        m_RtfGenerator.NewParagraph(RtfAnsiTextWriter.Align.Center)
                        'indice
                    Case "sub"
                        m_RtfGenerator.Subscript = Not end_html
                        'exposant
                    Case "sup"
                        m_RtfGenerator.Superscript = Not end_html
                        'souligné
                    Case "u"
                        m_RtfGenerator.Underline = Not end_html
                        'paragraphe
                    Case "div"
                        m_RtfGenerator.NewParagraph()
                        'paragraphe par défaut
                    Case "pard"
                        m_RtfGenerator.NewParagraphDefaultFormat()
                        'retour à la ligne
                    Case "br"
                        m_RtfGenerator.NewLine()
                        'police tag fermant
                    Case "font"
                        'remise police par défaut suivant le cas
                        Select Case m_StackFont.Pop()
                            Case "color"
                                m_RtfGenerator.ForeColor = Color.Black
                            Case "bgcolor"
                                m_RtfGenerator.BackColor = Color.White
                            Case "size"
                                m_RtfGenerator.FontSize = Me.DefaultFont.SizeInPoints
                            Case "name"
                                m_RtfGenerator.Font = Me.DefaultFont
                        End Select

                        'tableau
                    Case "table"
                        'nouveau paragraphe pour un tableau
                        Me.m_RtfGenerator.NewParagraph()
                        'en html l'attribut rows n'existe pas mais il est nécessaire car RTF en a besoin et que l'on ne connait pas le nombre de colonnes à l'avance
                    Case "tr cols"
                        If Not end_html Then
                            m_RtfGenerator.BeginRow()
                            'taille par défaut 100 points
                            For i As Integer = 1 To Integer.Parse(arg)
                                m_RtfGenerator.DeclareCell(100 * 20)
                            Next
                        End If
                        'ligne de tableau
                    Case "tr"
                        If end_html Then
                            m_RtfGenerator.EndRow()
                        End If
                        'contenu de cellule
                    Case "td"
                        If Not end_html Then
                            m_RtfGenerator.BeginCell(True)
                        Else
                            m_RtfGenerator.EndCell()
                        End If
                End Select
            Else
                'caracdtère simple
                m_RtfGenerator.WriteChar(ChrW(m_InputHtml.Read()))
            End If
        End While
        m_RtfGenerator.Generate()
    End Sub

    ''' <summary>
    ''' Renvoie le flux rtf
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetOutput() As Stream
        m_OutputStream.Position = 0
        Return m_OutputStream
    End Function
    ''' <summary>
    ''' Rnvoie une chaine contenant le RTF
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetOutputString() As String
        m_OutputStream.Position = 0
        Dim sr As New StreamReader(m_OutputStream)
        Return sr.ReadToEnd
    End Function
End Class
