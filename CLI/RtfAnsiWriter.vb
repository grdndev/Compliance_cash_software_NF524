Imports System.Text
Imports System.IO

'état d'écriture des entités RTF :  l'entité que l'on a écrit précédemment
Public Enum RtfWriterState
    'début : rien d'écrit
    Start
    'début d'une groupe : "{"
    StartGroup
    'un caractère : soit sa valeur textuelle, soit "\'XX", soit "\charspecial", soit "\uN..N"
    Character
    'un mot de contrôle : "\controlword"
    ControlWord
    'fin d'une groupe : "}"
    EndGroup
    'fichier RTF fermé
    Closed
End Enum

''' <summary>
''' Définit la base pour un Writer RTF. 
''' </summary>
''' <remarks></remarks>
Public MustInherit Class RtfAnsiWriter
    Private m_WriteState As RtfWriterState

    'définit le buffer en cours d'utilisation
    Private m_CurrentBuffer As StringBuilder

    ''' <summary>
    ''' permet de changer le buffer en cours d'utilisation
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Protected WriteOnly Property CurrentBuffer() As StringBuilder
        Set(ByVal value As StringBuilder)
            m_CurrentBuffer = value
            'on suppose que le buffer est vide
            m_WriteState = RtfWriterState.Start
        End Set
    End Property

    ''' <summary>
    ''' Type d'entité RTF : <see cref="RtfWriterState">Voir RtfWriterState</see>
    ''' </summary>
    ''' <remarks></remarks>
    Protected Enum RtfEntityType
        Character
        ControlWord
        StartGroup
        EndGroup
    End Enum

    ''' <summary>
    ''' Renvoie le type de la dernière entité écrite dans le buffer
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property WriteState() As RtfWriterState
        Get
            Return m_WriteState
        End Get
    End Property

    'écrit une chaine RTF brute
    Private Sub Write(ByVal rawRtf As String)
        m_CurrentBuffer.Append(rawRtf)
    End Sub
    'écrit un caractère RTF brut
    Private Sub Write(ByVal rawRtf As Char)
        m_CurrentBuffer.Append(rawRtf)
    End Sub

    ''' <summary>
    ''' Ecrit une entité RTF dans le buffer
    ''' </summary>
    ''' <param name="rawRtf">chaine contenant l'entité RTF à écrire</param>
    ''' <param name="rtfEntityType">type de cet entité RTF</param>
    ''' <remarks></remarks>
    Protected Sub Write(ByVal rawRtf As String, ByVal rtfEntityType As RtfEntityType)
        'gère l'écriture de l'entité en fonction de l'entité écrite juste avant
        Select Case m_WriteState
            Case RtfWriterState.Character
                'on peut écrire directement derrière un caractère
                Me.Write(rawRtf)
            Case RtfWriterState.Closed
                Throw New InvalidOperationException("The writer is closed")
            Case RtfWriterState.ControlWord
                Select Case rtfEntityType
                    Case RtfAnsiWriter.RtfEntityType.Character
                        'il faut un espace entre un mot de contrôle et un caractère
                        Write(" "c)
                        Write(rawRtf)
                    Case RtfAnsiWriter.RtfEntityType.ControlWord
                        Write(rawRtf)
                    Case RtfAnsiWriter.RtfEntityType.EndGroup
                        Write(rawRtf)
                    Case RtfAnsiWriter.RtfEntityType.StartGroup
                        Write(rawRtf)
                End Select
            Case RtfWriterState.EndGroup
                Write(rawRtf)
            Case RtfWriterState.Start
                Write(rawRtf)
            Case RtfWriterState.StartGroup
                Write(rawRtf)
        End Select
        'définit l'état d'écriture en fonction du type d'entité écrite
        Select Case rtfEntityType
            Case RtfAnsiWriter.RtfEntityType.Character
                m_WriteState = RtfWriterState.Character
            Case RtfAnsiWriter.RtfEntityType.ControlWord
                m_WriteState = RtfWriterState.ControlWord
            Case RtfAnsiWriter.RtfEntityType.EndGroup
                m_WriteState = RtfWriterState.EndGroup
            Case RtfAnsiWriter.RtfEntityType.StartGroup
                m_WriteState = RtfWriterState.StartGroup
        End Select
    End Sub

    ''' <summary>
    ''' Ecrit un mot de contrôle avec argument entier dans une base (il n'existe pas d'autre type d'arguments)
    ''' </summary>
    ''' <param name="controlWord">mot de contrôle</param>
    ''' <param name="arg">argument entier accolé</param>
    ''' <param name="isHexa">indique si l'argument doit être en hexa décimal</param>
    ''' <param name="digits">indique le nombre de digit obligatoire pour l'argument</param>
    ''' <remarks></remarks>
    Public Sub WriteControlWord(ByVal controlWord As String, ByVal arg As Integer, ByVal isHexa As Boolean, ByVal digits As Integer)
        If isHexa Then
            WriteControlWord(String.Format("{0}{1:X" & digits & "}", controlWord, arg))
        Else
            WriteControlWord(String.Format("{0}{1}", controlWord, arg))
        End If
    End Sub
    ''' <summary>
    ''' Ecrit un mot de contrôle avec argument entier écrit en décimal
    ''' </summary>
    ''' <param name="controlWord">mot de contrôle</param>
    ''' <param name="arg">argument entier accolé</param>
    ''' <remarks></remarks>
    Public Sub WriteControlWord(ByVal controlWord As String, ByVal arg As Integer)
        WriteControlWord(controlWord, arg, False, 0)
    End Sub
    ''' <summary>
    ''' Ecrit un mot de contrôle simple
    ''' </summary>
    ''' <param name="controlWord">mot de contrôle</param>
    ''' <remarks></remarks>
    Public Sub WriteControlWord(ByVal controlWord As String)
        Write(String.Format("\{0}", controlWord), RtfEntityType.ControlWord)
    End Sub

    ''' <summary>
    ''' Ecrit un caractère sous forme RTF unicode "\uN..N"
    ''' </summary>
    ''' <param name="c">caractère à écrire</param>
    ''' <remarks></remarks>
    Private Sub WriteUnicodeChar(ByVal c As Char)
        Dim ucod As Integer = AscW(c)
        WriteControlWord("u", ucod)
        m_WriteState = RtfWriterState.Character
        Write("?", RtfEntityType.Character)
    End Sub
    ''' <summary>
    ''' Ecrit un caractère sous forme de caractère spécial RTF : "{", "}", "\"
    ''' </summary>
    ''' <param name="c">caractère à écrire</param>
    ''' <remarks></remarks>
    Private Sub WriteSpecialChar(ByVal c As Char)
        Write(String.Format("\{0}", c), RtfEntityType.Character)
    End Sub

    ''' <summary>
    ''' Ecrit un caractère sous forme RTF ansi "\'XX"
    ''' </summary>
    ''' <param name="c">caractère à écrire</param>
    ''' <remarks></remarks>
    Private Sub WriteAnsiChar(ByVal c As Char)
        Dim ucod As Integer = AscW(c)
        WriteControlWord("'", ucod, True, 2)
        m_WriteState = RtfWriterState.Character
    End Sub
    ''' <summary>
    ''' Ecrit un caractère sous forme RTF
    ''' </summary>
    ''' <param name="c"></param>
    ''' <remarks></remarks>
    Public Sub WriteChar(ByVal c As Char)
        '\\ \{ \}
        Dim ucod As Integer = AscW(c)
        If c = "{" OrElse c = "}" OrElse c = "\" Then
            WriteSpecialChar(c)
        ElseIf ucod > 255 Then
            WriteUnicodeChar(c)
        ElseIf ucod > 127 Then
            WriteAnsiChar(c)
        Else
            Write(c, RtfEntityType.Character)
        End If
    End Sub
    ''' <summary>
    ''' Ecrit une chaine de caractères sous forme RTF
    ''' </summary>
    ''' <param name="s"></param>
    ''' <remarks></remarks>
    Public Sub WriteString(ByVal s As String)
        For Each c As Char In s.ToCharArray()
            WriteChar(c)
        Next
    End Sub

    ''' <summary>
    ''' Ecrit le début d'un groupe
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub WriteStartGroup()
        Me.Write("{", RtfEntityType.StartGroup)
    End Sub
    ''' <summary>
    ''' Ecrit la fin d'un groupe
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub WriteEndGroup()
        Me.Write("}", RtfEntityType.EndGroup)
    End Sub

    ''' <summary>
    ''' Génère le fichier RTF final et ferme le flux
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub Generate()

    ''' <summary>
    ''' Ferme le flux
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub Close()
        m_WriteState = RtfWriterState.Closed
    End Sub
End Class
