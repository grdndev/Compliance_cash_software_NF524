Imports System.Security.Cryptography
Imports System.Text

Namespace NF525
    ''' <summary>
    ''' Module de hachage sécurisé des mots de passe utilisateurs.
    ''' Algorithme : PBKDF2-HMAC-SHA1 (compatible .NET Framework 3.5+)
    ''' Conforme NF525 : les accès aux données fiscales doivent être protégés
    ''' par des mots de passe hachés avec sel (jamais en clair).
    '''
    ''' Format de stockage :
    '''   $pbkdf2sha1v1$<iterations>$<salt_base64>$<hash_base64>
    ''' Exemple :
    '''   $pbkdf2sha1v1$600000$R3h0aW...==$kJlMn...==
    ''' </summary>
    Public Module PasswordHasherNF525

#Region "Constantes"
        Private Const VERSION As String = "pbkdf2sha1v1"
        Private Const SEPARATEUR As String = "$"
        Private Const ITERATIONS As Integer = 600000   ' NIST SP 800-132 : 600 000 pour PBKDF2-SHA1
        Private Const TAILLE_SEL As Integer = 32       ' 256 bits
        Private Const TAILLE_HASH As Integer = 32      ' 256 bits de sortie
#End Region

#Region "API Publique"

        ''' <summary>
        ''' Hache un mot de passe en clair avec PBKDF2 + sel aléatoire.
        ''' À appeler lors de la création ou modification d'un mot de passe.
        ''' </summary>
        ''' <param name="motDePasseClair">Mot de passe en texte clair</param>
        ''' <returns>Hash stockable en base de données (format $pbkdf2sha1v1$...)</returns>
        Public Function HacherMotDePasse(motDePasseClair As String) As String
            If String.IsNullOrEmpty(motDePasseClair) Then
                Throw New ArgumentException("Le mot de passe ne peut pas être vide.")
            End If

            ' Générer un sel aléatoire cryptographiquement sûr
            Dim sel(TAILLE_SEL - 1) As Byte
            Using rng As New RNGCryptoServiceProvider()
                rng.GetBytes(sel)
            End Using

            ' Dériver la clé avec PBKDF2-HMAC-SHA1
            Dim hashBytes As Byte() = DeriverCle(motDePasseClair, sel, ITERATIONS)

            ' Format : $version$iterations$sel_base64$hash_base64
            Return SEPARATEUR & VERSION & SEPARATEUR & _
                   ITERATIONS.ToString() & SEPARATEUR & _
                   Convert.ToBase64String(sel) & SEPARATEUR & _
                   Convert.ToBase64String(hashBytes)
        End Function

        ''' <summary>
        ''' Vérifie un mot de passe en clair contre un hash stocké.
        ''' Utilise une comparaison en temps constant pour éviter les timing attacks.
        ''' </summary>
        ''' <param name="motDePasseClair">Mot de passe saisi par l'utilisateur</param>
        ''' <param name="hashStocke">Hash stocké en base (format $pbkdf2sha1v1$...)</param>
        ''' <returns>True si le mot de passe correspond</returns>
        Public Function VerifierMotDePasse(motDePasseClair As String, hashStocke As String) As Boolean
            Try
                If String.IsNullOrEmpty(motDePasseClair) OrElse String.IsNullOrEmpty(hashStocke) Then
                    Return False
                End If

                ' Vérifier le format attendu
                If Not hashStocke.StartsWith(SEPARATEUR & VERSION) Then
                    Return False
                End If

                ' Décomposer le hash stocké
                Dim parties() As String = hashStocke.Split(New Char() {SEPARATEUR.Chars(0)}, StringSplitOptions.None)
                ' parties = {"", "pbkdf2sha1v1", iterations, sel_b64, hash_b64}
                If parties.Length <> 5 Then Return False

                Dim iterations As Integer = Integer.Parse(parties(2))
                Dim sel As Byte() = Convert.FromBase64String(parties(3))
                Dim hashStockéBytes As Byte() = Convert.FromBase64String(parties(4))

                ' Recalculer le hash avec les mêmes paramètres
                Dim hashCalculé As Byte() = DeriverCle(motDePasseClair, sel, iterations)

                ' Comparaison en temps constant (protection anti timing-attack)
                Return ComparerEnTempsConstant(hashCalculé, hashStockéBytes)

            Catch ex As Exception
                Debug.WriteLine("NF525 - Erreur vérification mot de passe : " & ex.Message)
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Détecte si une valeur est un hash PBKDF2 (format NF525) ou un mot de passe en clair.
        ''' Permet la migration transparente des anciens comptes.
        ''' </summary>
        Public Function EstUnHashNF525(valeur As String) As Boolean
            Return Not String.IsNullOrEmpty(valeur) AndAlso _
                   valeur.StartsWith(SEPARATEUR & VERSION & SEPARATEUR)
        End Function

#End Region

#Region "Fonctions Internes"

        ''' <summary>
        ''' Dérive une clé cryptographique à partir d'un mot de passe et d'un sel.
        ''' Utilise PBKDF2-HMAC-SHA1 (RFC 2898), compatible .NET Framework 3.5+.
        ''' </summary>
        Private Function DeriverCle(motDePasse As String, sel As Byte(), iterations As Integer) As Byte()
            Using pbkdf2 As New Rfc2898DeriveBytes(motDePasse, sel, iterations)
                Return pbkdf2.GetBytes(TAILLE_HASH)
            End Using
        End Function

        ''' <summary>
        ''' Compare deux tableaux d'octets en temps constant.
        ''' Empêche les attaques par analyse du temps de réponse (timing attack).
        ''' </summary>
        Private Function ComparerEnTempsConstant(a As Byte(), b As Byte()) As Boolean
            Dim diff As Integer = a.Length Xor b.Length
            Dim longueurMin As Integer = Math.Min(a.Length, b.Length)
            For i As Integer = 0 To longueurMin - 1
                diff = diff Or (CInt(a(i)) Xor CInt(b(i)))
            Next
            Return diff = 0
        End Function

#End Region

    End Module
End Namespace
