Public NotInheritable Class SplashScreen

    Private Sub SplashScreen_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    End Sub

    'TODO : ce formulaire peut facilement être configuré comme écran de démarrage de l'application en accédant à l'onglet "Application"
    '  du Concepteur de projets ("Propriétés" sous le menu "Projet").


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Configurez le texte de la boîte de dialogue au moment de l'exécution en fonction des informations d'assembly de l'application.  

        'TODO : personnalisez les informations d'assembly de l'application dans le volet "Application" de la 
        '  boîte de dialogue Propriétés du projet (sous le menu "Projet").

        'Titre de l'application
        'If My.Application.Info.Title <> "" Then
        '    ApplicationTitle.Text = My.Application.Info.Title
        'Else
        '    'Si le titre de l'application est absent, utilisez le nom de l'application, sans l'extension
        '    ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        'End If

        'Mettez en forme les informations de version à l'aide du texte défini dans le contrôle Version au moment du design en tant que
        '  chaîne de mise en forme. Ceci permet une localisation efficace si besoin est.
        '  Les informations de génération et de révision peuvent être incluses en utilisant le code suivant et en remplaçant le 
        '  texte du contrôle de version par "Version {0}.{1:00}.{2}.{3}" ou un équivalent. Voir
        '  String.Format() dans l'aide pour plus d'informations.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        Me.Opacity = 0
        Version.Text = My.Application.Info.Version.ToString

        'Informations de copyright
        Copyright.Text = My.Application.Info.Copyright
        Timer1.Start()


    End Sub

    Private Sub MainLayoutPanel_MouseCaptureChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.Opacity <= 100 Then
            Me.Opacity = Me.Opacity + 0.01
        End If
    End Sub




    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.Close()
    End Sub

    Private Sub SplashScreen_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Me.Close()
    End Sub

   


End Class
