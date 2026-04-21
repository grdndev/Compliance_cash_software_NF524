Imports System.Text
Imports System.IO
Imports System.Drawing

''' <summary>
''' Définit un Writer RTF permettant d'écrire un fichier/fragment RTF complet
''' La particularité du RTF est que l'on ne peut pas écrire directement dans un flux
''' car en début de fichier, il y a la table des couleurs et la table des polices
''' Il faut donc écrire séparément dans un buffer distinct toutes les parties du fichier RTF
''' On va donc changer le buffer d'écriture en fonction des besoins
''' 
''' Cette classe gère :
''' -> les polices
''' -> les couleurs de fond/police
''' -> les tailles de police
''' -> italique/gras/sousligné/barré/exposant/indice/smallcaps
''' -> insertion d'image
''' -> liste à points
''' -> liste numérotée (ou titre)
''' -> tableaux
''' </summary>
''' <remarks></remarks>
Public Class RtfAnsiTextWriter
    Inherits RtfAnsiWriter

    '"flux" sous jacent
    Private m_TextWriter As TextWriter

    'attribut des caractères en cours d'écriture
    Private m_ForeColor As Color = Color.Black
    Private m_BackColor As Color = Color.White
    Private m_FontSize As Integer = 30
    Private m_Italic As Boolean = False
    Private m_Bold As Boolean = False
    Private m_Underline As Boolean = False
    Private m_Strikeout As Boolean = False
    Private m_Superscript As Boolean = False
    Private m_Subscript As Boolean = False
    Private m_SmallCaps As Boolean
    'liste des couleurs utilisés (pour le forecolor et le backcolor)
    Private m_ColorTable As New List(Of Color)
    'liste des polices du fichier
    Private m_FontTable As New List(Of Font)
    Private m_DefaultFont As Font
    Private m_Font As Font

    'définit les buffers des différents parties d'un fichier RTF
    Private m_StartBuffer As New StringBuilder
    Private m_ColorTableBuffer As New StringBuilder
    Private m_FontTableBuffer As New StringBuilder
    Private m_BodyBuffer As New StringBuilder
    Private m_EndBuffer As New StringBuilder

    'renvoie l'index d'une couleur dans la table des couleurs RTF
    Private Function GetColorIndex(ByVal color As Color) As Integer
        If Not m_ColorTable.Contains(color) Then
            m_ColorTable.Add(color)
        End If
        Return m_ColorTable.IndexOf(color) + 1
    End Function
    'renvoie l'index d'une police dans la table des polices RTF
    Private Function GetFontIndex(ByVal font As Font) As Integer
        Dim index As Integer = 0
        For Each f As Font In m_FontTable
            If f.Name = font.Name Then Return index
            index += 1
        Next
        m_FontTable.Add(font)
        Return m_FontTable.Count - 1
    End Function

    ''' <summary>
    ''' Nom de la police par défaut
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DefaultFontName() As String
        Get
            Return m_DefaultFont.Name
        End Get
    End Property

#Region "Définition des attributs des caractères suivants"
    ''' <summary>
    ''' Renvoie ou définit si les caractères qui vont être ajoutés seront en SmallCaps ou pas
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SmallCaps() As Boolean
        Get
            Return m_SmallCaps
        End Get
        Set(ByVal value As Boolean)
            If m_SmallCaps <> value Then
                If value Then
                    WriteControlWord("scaps")
                Else
                    WriteControlWord("scaps", 0)
                End If
                m_SmallCaps = value
            End If
        End Set
    End Property
    ''' <summary>
    ''' Renvoie ou définit si les caractères qui vont être ajoutés seront en Indice ou pas
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Subscript() As Boolean
        Get
            Return m_Subscript
        End Get
        Set(ByVal value As Boolean)
            If m_Subscript <> value Then
                If value Then
                    WriteControlWord("sub")
                Else
                    WriteControlWord("nosupersub")
                    'ni sub, ni sup
                    m_Superscript = False
                End If
                m_Subscript = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Renvoie ou définit si les caractères qui vont être ajoutés seront en Exposant ou pas
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Superscript() As Boolean
        Get
            Return m_Superscript
        End Get
        Set(ByVal value As Boolean)
            If m_Superscript <> value Then
                If value Then
                    WriteControlWord("super")
                Else
                    WriteControlWord("nosupersub")
                    'ni sub, ni sup
                    m_Subscript = False
                End If
                m_Superscript = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Renvoie ou définit si les caractères qui vont être ajoutés seront Barrés ou pas
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Strikeout() As Boolean
        Get
            Return m_Strikeout
        End Get
        Set(ByVal value As Boolean)
            If m_Strikeout <> value Then
                If value Then
                    WriteControlWord("strike")
                Else
                    WriteControlWord("strike", 0)
                End If
                m_Strikeout = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Renvoie ou définit si les caractères qui vont être ajoutés seront Soulignés ou pas
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Underline() As Boolean
        Get
            Return m_Underline
        End Get
        Set(ByVal value As Boolean)
            If m_Underline <> value Then
                If value Then
                    WriteControlWord("ul")
                Else
                    WriteControlWord("ul", 0)
                End If
                m_Underline = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Renvoie ou définit si les caractères qui vont être ajoutés seront en Gras ou pas
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Bold() As Boolean
        Get
            Return m_Bold
        End Get
        Set(ByVal value As Boolean)
            If m_Bold <> value Then
                If value Then
                    WriteControlWord("b")
                Else
                    WriteControlWord("b", 0)
                End If
                m_Bold = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Renvoie ou définit si les caractères qui vont être ajoutés seront en Italique ou pas
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Italic() As Boolean
        Get
            Return m_Italic
        End Get
        Set(ByVal value As Boolean)
            If m_Italic <> value Then
                If value Then
                    WriteControlWord("i")
                Else
                    WriteControlWord("i", 0)
                End If
                m_Italic = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Remet la taille de la police à sa taille par défaut pour les caractères qui seront ajoutés par la suite
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub WriteDefaultFontSize()
        WriteControlWord("fs", m_FontSize)
    End Sub

    ''' <summary>
    ''' Renvoie ou définit la taille de la police (en points) pour les caractères qui seront ajoutés par la suite
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FontSize() As Integer
        Get
            Return m_FontSize
        End Get
        Set(ByVal value As Integer)
            'en RTF la taille de la font est en demi points
            value *= 2
            If m_FontSize <> value Then
                WriteControlWord("fs", value)
            End If
            m_FontSize = value
        End Set
    End Property

    ''' <summary>
    ''' Renvoie ou définit la couleur de fond des caractères qui vont être ajoutés
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BackColor() As Color
        Get
            Return m_BackColor
        End Get
        Set(ByVal value As Color)
            If Not m_BackColor.Equals(value) Then
                'si la couleur de fond demandée est : blanc, transparent ou vide
                If value.Equals(Color.White) OrElse value.Equals(Color.Transparent) OrElse value.Equals(Color.Empty) Then
                    'alors plus de fond
                    WriteControlWord("highlight", 0)
                Else
                    'sinon fond de la couleur demandée
                    WriteControlWord("highlight", GetColorIndex(value))
                End If
                m_BackColor = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Renvoie ou définit la couleur de police des caractères qui vont être ajoutés
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ForeColor() As Color
        Get
            Return m_ForeColor
        End Get
        Set(ByVal value As Color)
            'si on demande Transparent alors on suppose que c'est "pas de couleur" donc Noir
            If value = Color.Transparent Then value = Color.Black
            If Not m_ForeColor.ToArgb() = value.ToArgb() Then
                'Noir, Transparent ou Vide -> couleur par défaut Noir
                If value.ToArgb() = Color.Black.ToArgb() _
                    OrElse value.ToArgb() = Color.Transparent.ToArgb() _
                    OrElse value.ToArgb() = Color.Empty.ToArgb() Then
                    WriteControlWord("cf", 0)
                Else
                    WriteControlWord("cf", GetColorIndex(value))
                End If
                m_ForeColor = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Renvoie ou définit la police des caractères qui vont être ajoutés
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Font() As Font
        Get
            Return m_Font
        End Get
        Set(ByVal value As Font)
            'on compare juste avec le nom de la police (seul attribut "utile" de la police dans la table de font)
            If Not m_Font.Name.Equals(value.Name) Then
                'pas de police spécifié =  police et taille par défaut
                If value Is Nothing Then
                    WriteControlWord("f", 0)
                    WriteDefaultFontSize()
                Else
                    'changement de police et de taille
                    WriteControlWord("f", GetFontIndex(value))
                    Me.FontSize = value.SizeInPoints
                End If
                m_Font = value
            End If
        End Set
    End Property
#End Region

    ''' <summary>
    ''' Construit un RTFWriter
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
        'un écrit le contenu du texte, le reste du fichier étant généré à la fin
        Me.CurrentBuffer = m_BodyBuffer
        'la couleur par défaut est noir
        m_ColorTable.Add(Color.Black)
    End Sub

#Region "Constructeurs à partir d'un flux, d'un encoding et d'une police par défaut"
    Private Sub New(ByVal writer As TextWriter)
        Me.New()
        If writer Is Nothing Then Throw New ArgumentNullException("writer")

        m_TextWriter = writer
    End Sub

    Private Sub New(ByVal stream As Stream)
        Me.New()
        If stream Is Nothing Then Throw New ArgumentNullException("stream")

        m_TextWriter = New StreamWriter(stream)
    End Sub

    Private Sub New(ByVal stream As Stream, ByVal enc As Encoding)
        Me.New()
        If stream Is Nothing Then Throw New ArgumentNullException("stream")

        m_TextWriter = New StreamWriter(stream, enc)
    End Sub

    Public Sub New(ByVal writer As TextWriter, ByVal defaultFont As Font)
        Me.New(writer)
        m_DefaultFont = defaultFont
        m_Font = m_DefaultFont
        m_FontTable.Add(m_Font)
    End Sub

    Public Sub New(ByVal stream As Stream, ByVal defaultFont As Font)
        Me.New(stream)
        m_DefaultFont = defaultFont
        m_Font = m_DefaultFont
        m_FontTable.Add(m_Font)
    End Sub

    Public Sub New(ByVal stream As Stream, ByVal enc As Encoding, ByVal defaultFont As Font)
        Me.New(stream, enc)
        m_DefaultFont = defaultFont
        m_Font = m_DefaultFont
        m_FontTable.Add(m_Font)
    End Sub
#End Region

    ''' <summary>
    ''' génère le fichier RTF final et l'écrit dans le flux texte sous jacent
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Generate()
        'ces attributs de caractère étant dans des groupes, il faut être sûr de bien les fermer s'ils sont ouverts
        Me.Subscript = False
        Me.Superscript = False

        'un fichier RTF se compose de (impérativement dans l'ordre) :
        '-> une entête avec l'encoding, la police par défaut, la langue
        Me.CurrentBuffer = m_StartBuffer
        Me.WriteStartGroup()
        Me.WriteControlWord("rtf", 1)
        Me.WriteControlWord("ansi")
        Me.WriteControlWord("ansicpg", System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ANSICodePage)
        Me.WriteControlWord("deff", 0)
        Me.WriteControlWord("deflang", System.Threading.Thread.CurrentThread.CurrentUICulture.LCID)

        '-> la table des polices
        Me.CurrentBuffer = m_FontTableBuffer
        Me.WriteStartGroup()
        Me.WriteControlWord("fonttbl")

        Dim i As Integer = 0
        For Each f As System.Drawing.Font In m_FontTable
            Me.WriteStartGroup()
            Me.WriteControlWord("f", i)
            Me.WriteControlWord("fnil")
            Me.WriteControlWord("fcharset", f.GdiCharSet())
            Me.WriteString(f.Name)
            Me.WriteChar(";"c)
            Me.WriteEndGroup()

            i += 1
        Next
        Me.WriteEndGroup()

        '-> la table des couleurs
        Me.CurrentBuffer = m_ColorTableBuffer
        Me.WriteStartGroup()
        Me.WriteControlWord("colortbl")
        Me.WriteChar(";"c)
        For Each col As System.Drawing.Color In m_ColorTable
            Me.WriteControlWord("red", col.R)
            Me.WriteControlWord("green", col.G)
            Me.WriteControlWord("blue", col.B)
            Me.WriteChar(";"c)
        Next
        Me.WriteEndGroup()

        'indique le générateur du RTF
        Me.WriteStartGroup()
        Me.WriteControlWord("*")
        Me.WriteControlWord("generator")
        Me.WriteString("ShareVB RTF Generator")
        Me.WriteEndGroup()

        '->le texte
        'déjà remplit

        '->la fin
        Me.CurrentBuffer = m_EndBuffer
        Me.WriteEndGroup()

        'écriture de tous les buffers dans le flux sous jacent
        m_TextWriter.Write(m_StartBuffer)
        m_TextWriter.Write(m_FontTableBuffer)
        m_TextWriter.Write(m_ColorTableBuffer)
        m_TextWriter.Write(m_BodyBuffer)
        m_TextWriter.Write(m_EndBuffer)
        m_TextWriter.Flush()
    End Sub

    ''' <summary>
    ''' renvoie une chaine contenant le body du document RTF
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBody() As String
        Return m_BodyBuffer.ToString()
    End Function

#Region "Paragraphe"
    ''' <summary>
    ''' Alignement d'un paragraphe
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Align
        Left
        Center
        Right
        Justify
    End Enum
    ''' <summary>
    ''' Crée un nouveau paragraphe
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub NewParagraph()
        Me.WriteControlWord("par")
        'si on est dans un tableau, on l'indique
        If m_InTbl Then
            Me.WriteControlWord("intbl")
        End If
    End Sub
    ''' <summary>
    ''' Crée un nouveau paragraphe avec un alignement donné
    ''' </summary>
    ''' <param name="align">Alignement du paragraphe</param>
    ''' <remarks></remarks>
    Public Sub NewParagraph(ByVal align As Align)
        Me.NewParagraph()
        Select Case align
            Case RtfAnsiTextWriter.Align.Center
                Me.WriteControlWord("qc")
            Case RtfAnsiTextWriter.Align.Right
                Me.WriteControlWord("qr")
            Case RtfAnsiTextWriter.Align.Left
                Me.WriteControlWord("ql")
            Case RtfAnsiTextWriter.Align.Justify
                Me.WriteControlWord("qj")
        End Select
    End Sub
    ''' <summary>
    ''' Crée un nouveau paragraphe avec un alignement et une police donné
    ''' </summary>
    ''' <param name="align">Alignement du paragraphe</param>
    ''' <param name="font">Police du paragraphe</param>
    ''' <remarks></remarks>
    Public Sub NewParagraph(ByVal align As Align, ByVal font As Font)
        Me.NewParagraph(align)
        Me.Font = font
    End Sub
    ''' <summary>
    ''' Crée un nouveau paragraphe avec le format par défaut
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub NewParagraphDefaultFormat()
        Me.WriteControlWord("pard")
        'si on est dans un tableau, on l'indique
        If m_InTbl Then
            Me.WriteControlWord("intbl")
        End If
    End Sub
#End Region

#Region "Liste à points"
    ''' <summary>
    ''' Crée un nouvelle liste à point
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartBulletList()
        'commence par une nouvelle entrée à point
        Me.NewBulletListEntry()
        'puis les attributs de la liste à point
        Me.WriteStartGroup()
        Me.WriteControlWord("*")
        Me.WriteControlWord("pn")
        'liste à points
        Me.WriteControlWord("pnlvlblt")
        Me.WriteControlWord("pnf", GetFontIndex(New Font("Symbol", 12)))
        Me.WriteControlWord("pnindent", 0)
        'caractère "point"
        Me.WriteStartGroup()
        Me.WriteControlWord("pntxtb")
        Me.WriteChar(ChrW(&HB7))
        Me.WriteEndGroup()
        Me.WriteEndGroup()
        'marges
        Me.WriteControlWord("fi", -720)
        Me.WriteControlWord("li", 720)
    End Sub
    ''' <summary>
    ''' Crée une nouvelle entrée à points
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub NewBulletListEntry()
        Me.WriteStartGroup()
        Me.WriteControlWord("pntext")
        Me.WriteControlWord("f", GetFontIndex(New Font("Symbol", 12)))
        Me.WriteChar(ChrW(&HB7))
        Me.InsertTab()
        Me.WriteEndGroup()
    End Sub
    ''' <summary>
    ''' Termine une liste à points
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EndBulletList()
        Me.WriteControlWord("pard")
    End Sub
#End Region

#Region "Liste numérotée"
    ''' <summary>
    ''' Type de numéro
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Numbering
        Cardinal
        [Decimal]
        UpperAlpha
        UpperRoman
        LowerAlpha
        LowerRoman
        Ordinal
        OrdinalText
    End Enum
    ''' <summary>
    ''' Commence une nouvelle entrée de liste numérotée au niveau donné (1-9) et pour un type de numérotation donné
    ''' </summary>
    ''' <param name="level">Niveau de la numérotation (1-9)</param>
    ''' <param name="numb">Type de numérotation</param>
    ''' <remarks></remarks>
    Public Sub StartNumberedListEntry(ByVal level As Integer, ByVal numb As Numbering)
        Me.NewBulletListEntry()
        Me.WriteStartGroup()
        Me.WriteControlWord("*")
        Me.WriteControlWord("pn")
        'liste numérotée
        Me.WriteControlWord("pnlvl", level)
        Me.WriteControlWord("pnf", 0)
        Me.WriteControlWord("pnindent", 0)
        Me.WriteStartGroup()

        'type de numéro
        Select Case numb
            Case Numbering.Cardinal
                Me.WriteControlWord("pncard")
            Case Numbering.Decimal
                Me.WriteControlWord("pndec")
            Case Numbering.LowerAlpha
                Me.WriteControlWord("pnlcltr")
            Case Numbering.LowerRoman
                Me.WriteControlWord("pnlcrm")
            Case Numbering.Ordinal
                Me.WriteControlWord("pnord")
            Case Numbering.OrdinalText
                Me.WriteControlWord("pnordt")
            Case Numbering.UpperAlpha
                Me.WriteControlWord("pnucltr")
            Case Numbering.UpperRoman
                Me.WriteControlWord("pnucrm")
        End Select

        Me.WriteEndGroup()
        Me.WriteEndGroup()
        'marges
        Me.WriteControlWord("fi", -720)
        Me.WriteControlWord("li", 720)
    End Sub
    ''' <summary>
    ''' Termine une entrée de liste numérotée
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EndNumberedListEntry()
        Me.WriteControlWord("pard")
        Me.WriteControlWord("par")
    End Sub
#End Region

#Region "Gestion des images"
    'Type de transformation EMF vers WMF
    Private Enum EmfToWmfBitsFlags
        EmfToWmfBitsFlagsDefault = &H0
        EmfToWmfBitsFlagsEmbedEmf = &H1
        EmfToWmfBitsFlagsIncludePlaceable = &H2
        EmfToWmfBitsFlagsNoXORClip = &H4
    End Enum

    'Convertit un EMF en WMF et renvoie les octets du WMF
    Private Declare Function GdipEmfToWmfBits Lib "gdiplus.dll" (ByVal hEmf As IntPtr, _
        ByVal bufferSize As Integer, <System.Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.LPArray)> ByVal buffer() As Byte, _
        ByVal mappingMode As Integer, ByVal flags As EmfToWmfBitsFlags) As Integer
    Private Declare Function GdipEmfToWmfBits Lib "gdiplus.dll" (ByVal hEmf As IntPtr, _
        ByVal bufferSize As Integer, ByVal buffer As IntPtr, _
        ByVal mappingMode As Integer, ByVal flags As EmfToWmfBitsFlags) As Integer
    Private Const MM_ANISOTROPIC As Integer = 8

    ''' <summary>
    ''' Insère une image dans le RTF (méthode de Word)
    ''' </summary>
    ''' <param name="image">Image à insérer</param>
    ''' <remarks></remarks>
    Public Sub InsertImage(ByVal image As Image)
        'crée un stream pour contenir le EMF
        Dim metaStream As New MemoryStream()
        'fichier EMF créé
        Dim metaFile As System.Drawing.Imaging.Metafile

        'contrôle qui va servir à créer un fichier EMF
        Dim ctrl As New Control
        'crée un Graphics à partir du contrôle
        Using g As Graphics = ctrl.CreateGraphics
            'récupère le HDC du Graphics
            Dim hDc As IntPtr = g.GetHdc
            'crée un nouveau fichier EMF à partir d'un stream de stockage et du HDC du contrôle de référence
            'on ne peut pas créé un fichier EMF autrement
            metaFile = New System.Drawing.Imaging.Metafile(metaStream, hDc)
            'libère le HDC
            g.ReleaseHdc(hDc)
        End Using
        ctrl.Dispose()

        'crée un Graphics pour dessiner sur le EMF
        Using g As Graphics = Graphics.FromImage(metaFile)
            'dessine l'image donnée dans l'EMF 
            g.DrawImage(image, 0, 0, image.Width, image.Height)
        End Using

        'calcule la taille originale de l'image en centième de pouce (unit 0,01 inches)
        Dim picw As Integer, pich As Integer
        picw = image.Width / metaFile.HorizontalResolution * 100
        pich = image.Height / metaFile.VerticalResolution * 100

        'calcule la taille de l'image dans le RTF en twips (unit 1/1440 inch)
        'le twip est une unité indépendante de la résolution permettant de respecter un ratio (contrairement au pixel)
        Dim picwgoal As Integer, pichgoal As Integer
        picwgoal = image.Width / metaFile.HorizontalResolution * 1440
        pichgoal = image.Height / metaFile.VerticalResolution * 1440

        'récupèe le handle du EMF
        Dim hMeta As IntPtr = metaFile.GetHenhmetafile
        'récupère la taille des données WMF converties
        Dim bufferSize As Integer = GdipEmfToWmfBits(hMeta, 0, IntPtr.Zero, _
            MM_ANISOTROPIC, EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault)

        'crée un buffer de la taille demandée
        Dim buffer(bufferSize - 1) As Byte
        'convertit l'EMF en WMF et récupère les octets de la conversion dans le buffer
        GdipEmfToWmfBits(hMeta, bufferSize, buffer, _
            MM_ANISOTROPIC, EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault)

        'écrit l'image
        Me.WriteStartGroup()
        Me.WriteControlWord("pict")
        'WMF => comme ce que fait Word
        Me.WriteControlWord("wmetafile", 8)
        'taille originale
        Me.WriteControlWord("picw", picw)
        Me.WriteControlWord("pich", pich)
        'taille attendue dans le RTF
        Me.WriteControlWord("picwgoal", picwgoal)
        Me.WriteControlWord("pichgoal", pichgoal)
        'place tous les octets en hexa
        For i As Integer = 0 To buffer.Length - 1
            Me.WriteString(String.Format("{0:X2}", buffer(i)))
        Next
        Me.WriteEndGroup()
    End Sub
#End Region

#Region "Caractères spéciaux"
    ''' <summary>
    ''' Crée une nouvelle ligne
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub NewLine()
        Me.WriteControlWord("line")
    End Sub
    ''' <summary>
    ''' Crée une tabulation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InsertTab()
        Me.WriteControlWord("tab")
    End Sub
    ''' <summary>
    ''' Crée un tiret insecable
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InsertNonBreakingHyphen()
        Me.WriteControlWord("_")
    End Sub
    ''' <summary>
    ''' Crée un tiret optionel
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InsertOptionalHyphen()
        Me.WriteControlWord("-")
    End Sub
    ''' <summary>
    ''' Crée un espace insecable
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InsertNonBreakingSpace()
        Me.WriteControlWord("~")
    End Sub
    ''' <summary>
    ''' Crée une guillemet simple ou double
    ''' </summary>
    ''' <param name="left">guillemet gauche (true) ou droit (false)</param>
    ''' <param name="doubleQuote">guillemet simple (false) = apostrophe, guillemet double (true)</param>
    ''' <remarks></remarks>
    Public Sub InsertQuote(ByVal left As Boolean, ByVal doubleQuote As Boolean)
        If doubleQuote Then
            If left Then
                Me.WriteControlWord("ldblquote")
            Else
                Me.WriteControlWord("rdblquote")
            End If
        Else
            If left Then
                Me.WriteControlWord("lquote")
            Else
                Me.WriteControlWord("rquote")
            End If
        End If
        Me.WriteControlWord("tab")
    End Sub
    ''' <summary>
    ''' Insère un point de liste
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InsertBullet()
        Me.WriteControlWord("bullet")
    End Sub
    ''' <summary>
    ''' Insère un saut de page
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub NewPage()
        Me.WriteControlWord("page")
    End Sub
    ''' <summary>
    ''' Insère la date du jour
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InsertDate()
        Me.WriteControlWord("chdate")
    End Sub
    ''' <summary>
    ''' Insère l'heure courante
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InsertTime()
        Me.WriteControlWord("chtime")
    End Sub
    ''' <summary>
    ''' Insère la date du jour au format abbrégé ("Thu, Oct 28, 1997")
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InsertDateAbbr()
        Me.WriteControlWord("chdpa")
    End Sub
    ''' <summary>
    ''' Insère la date du jour au format long ("Thursday, October 28, 1997")
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InsertDateLong()
        Me.WriteControlWord("chdpl")
    End Sub
    ''' <summary>
    ''' Insère un numéro de page
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InsertPageNumber()
        Me.WriteControlWord("chpgn")
    End Sub
    ''' <summary>
    ''' Insère un tiret
    ''' </summary>
    ''' <param name="mSize">true pour un tiret de la taille d'un "m", false pour un tiret de la taille d'un "n"</param>
    ''' <remarks></remarks>
    Public Sub InsertDash(ByVal mSize As Boolean)
        If mSize Then
            Me.WriteControlWord("emdash")
        Else
            Me.WriteControlWord("endash")
        End If
    End Sub

    'ferme le flux sous jacent
    Public Overrides Sub Close()
        MyBase.Close()
        m_TextWriter.Close()
    End Sub
#End Region

#Region "Basic Table"
    'position du bord droit de la cellule précédente (reinit à chaque ligne)
    Private m_RightBorder As Integer = 0
    'indique si on est dans une ligne d'un tableau pour insérer \intbl lors d'un nouveau paragraphe
    Private m_InTbl As Boolean = False

    ''' <summary>
    ''' Crée une nouvelle ligne de tableau (permet aussi de commencer un tableau)
    ''' </summary>
    ''' <param name="cellSpacing">demi espace entre les cellules (en twips)</param>
    ''' <param name="rowPaddingLeft">padding ou margin gauche de la ligne (en twips)</param>
    ''' <param name="rowPaddingRight">padding ou margin droite de la ligne (en twips)</param>
    ''' <param name="rowPaddingTop">padding ou margin haute de la ligne (en twips)</param>
    ''' <param name="rowPaddingBottom">padding ou margin basse de la ligne (en twips)</param>
    ''' <remarks></remarks>
    Public Sub BeginRow( _
            Optional ByVal cellSpacing As Integer = 70, _
            Optional ByVal rowPaddingLeft As Integer = 70, _
            Optional ByVal rowPaddingRight As Integer = 70, _
            Optional ByVal rowPaddingTop As Integer = 70, _
            Optional ByVal rowPaddingBottom As Integer = 70)
        Me.WriteControlWord("trowd")
        Me.WriteControlWord("trgaph", cellSpacing)
        Me.WriteControlWord("trpaddl", rowPaddingLeft)
        Me.WriteControlWord("trpaddr", rowPaddingRight)
        Me.WriteControlWord("trpaddt", rowPaddingTop)
        Me.WriteControlWord("trpaddb", rowPaddingBottom)
        Me.WriteControlWord("trpaddfl", 3)
        Me.WriteControlWord("trpaddfr", 3)
        Me.WriteControlWord("trpaddft", 3)
        Me.WriteControlWord("trpaddfb", 3)
        Me.Write(vbCrLf, RtfEntityType.ControlWord)

        m_RightBorder = 0
        m_InTbl = True
    End Sub

    ''' <summary>
    ''' Alignement vertical de la cellule
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum VerticalAlign
        Top
        Middle
        Bottom
    End Enum
    ''' <summary>
    ''' Déclare le format d'une cellule d'une ligne. Les cellules doivent être déclarées avant de les remplir
    ''' </summary>
    ''' <param name="cellWidth">taille de la cellule (en twips)</param>
    ''' <param name="borderColorsARGB">couleur (sous forme ARGB) des bordures de la cellule</param>
    ''' <param name="verticalAlign">alignement vertical de la cellule</param>
    ''' <param name="leftBorderWidth">épaisseur de la bordure gauche de la cellule (en twips), 0 pour ne pas mettre de bordure</param>
    ''' <param name="rightBorderWidth">épaisseur de la bordure droite de la cellule (en twips), 0 pour ne pas mettre de bordure</param>
    ''' <param name="topBorderWidth">épaisseur de la bordure haute de la cellule (en twips), 0 pour ne pas mettre de bordure</param>
    ''' <param name="bottomBorderWidth">épaisseur de la bordure basse de la cellule (en twips), 0 pour ne pas mettre de bordure</param>
    ''' <remarks></remarks>
    Public Sub DeclareCell(ByVal cellWidth As Integer, _
            Optional ByVal borderColorsARGB As Integer = &HFF000000, _
            Optional ByVal verticalAlign As VerticalAlign = VerticalAlign.Top, _
            Optional ByVal leftBorderWidth As Integer = 10, _
            Optional ByVal rightBorderWidth As Integer = 10, _
            Optional ByVal topBorderWidth As Integer = 10, _
            Optional ByVal bottomBorderWidth As Integer = 10)

        Select Case verticalAlign
            Case RtfAnsiTextWriter.VerticalAlign.Top
                Me.WriteControlWord("clvertalt")
            Case RtfAnsiTextWriter.VerticalAlign.Middle
                Me.WriteControlWord("clvertalc")
            Case RtfAnsiTextWriter.VerticalAlign.Bottom
                Me.WriteControlWord("clvertalb")
        End Select
        If leftBorderWidth > 0 AndAlso leftBorderWidth <= 75 Then
            Me.WriteControlWord("clbrdrl")
            Me.WriteControlWord("brdrw", leftBorderWidth)
            Me.WriteControlWord("brdrs")
            Me.WriteControlWord("brdrcf", GetColorIndex(Color.FromArgb(borderColorsARGB)))
        End If
        If rightBorderWidth > 0 AndAlso rightBorderWidth <= 75 Then
            Me.WriteControlWord("clbrdrt")
            Me.WriteControlWord("brdrw", rightBorderWidth)
            Me.WriteControlWord("brdrs")
            Me.WriteControlWord("brdrcf", GetColorIndex(Color.FromArgb(borderColorsARGB)))
        End If
        If topBorderWidth > 0 AndAlso topBorderWidth <= 75 Then
            Me.WriteControlWord("clbrdrr")
            Me.WriteControlWord("brdrw", topBorderWidth)
            Me.WriteControlWord("brdrs")
            Me.WriteControlWord("brdrcf", GetColorIndex(Color.FromArgb(borderColorsARGB)))
        End If
        If bottomBorderWidth > 0 AndAlso bottomBorderWidth <= 75 Then
            Me.WriteControlWord("clbrdrb")
            Me.WriteControlWord("brdrw", bottomBorderWidth)
            Me.WriteControlWord("brdrs")
            Me.WriteControlWord("brdrcf", GetColorIndex(Color.FromArgb(borderColorsARGB)))
        End If

        Me.Write(" ", RtfEntityType.ControlWord)
        'indique la position de la bordure droite de la cellule
        m_RightBorder += cellWidth
        Me.WriteControlWord("cellx", m_RightBorder)
        Me.Write(vbCrLf, RtfEntityType.ControlWord)
    End Sub

    ''' <summary>
    ''' Commence le contenu d'une cellule
    ''' </summary>
    ''' <param name="newParagraph">True pour commencer un nouveau paragraphe (format par défaut) dans la cellule</param>
    ''' <remarks></remarks>
    Public Sub BeginCell(ByVal newParagraph As Boolean)
        If newParagraph Then
            'nouveau paragraph
            Me.NewParagraphDefaultFormat()
        Else
            'sinon contenu simplement dans la cellule
            Me.WriteControlWord("intbl")
        End If
    End Sub
    ''' <summary>
    ''' Termine le contenu d'une cellule
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EndCell()
        Me.WriteControlWord("cell")
    End Sub
    ''' <summary>
    ''' Termine une ligne de tableau
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EndRow()
        Me.WriteControlWord("row")
        m_InTbl = False
    End Sub
#End Region

End Class
