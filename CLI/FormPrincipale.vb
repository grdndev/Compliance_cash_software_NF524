' A faire
' gestion du login
' gestion de la chaine de connexion de l'appli --> non
' gestion d'erreur
' #####Articles
' D�placer programme et type --> ok
' Ajout des familles sous familles --> ok
' fermer form si plus d'enregistrements --> ok
' bouton refresh avec les familles sous famille --> ok
' limiter la recherche (afficher message warning) --> non
' impression codes barre --> ok
' description Auto tous les rayons -> ok
' bouton ajouter un fournisseur dans article-->ok
' bouton mettre au panier CA dans article
' gestion des valeurs nulles dans les numeric -> ok
' valeurs par d�faut dans les champs bool�ens (RDM etc...) --> ok
' Ajout nombre d'articles dans les entetes, version et possibilit� de les voir (crit�res de recherche) --> ok
' ajout de tous les champs possibles en fonction des rayons --> ok
' ajout des champs obligatoires --> ok
' Supprimer fournisser menu contextuel
' recherche articles par fournisseur --> ok
' recherche articles par ref fournisseur --> Ok
' controles avant suppression (parents enfants)-->Ok
' controle menu contextuel (si pas d'enregistrements)
' gestion droits d'acc�s (stock, champs en lecture seule, menus)
' gestion des packs
' gestion des occasions--> Ok
' gestion des depots ventes--> Ok
' gestion des avoirs--> Ok
' module client--> Ok
' module fournisseur --> ok
' module caisse --> Ok


Imports Microsoft.PointOfService
Imports System.IO
Imports System.Globalization
Imports System.Text
Imports Newtonsoft.Json
Imports DocumentFormat.OpenXml.Vml.Spreadsheet

Public Class FormPrincipale

    Private Sub FormPrincipale_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing


        If m_Display Is Nothing Then
            Return
        End If

        Try
            m_Display.ClearText()

            'Cancel the device
            m_Display.DeviceEnabled = False
            m_Drawer.DeviceEnabled = False
            m_Printer.DeviceEnabled = False
            'Release the device exclusive control right.
            m_Display.Release()
            m_Drawer.Release()
            m_Printer.Release()
        Catch ex As PosControlException

        Finally
            'Finish using the device.
            Try
                m_Display.Close()
                m_Drawer.Close()
                m_Printer.Close()
            Catch ex As Exception

            End Try

        End Try
    End Sub

    Private Sub FormPrincipale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'cr�ation du r�pertoire c:\temp\cli s'il n'existe pas
        If Not My.Computer.FileSystem.DirectoryExists(gChemin_local_vignette) Then
            My.Computer.FileSystem.CreateDirectory(gChemin_local_vignette)
        End If

        Me.Text = My.Application.Info.Title & " " & My.Application.Info.Version.ToString

        ' ✅ NF525 : Démarrage logiciel obligatoirement tracé dans le JET
        Try
            LogEventTechnique("DEMARRAGE",
                             "Démarrage logiciel CHINOOK LEUCATE CLI " & My.Application.Info.Version.ToString(),
                             "", "Machine: " & Environment.MachineName & " | OS: " & Environment.OSVersion.ToString())
        Catch
            ' Ne jamais bloquer le démarrage si le JET est indisponible
        End Try

    End Sub

    Private Sub QuitterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitterToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AProposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AProposToolStripMenuItem.Click
        SplashScreen.Close()
        SplashScreen.ShowDialog()

    End Sub

    Private Sub RechercheToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechercheToolStripMenuItem.Click

        FormArticleRecherche.MdiParent = Me

        FormArticleRecherche.Show()
        FormArticleRecherche.WindowState = FormWindowState.Normal
        FormArticleRecherche.BringToFront()

    End Sub

    Private Sub Param�tresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Param�tresToolStripMenuItem.Click


    End Sub

    Private Sub G�n�ralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G�n�ralToolStripMenuItem.Click
        FormParamsGene.MdiParent = Me
        FormParamsGene.Show()
        FormParamsGene.WindowState = FormWindowState.Normal
        FormParamsGene.BringToFront()
    End Sub

    Private Sub CodeTVAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodeTVAToolStripMenuItem.Click
        FormParamTva.MdiParent = Me
        FormParamTva.Show()
        FormParamTva.WindowState = FormWindowState.Normal
        FormParamTva.BringToFront()

    End Sub

    Private Sub CodePortToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodePortToolStripMenuItem.Click
        FormParamsCodesPortPays.MdiParent = Me
        FormParamsCodesPortPays.Show()
        FormParamsCodesPortPays.WindowState = FormWindowState.Normal
        FormParamsCodesPortPays.BringToFront()
    End Sub

    Private Sub PaysToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaysToolStripMenuItem.Click
        FormPays.MdiParent = Me
        FormPays.Show()
        FormPays.WindowState = FormWindowState.Normal
        FormPays.BringToFront()
    End Sub

    Private Sub NouveauToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauArticleToolStripMenuItem2.Click
        FormArticleRecherche.MdiParent = Me
        FormArticleRecherche.Show()
        FormArticleRecherche.WindowState = FormWindowState.Normal
        FormArticleRecherche.BringToFront()
        FormArticleRecherche.Nouvel_article()
    End Sub

    Private Sub RechercheToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechercheToolStripMenuItem1.Click
        FormFournisseurRecherche.MdiParent = Me

        FormFournisseurRecherche.Show()
        FormFournisseurRecherche.WindowState = FormWindowState.Normal
        FormFournisseurRecherche.BringToFront()
    End Sub

    Private Sub NouveauToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauFournisseurToolStripMenuItem.Click
        FormFournisseurRecherche.MdiParent = Me
        FormFournisseurRecherche.Show()
        FormFournisseurRecherche.WindowState = FormWindowState.Normal
        FormFournisseurRecherche.BringToFront()
        FormFournisseurRecherche.Nouvelle_Fiche()
    End Sub

    Private Sub CaisseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RechercheToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechercheToolStripMenuItem2.Click
        FormCommandeRecherche.MdiParent = Me
        FormCommandeRecherche.Show()
        FormCommandeRecherche.WindowState = FormWindowState.Normal
        FormCommandeRecherche.BringToFront()
    End Sub

    Private Sub FormPrincipale_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Application.DoEvents()
        FormInitialisation.ShowDialog()
    End Sub

    Private Sub NouvelleToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouvelleCommandeToolStripMenuItem2.Click
        FormCaisse.MdiParent = Me
        FormCaisse.Show()
        FormCaisse.WindowState = FormWindowState.Normal
        FormCaisse.BringToFront()
    End Sub

    Private Sub RechercheToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechercheToolStripMenuItem5.Click
        FormClientRecherche.MdiParent = Me
        FormClientRecherche.Show()
        FormClientRecherche.WindowState = FormWindowState.Normal
        FormClientRecherche.BringToFront()
    End Sub

    Private Sub NouveauToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauClientToolStripMenuItem1.Click
        FormClientRecherche.MdiParent = Me
        FormClientRecherche.Show()
        FormClientRecherche.WindowState = FormWindowState.Normal
        FormClientRecherche.BringToFront()
        FormClientRecherche.Nouvelle_Fiche()
    End Sub

    Private Sub ListeUtilisateursToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListeUtilisateursToolStripMenuItem.Click
        FormUser.MdiParent = Me
        FormUser.Show()
        FormUser.WindowState = FormWindowState.Normal
        FormUser.BringToFront()
    End Sub

    Private Sub ListeProfilsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListeProfilsToolStripMenuItem.Click
        FormProfil.MdiParent = Me
        FormProfil.Show()
        FormProfil.WindowState = FormWindowState.Normal
        FormProfil.BringToFront()
    End Sub

    Private Sub FamillesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FamillesToolStripMenuItem.Click
        FormFamille.MdiParent = Me
        FormFamille.Show()
        FormFamille.WindowState = FormWindowState.Normal
        FormFamille.BringToFront()
    End Sub

    Private Sub SousFamillesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SousFamillesToolStripMenuItem.Click
        FormSousFamille.MdiParent = Me
        FormSousFamille.Show()
        FormSousFamille.WindowState = FormWindowState.Normal
        FormSousFamille.BringToFront()
    End Sub

    Private Sub ChangerDidentificationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangerDidentificationToolStripMenuItem.Click
        Dim f As Form
        For Each f In Me.MdiChildren
            f.Close()
        Next
        FormIdentification.ShowDialog()
    End Sub

    Private Sub NewsLetterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewsLetterToolStripMenuItem.Click
        FormNewsLetter.MdiParent = Me
        FormNewsLetter.Show()
        FormNewsLetter.WindowState = FormWindowState.Normal
        FormNewsLetter.BringToFront()
    End Sub
    Private Sub ExtractionNewsletterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtractionNewsletterToolStripMenuItem.Click
        FormNewsLetterView.MdiParent = Me
        FormNewsLetterView.Show()
        FormNewsLetterView.WindowState = FormWindowState.Normal
        FormNewsLetterView.BringToFront()
    End Sub

    Private Sub AttaquesSQLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttaquesSQLToolStripMenuItem.Click
        FormAttaques.MdiParent = Me
        FormAttaques.Show()
        FormAttaques.WindowState = FormWindowState.Normal
        FormAttaques.BringToFront()
    End Sub

    Private Sub ModeR�glementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModeR�glementToolStripMenuItem.Click
        FormModeReglement.MdiParent = Me
        FormModeReglement.Show()
        FormModeReglement.WindowState = FormWindowState.Normal
        FormModeReglement.BringToFront()
    End Sub

    Private Sub MoyenPaiementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoyenPaiementToolStripMenuItem.Click
        FormMoyenPaiement.MdiParent = Me
        FormMoyenPaiement.Show()
        FormMoyenPaiement.WindowState = FormWindowState.Normal
        FormMoyenPaiement.BringToFront()
    End Sub

    Private Sub JournalDeCaisseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalDeCaisseToolStripMenuItem.Click
        FormJournalCaisse.MdiParent = Me

        FormJournalCaisse.Show()
        FormJournalCaisse.WindowState = FormWindowState.Normal
        FormJournalCaisse.BringToFront()
    End Sub

    Private Sub CAParRayonVendeurToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormStatVente1.MdiParent = Me

        FormStatVente1.Show()
        FormStatVente1.WindowState = FormWindowState.Normal
        FormStatVente1.BringToFront()
    End Sub

    Private Sub ComptesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComptesToolStripMenuItem.Click
        FormComptes.MdiParent = Me

        FormComptes.Show()
        FormComptes.WindowState = FormWindowState.Normal
        FormComptes.BringToFront()
    End Sub

    Private Sub TransactionsManuellesSuresLesComptesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionsManuellesSuresLesComptesToolStripMenuItem.Click
        FormTransactionManuelle.MdiParent = Me

        FormTransactionManuelle.Show()
        FormTransactionManuelle.WindowState = FormWindowState.Normal
        FormTransactionManuelle.BringToFront()
    End Sub

    Private Sub CAParRayonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormStatVente_rayon.MdiParent = Me

        FormStatVente_rayon.Show()
        FormStatVente_rayon.WindowState = FormWindowState.Normal
        FormStatVente_rayon.BringToFront()
    End Sub

    Private Sub CANeufOccasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormStatVente_neufoccas.MdiParent = Me

        FormStatVente_neufoccas.Show()
        FormStatVente_neufoccas.WindowState = FormWindowState.Normal
        FormStatVente_neufoccas.BringToFront()
    End Sub

    Private Sub CANeufOccasRayonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormStatVente_neufoccasRayon.MdiParent = Me

        FormStatVente_neufoccasRayon.Show()
        FormStatVente_neufoccasRayon.WindowState = FormWindowState.Normal
        FormStatVente_neufoccasRayon.BringToFront()
    End Sub

    Private Sub CAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormStatVente_neufoccasrayonVendeur.MdiParent = Me

        FormStatVente_neufoccasrayonVendeur.Show()
        FormStatVente_neufoccasrayonVendeur.WindowState = FormWindowState.Normal
        FormStatVente_neufoccasrayonVendeur.BringToFront()
    End Sub

    Private Sub CANeufOccasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormStatVente_neufoccasVendeur.MdiParent = Me

        FormStatVente_neufoccasVendeur.Show()
        FormStatVente_neufoccasVendeur.WindowState = FormWindowState.Normal
        FormStatVente_neufoccasVendeur.BringToFront()
    End Sub

    Private Sub StatistiquesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatistiquesToolStripMenuItem.Click
        FormStatVente.MdiParent = Me

        FormStatVente.Show()
        FormStatVente.WindowState = FormWindowState.Normal
        FormStatVente.BringToFront()
    End Sub

    Private Sub ArticlesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArticlesToolStripMenuItem1.Click

    End Sub

    Private Sub Actualit�sToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Actualit�sToolStripMenuItem.Click
        FormActualite.MdiParent = Me
        FormActualite.Show()
        FormActualite.WindowState = FormWindowState.Normal
        FormActualite.BringToFront()
    End Sub

    Private Sub GuideTailleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuideTailleToolStripMenuItem.Click
        FormGuideTaille.MdiParent = Me

        FormGuideTaille.Show()
        FormGuideTaille.WindowState = FormWindowState.Normal
        FormGuideTaille.BringToFront()
    End Sub

    Private Sub TransporteurssuiviToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransporteurssuiviToolStripMenuItem.Click
        FormTransporteurs.MdiParent = Me

        FormTransporteurs.Show()
        FormTransporteurs.WindowState = FormWindowState.Normal
        FormTransporteurs.BringToFront()
    End Sub

    Private Sub FormPrincipale_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

    End Sub

    Private Sub ImporterArticlesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImporterArticlesToolStripMenuItem.Click
        FormImport.MdiParent = Me
        FormImport.Show()
        FormImport.WindowState = FormWindowState.Normal
        FormImport.BringToFront()
    End Sub

    Private Sub StatistiquesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StatistiquesToolStripMenuItem1.Click
        FormStatVenteNb.MdiParent = Me

        FormStatVenteNb.Show()
        FormStatVenteNb.WindowState = FormWindowState.Normal
        FormStatVenteNb.BringToFront()
    End Sub

    Private Sub CodesPromosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CodesPromosToolStripMenuItem.Click
        FormCodePromo.MdiParent = Me

        FormCodePromo.Show()
        FormCodePromo.WindowState = FormWindowState.Normal
        FormCodePromo.BringToFront()
    End Sub

    Private Sub Ch�queCadeauxAutoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Ch�queCadeauxAutoToolStripMenuItem.Click
        FormChequeCadeauAuto.MdiParent = Me

        FormChequeCadeauAuto.Show()
        FormChequeCadeauAuto.WindowState = FormWindowState.Normal
        FormChequeCadeauAuto.BringToFront()
    End Sub

    Private Sub AssociationPCCaisseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssociationPCCaisseToolStripMenuItem.Click
        FormPCNumCaisse.MdiParent = Me
        FormPCNumCaisse.Show()
        FormPCNumCaisse.WindowState = FormWindowState.Normal
        FormPCNumCaisse.BringToFront()
    End Sub

    Private Sub EcheancesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EcheancesToolStripMenuItem.Click
        FormEcheanceRecherche.MdiParent = Me

        FormEcheanceRecherche.Show()
        FormEcheanceRecherche.WindowState = FormWindowState.Normal
        FormEcheanceRecherche.BringToFront()
    End Sub



    Private Sub LogErreurSynchroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogErreurSynchroToolStripMenuItem.Click
        Dim f As New FormLog
        f.ShowDialog()
    End Sub

    Private Sub LogAppelsDiff�r�sToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogAppelsDiff�r�sToolStripMenuItem.Click
        Dim f As New FormApiCall
        f.ShowDialog()
    End Sub

    Private Sub TriDesAttributsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TriDesAttributsToolStripMenuItem.Click
        Dim f As New FormTriAttribut
        f.ShowDialog()

    End Sub

    Private Sub ImporterArticlesParSousFamilleancienSiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImporterArticlesParSousFamilleancienSiteToolStripMenuItem.Click
        Dim f As New FormImportArticleParSousFamilleAncienSite
        f.ShowDialog()

    End Sub

    Private Sub SuppressionDesProduitsPSDansCorrespondanceCLIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuppressionDesProduitsPSDansCorrespondanceCLIToolStripMenuItem.Click
        Dim f As New FormSuppressionDesProduitsPrestashopSansCorrespondanceCLI
        f.ShowDialog()
    End Sub

    Private Sub ImporterLesClientsVersPSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImporterLesClientsVersPSToolStripMenuItem.Click
        Dim f As New FormImportClients
        f.ShowDialog()
    End Sub

    Private Sub TonquerLeLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TonquerLeLogToolStripMenuItem.Click
        Dim f As New FormTruncateLog
        f.ShowDialog()
    End Sub

    Private Sub ImporterCommandePrestashopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImporterCommandePrestashopToolStripMenuItem.Click
        Dim f As New FormImportCommande
        f.ShowDialog()
    End Sub

    Private Sub ChangerMessageDisponibilit�ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangerMessageDisponibilit�ToolStripMenuItem.Click
        Dim f As New FormMessageDispo
        f.ShowDialog()

    End Sub
End Class

Public Class Article
    Dim userId As Integer
    Dim id As Integer
    Dim title As String
    Dim body As String
End Class