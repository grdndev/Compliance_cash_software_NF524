Imports System.Linq

Public Class FormCodePromo
    Private Sub T_CodePromoBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.T_CodePromoBindingSource.EndEdit()
        Me.T_CodePromoTableAdapter.Update(Me.CLIDataSet.T_CodePromo)

    End Sub

    Private Sub FormCodePromo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.T_CodePromoTableAdapter.Fill(Me.CLIDataSet.T_CodePromo)
    End Sub


    Private Sub T_CodePromoDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles T_CodePromoDataGridView.CellContentDoubleClick


        AfficheDetail(e)

    End Sub
    Private Sub AfficheDetail(e As DataGridViewCellEventArgs)



        'Mappage des éléments de la grille vers le detail
        IDTextBox.Text = T_CodePromoDataGridView.Rows(e.RowIndex).Cells("I_Id_t_CodePromo").Value
        CodeTextBox.Text = T_CodePromoDataGridView.Rows(e.RowIndex).Cells("I_Code").Value

        'recup des valeurs depuis la base de données

        Dim dt As DataTable = ExecuteRequeteR("select * from T_codePromo where id_t_codepromo = " & IDTextBox.Text, My.Settings.CLIConnectionString)

        DuDateTimePicker.Value = dt.Rows(0)("Du").ToString
        AuDateTimePicker.Value = dt.Rows(0)("Au").ToString
        RemiseTextBox.Text = dt.Rows(0)("PourcentageRemise").ToString
        DescriptionTextBox.Text = dt.Rows(0)("Description").ToString
        ValideCheckBox.Checked = dt.Rows(0)("valide")


        'initialisation des combobox
        'NeufOccazTout
        RemoveHandler NeufOccazToutComboBox.SelectedIndexChanged, AddressOf NeufOccazToutComboBox_SelectedIndexChanged

        InitCombo(NeufOccazToutComboBox, My.Settings.CLIConnectionString, "select id,libelle from t_neufoccaztout order by libelle", "libelle", Nothing, "id")
        AddHandler NeufOccazToutComboBox.SelectedIndexChanged, AddressOf NeufOccazToutComboBox_SelectedIndexChanged


        If dt.Rows(0)("NeufOccazTout").ToString <> "" Then
            Console.WriteLine(dt.Rows(0)("neufOccazTout"))
            NeufOccazToutComboBox.SelectedIndex = -1
            NeufOccazToutComboBox.SelectedValue = dt.Rows(0)("neufOccazTout")
        End If


        'Marque

        If dt.Rows(0)("Marque").ToString <> "" Then
            MarqueCombobox.SelectedValue = dt.Rows(0)("marque").ToString
        End If

        'Famille

        If dt.Rows(0)("id_t_Famille").ToString <> "" Then
            FamilleComboBox.SelectedValue = dt.Rows(0)("Id_t_famille").ToString
        End If



        'SousFamille

        If dt.Rows(0)("id_t_sousFamille").ToString <> "" Then
            SousFamilleComboBox.SelectedValue = dt.Rows(0)("id_t_sousFamille").ToString
        End If



        'Type
        If dt.Rows(0)("type").ToString <> "" Then
            TypeComboBox.SelectedValue = dt.Rows(0)("type").ToString
        End If



        'Entete

        If dt.Rows(0)("id_t_article_entete").ToString <> "" Then
            EnteteComboBox.SelectedValue = dt.Rows(0)("id_t_article_entete").ToString
        End If



        'Détail

        If dt.Rows(0)("id_t_article_detail").ToString <> "" Then
            DetailComboBox.SelectedValue = dt.Rows(0)("id_t_article_detail").ToString
        End If



        'Version

        If dt.Rows(0)("id_t_article_version").ToString <> "" Then
            VersionComboBox.SelectedValue = dt.Rows(0)("id_t_article_version").ToString
        End If


        DetailPanel.Show()
        ListPanel.Hide()


    End Sub
    Private Sub AfficheDetailOrig(e As DataGridViewCellEventArgs)

        'suppression des evenements
        RemoveHandler FamilleComboBox.SelectedIndexChanged, AddressOf FamilleComboBox_SelectedIndexChanged
        RemoveHandler SousFamilleComboBox.SelectedIndexChanged, AddressOf SousFamilleComboBox_SelectedIndexChanged
        RemoveHandler TypeComboBox.SelectedIndexChanged, AddressOf TypeComboBox_SelectedIndexChanged
        RemoveHandler EnteteComboBox.SelectedIndexChanged, AddressOf EnteteComboBox_SelectedIndexChanged
        RemoveHandler DetailComboBox.SelectedIndexChanged, AddressOf DetailComboBox_SelectedIndexChanged

        'Mappage des éléments de la grille vers le detail
        IDTextBox.Text = T_CodePromoDataGridView.Rows(e.RowIndex).Cells("I_Id_t_CodePromo").Value
        CodeTextBox.Text = T_CodePromoDataGridView.Rows(e.RowIndex).Cells("I_Code").Value

        'recup des valeurs depuis la base de données

        Dim dt As DataTable = ExecuteRequeteR("select * from T_codePromo where id_t_codepromo = " & IDTextBox.Text, My.Settings.CLIConnectionString)

        DuDateTimePicker.Value = dt.Rows(0)("Du").ToString
        AuDateTimePicker.Value = dt.Rows(0)("Au").ToString
        RemiseTextBox.Text = dt.Rows(0)("PourcentageRemise").ToString
        DescriptionTextBox.Text = dt.Rows(0)("Description").ToString
        ValideCheckBox.Checked = dt.Rows(0)("valide")


        'initialisation des combobox
        'NeufOccazTout
        InitCombo(NeufOccazToutComboBox, My.Settings.CLIConnectionString, "select id,libelle from t_neufoccaztout order by libelle", "libelle", Nothing, "id")
        'Famille
        InitCombo(FamilleComboBox, My.Settings.CLIConnectionString, "select id_t_famille,libelle from t_famille order by libelle", "libelle", "", "id_t_famille")
        If dt.Rows(0)("id_t_Famille").ToString <> "" Then
            FamilleComboBox.SelectedValue = dt.Rows(0)("Id_t_famille").ToString
        End If



        'SousFamille

        Dim champtech As String = ""
        If dt.Rows(0)("id_t_Famille").ToString <> "" Then
            InitCombo(SousFamilleComboBox, My.Settings.CLIConnectionString, "select id_t_Sousfamille,libelle from t_sousfamille where id_t_famille=" & FamilleComboBox.SelectedValue & " order by libelle", "libelle", "", "id_t_sousfamille")
            If dt.Rows(0)("id_t_sousFamille").ToString <> "" Then
                SousFamilleComboBox.SelectedValue = dt.Rows(0)("id_t_sousFamille").ToString
                champtech = ExecuteRequeteR("select champtech from t_sousfamille where id_t_sousfamille = " & dt.Rows(0)("id_t_sousFamille").ToString, My.Settings.CLIConnectionString).Rows(0)("champtech").ToString
            End If

        End If

        'Type
        If dt.Rows(0)("id_t_sousFamille").ToString <> "" Then
            InitCombo(TypeComboBox, My.Settings.CLIConnectionString, "select distinct rtrim(ltrim([type])) as [type] from t_article_detail,t_article_entete,t_article_version where t_article_detail.id_t_article_entete=t_article_entete.id_t_article_entete  and t_article_version.id_t_article_detail=t_article_detail.id_t_article_detail and active_on=1 and web_on=1 and id_t_sousfamille=" & SousFamilleComboBox.SelectedValue & " order by rtrim(ltrim([type]))", "type", "", "type")
            If dt.Rows(0)("type").ToString <> "" Then
                TypeComboBox.SelectedValue = dt.Rows(0)("type").ToString
            End If

        End If

        'Entete

        If dt.Rows(0)("type").ToString <> "" Or dt.Rows(0)("id_t_sousFamille").ToString <> "" Then
            'si type <>'' et on filtre aussi sur le type et on ramene le champtech de la sousfamille

            InitCombo(EnteteComboBox, My.Settings.CLIConnectionString, "select distinct T_Article_Entete.ID_t_article_entete,isnull(annee,'') +'/' + isnull(marque,'') +'/'+isnull(modele,'')  as libelle from T_Article_Entete,t_article_detail,t_Article_version where t_article_detail.id_t_article_entete=t_article_entete.id_t_article_entete and t_article_version.id_t_article_detail=t_article_detail.id_t_article_detail and active_on=1 and web_on=1 and  id_t_sousfamille=" & SousFamilleComboBox.SelectedValue & IIf(TypeComboBox.SelectedValue.ToString <> "", " and [type]='" & TypeComboBox.SelectedValue.ToString.Replace("'", "''") & "'", "") & " order by isnull(annee,'') +'/' + isnull(marque,'') +'/'+isnull(modele,'') ", "libelle", "", "ID_t_article_entete")
            If dt.Rows(0)("id_t_article_entete").ToString <> "" Then
                EnteteComboBox.SelectedValue = dt.Rows(0)("id_t_article_entete").ToString
            End If

        End If

        'Détail

        If dt.Rows(0)("id_t_article_entete").ToString <> "" Then

            InitCombo(DetailComboBox, My.Settings.CLIConnectionString, "select distinct id_t_article_detail, convert(varchar," & champtech & ")  as libelle from t_article_detail,t_Article_version where t_article_version.id_t_article_detail=t_article_detail.id_t_article_detail t_article_detail.id_t_article_entete=" & EnteteComboBox.SelectedValue & " and active_on=1 and web_on=1 and order by " & champtech, "libelle", "", "ID_t_article_detail")
            If dt.Rows(0)("id_t_article_detail").ToString <> "" Then
                DetailComboBox.SelectedValue = dt.Rows(0)("id_t_article_detail").ToString
            End If

        End If

        'Version

        If dt.Rows(0)("id_t_article_detail").ToString <> "" Then

            InitCombo(VersionComboBox, My.Settings.CLIConnectionString, "select id_t_article_version, description_panier  as libelle from t_article_version where t_article_version.id_t_article_detail=" & DetailComboBox.SelectedValue & " and active_on=1 and web_on=1 order by description_panier ", "libelle", "", "ID_t_article_version")
            If dt.Rows(0)("id_t_article_version").ToString <> "" Then
                VersionComboBox.SelectedValue = dt.Rows(0)("id_t_article_version").ToString
            End If

        End If
        'ajout des evenements
        AddHandler FamilleComboBox.SelectedIndexChanged, AddressOf FamilleComboBox_SelectedIndexChanged
        AddHandler SousFamilleComboBox.SelectedIndexChanged, AddressOf SousFamilleComboBox_SelectedIndexChanged
        AddHandler TypeComboBox.SelectedIndexChanged, AddressOf TypeComboBox_SelectedIndexChanged
        AddHandler EnteteComboBox.SelectedIndexChanged, AddressOf EnteteComboBox_SelectedIndexChanged
        AddHandler DetailComboBox.SelectedIndexChanged, AddressOf DetailComboBox_SelectedIndexChanged
        DetailPanel.Show()
        ListPanel.Hide()


    End Sub

    Private Sub BT_Save_Click(sender As Object, e As EventArgs) Handles BT_Save.Click
        Dim bUpdate As Boolean = False
        Dim strSql As String = ""


        'test des champs
        '.........
        Dim errMsg As String = ""

        If NeufOccazToutComboBox.SelectedIndex = -1 Then
            errMsg = errMsg & vbCrLf & "Il faut choisir si le code s'applique sur le neuf / l'occaz ou les deux"
        End If


        Dim dtCodePromo As DataTable = ExecuteRequeteR("select * from t_codePromo where code='" & CodeTextBox.Text.Replace("'", "''") & "'", My.Settings.CLIConnectionString)
        If CodeTextBox.Text.Trim = "" Then
            errMsg = errMsg & vbCrLf & "Merci de saisir un code promo"
        Else
            If dtCodePromo.Rows.Count = 1 Then
                If CStr(dtCodePromo.Rows(0)("id_t_codepromo")) <> IDTextBox.Text Then
                    errMsg = errMsg & vbCrLf & "Le code de promo existe déjà"
                End If

            End If
        End If




        If Not IsNumeric(RemiseTextBox.Text) Then
            errMsg = errMsg & vbCrLf & "Merci de choisir un pourcentage de remise saisi en décimale : saisir 0,1 pour 10%"
        Else
            If CDbl(RemiseTextBox.Text) < 0 Or CDbl(RemiseTextBox.Text) > 1 Then
                errMsg = errMsg & vbCrLf & "Merci de choisir un pourcentage de remise saisi en décimale : saisir 0,1 pour 10%"
            End If
        End If

        If DescriptionTextBox.Text.Trim = "" Then
            errMsg = errMsg & vbCrLf & "Merci de saisir une description pour ce code de réduction"
        End If

        If errMsg <> "" Then
            MessageBox.Show(errMsg, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If



        If IDTextBox.Text <> "" Then
            bUpdate = True
        End If

        If bUpdate Then

            strSql = "UPDATE [dbo].[T_CodePromo]
   SET [Code] = '" & CodeTextBox.Text & "'
      ,[Du] = '" & DuDateTimePicker.Value.Date & "'
      ,[Au] = '" & AuDateTimePicker.Value.Date & "'
      ,[id_t_famille] =" & If(Not FamilleComboBox.SelectedValue Is DBNull.Value And Not FamilleComboBox.SelectedValue Is Nothing, FamilleComboBox.SelectedValue, "null") & "
      ,[id_t_sousfamille] = " & If(Not SousFamilleComboBox.SelectedValue Is DBNull.Value And Not SousFamilleComboBox.SelectedValue Is Nothing, SousFamilleComboBox.SelectedValue, "null") & "
      ,[type] = '" & If(Not TypeComboBox.SelectedValue Is DBNull.Value And Not TypeComboBox.SelectedValue Is Nothing, TypeComboBox.SelectedValue.ToString.Replace("'", "''"), "") & "'
      ,[id_t_article_entete] =" & If(Not EnteteComboBox.SelectedValue Is DBNull.Value And Not EnteteComboBox.SelectedValue Is Nothing, EnteteComboBox.SelectedValue, "null") & "
      ,[id_t_article_detail] = " & If(Not DetailComboBox.SelectedValue Is DBNull.Value And Not DetailComboBox.SelectedValue Is Nothing, DetailComboBox.SelectedValue, "null") & "
      ,[id_t_article_version] = " & If(Not VersionComboBox.SelectedValue Is DBNull.Value And Not VersionComboBox.SelectedValue Is Nothing, VersionComboBox.SelectedValue, "null") & "
      ,[NeufOccazTout] = " & NeufOccazToutComboBox.SelectedValue & "
      ,[PourcentageRemise] = " & RemiseTextBox.Text.Replace(",", ".") & "
      ,[Valide] = " & If(ValideCheckBox.Checked, 1, 0) & "
      , [Description] = '" & DescriptionTextBox.Text.Replace("'", "''") & "'
      , [Marque] = '" & If(Not MarqueCombobox.SelectedValue Is DBNull.Value And Not MarqueCombobox.SelectedValue Is Nothing, MarqueCombobox.SelectedValue.ToString.Replace("'", "''"), "") & "'
            WHERE id_t_codepromo = " & IDTextBox.Text



        Else
            strSql = "INSERT INTO [dbo].[T_CodePromo]
           ([Code]
           ,[Du]
           ,[Au]
           ,[id_t_famille]
           ,[id_t_sousfamille]
           ,[type]
           ,[id_t_article_entete]
           ,[id_t_article_detail]
           ,[id_t_article_version]
           ,[NeufOccazTout]
           ,[PourcentageRemise]
           ,[Valide]
           ,[Description]
           ,[Marque])
     VALUES
           ('" & CodeTextBox.Text & "'
           ,'" & DuDateTimePicker.Value.Date & "'
           ,'" & AuDateTimePicker.Value.Date & "'
           ," & If(Not FamilleComboBox.SelectedValue Is DBNull.Value And Not FamilleComboBox.SelectedValue Is Nothing, FamilleComboBox.SelectedValue, "null") & "
           ," & If(Not SousFamilleComboBox.SelectedValue Is DBNull.Value And Not SousFamilleComboBox.SelectedValue Is Nothing, SousFamilleComboBox.SelectedValue, "null") & "
           ,'" & If(Not TypeComboBox.SelectedValue Is DBNull.Value And Not TypeComboBox.SelectedValue Is Nothing, TypeComboBox.SelectedValue.ToString.Replace("'", "''"), "") & "'
           ," & If(Not EnteteComboBox.SelectedValue Is DBNull.Value And Not EnteteComboBox.SelectedValue Is Nothing, EnteteComboBox.SelectedValue, "null") & "
           ," & If(Not DetailComboBox.SelectedValue Is DBNull.Value And Not DetailComboBox.SelectedValue Is Nothing, DetailComboBox.SelectedValue, "null") & "
           ," & If(Not VersionComboBox.SelectedValue Is DBNull.Value And Not VersionComboBox.SelectedValue Is Nothing, VersionComboBox.SelectedValue, "null") & "
           ," & NeufOccazToutComboBox.SelectedValue & "
           ," & RemiseTextBox.Text.Replace(",", ".") & "
           ," & If(ValideCheckBox.Checked, 1, 0) & "
           ,'" & DescriptionTextBox.Text.Replace("'", "''") & "'
           ,'" & If(Not MarqueCombobox.SelectedValue Is DBNull.Value And Not MarqueCombobox.SelectedValue Is Nothing, MarqueCombobox.SelectedValue.ToString.Replace("'", "''"), "") & "')"
        End If

        ExecuteRequeteR(strSql, My.Settings.CLIConnectionString)

        DetailPanel.Hide()
        Me.T_CodePromoTableAdapter.Fill(Me.CLIDataSet.T_CodePromo)
        ListPanel.Show()


    End Sub

    Private Sub BT_GenererNomUnique_Click(sender As Object, e As EventArgs) Handles BT_GenererNomUnique.Click
        GenerateCode()

    End Sub

    Private Sub GenerateCode()
        Dim bDeja As Boolean = False
        Dim strSql As String = "Select * from t_codepromo where code = "
        CodeTextBox.Text = RandomString(10)

        While ExecuteRequeteR(strSql & "'" & CodeTextBox.Text.Replace("'", "''") & "'", My.Settings.CLIConnectionString).Rows.Count >= 1
            CodeTextBox.Text = RandomString(10)
        End While
    End Sub

    Public Shared Function RandomString(ByVal MaxLengh As Integer) As String
        Dim gen_array(36) As String
        gen_array(0) = "0"
        gen_array(1) = "1"
        gen_array(2) = "2"
        gen_array(3) = "3"
        gen_array(4) = "4"
        gen_array(5) = "5"
        gen_array(6) = "6"
        gen_array(7) = "7"
        gen_array(8) = "8"
        gen_array(9) = "9"
        gen_array(10) = "A"
        gen_array(11) = "B"
        gen_array(12) = "C"
        gen_array(13) = "D"
        gen_array(14) = "E"
        gen_array(15) = "F"
        gen_array(16) = "G"
        gen_array(17) = "H"
        gen_array(18) = "I"
        gen_array(19) = "J"
        gen_array(20) = "K"
        gen_array(21) = "L"
        gen_array(22) = "M"
        gen_array(23) = "N"
        gen_array(24) = "O"
        gen_array(25) = "P"
        gen_array(26) = "Q"
        gen_array(27) = "R"
        gen_array(28) = "S"
        gen_array(29) = "T"
        gen_array(30) = "U"
        gen_array(31) = "V"
        gen_array(32) = "W"
        gen_array(33) = "X"
        gen_array(34) = "Y"
        gen_array(35) = "Z"
        'gen_array(36) = "a"
        'gen_array(37) = "b"
        'gen_array(38) = "c"
        'gen_array(39) = "d"
        'gen_array(40) = "e"
        'gen_array(41) = "f"
        'gen_array(42) = "g"
        'gen_array(43) = "h"
        'gen_array(44) = "i"
        'gen_array(45) = "j"
        'gen_array(46) = "k"
        'gen_array(47) = "l"
        'gen_array(48) = "m"
        'gen_array(49) = "n"
        'gen_array(50) = "o"
        'gen_array(51) = "p"
        'gen_array(52) = "q"
        'gen_array(53) = "r"
        'gen_array(54) = "s"
        'gen_array(55) = "t"
        'gen_array(56) = "u"
        'gen_array(57) = "v"
        'gen_array(58) = "w"
        'gen_array(59) = "x"
        'gen_array(60) = "y"
        'gen_array(61) = "z"
        Dim r As New Random()
        Dim rNumber As Integer
        Dim rOutput As String
        Do While Len(rOutput) < MaxLengh
            rNumber = r.Next(0, 35)
            rOutput = rOutput & gen_array(rNumber)
        Loop
        Return rOutput
    End Function

    Private Sub BT_supprimer_Click(sender As Object, e As EventArgs) Handles BT_supprimer.Click
        If MessageBox.Show("Etes-vous sûr ?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
            ExecuteRequeteR("delete from t_codePromo where id_t_codepromo = " & IDTextBox.Text, My.Settings.CLIConnectionString)
        End If
        DetailPanel.Hide()
        Me.T_CodePromoTableAdapter.Fill(Me.CLIDataSet.T_CodePromo)
        ListPanel.Show()

    End Sub

    Private Sub BT_Annuler_Click(sender As Object, e As EventArgs) Handles BT_Annuler.Click
        DetailPanel.Hide()
        Me.T_CodePromoTableAdapter.Fill(Me.CLIDataSet.T_CodePromo)
        ListPanel.Show()
    End Sub

    Private Sub BT_Ajouter_Click(sender As Object, e As EventArgs) Handles BT_Ajouter.Click
        NouveauCode()

    End Sub

    Sub NouveauCode()


        'initialisation des combobox
        'NeufOccazTout
        InitCombo(NeufOccazToutComboBox, My.Settings.CLIConnectionString, "select id,libelle from t_neufoccaztout order by libelle", "libelle", "", "id")
        'Famille
        ' InitCombo(FamilleComboBox, My.Settings.CLIConnectionString, "select id_t_famille,libelle from t_famille order by libelle", "libelle", "", "id_t_famille")



        IDTextBox.Text = ""
        'CodeTextBox.Text = ""
        'génération d'un code unique
        GenerateCode()
        DescriptionTextBox.Text = ""

        DuDateTimePicker.ResetText()
        AuDateTimePicker.ResetText()
        RemiseTextBox.ResetText()

        NeufOccazToutComboBox.SelectedIndex = -1
        MarqueCombobox.SelectedIndex = -1

        FamilleComboBox.SelectedIndex = -1

        SousFamilleComboBox.DataSource = Nothing
        TypeComboBox.DataSource = Nothing
        EnteteComboBox.DataSource = Nothing
        DetailComboBox.DataSource = Nothing
        VersionComboBox.DataSource = Nothing


        DetailPanel.Show()
        ListPanel.Hide()
    End Sub

    Private Sub NeufOccazToutComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles NeufOccazToutComboBox.SelectedIndexChanged
        'remise à zéro
        MarqueCombobox.DataSource = Nothing
        FamilleComboBox.DataSource = Nothing
        SousFamilleComboBox.DataSource = Nothing
        TypeComboBox.DataSource = Nothing
        EnteteComboBox.DataSource = Nothing
        DetailComboBox.DataSource = Nothing
        VersionComboBox.DataSource = Nothing

        'remplissage
        Dim strFiltre As String = ""
        If IsNumeric(NeufOccazToutComboBox.SelectedValue) Then
            Select Case NeufOccazToutComboBox.SelectedValue
                Case 0 : strFiltre = strFiltre & " and occaz = 0 "
                Case 1 : strFiltre = strFiltre & " and occaz = 1 "
            End Select
        End If
        If IsNumeric(NeufOccazToutComboBox.SelectedValue) Then
            InitCombo(MarqueCombobox, My.Settings.CLIConnectionString, "select distinct Marque from v_generateCodepromo where 1=1 " & strFiltre & " order by Marque", "Marque", "", "Marque")
            InitCombo(FamilleComboBox, My.Settings.CLIConnectionString, "select distinct id_t_famille,famille from v_generateCodepromo where 1=1 " & strFiltre & " order by famille", "famille", "", "id_t_famille")
        End If

    End Sub

    Private Sub MarqueComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MarqueCombobox.SelectedIndexChanged
        'remise à zéro

        FamilleComboBox.DataSource = Nothing
        SousFamilleComboBox.DataSource = Nothing
        TypeComboBox.DataSource = Nothing
        EnteteComboBox.DataSource = Nothing
        DetailComboBox.DataSource = Nothing
        VersionComboBox.DataSource = Nothing


        'remplissage
        Dim strFiltre As String = ""
        If IsNumeric(NeufOccazToutComboBox.SelectedValue) Then
            Select Case NeufOccazToutComboBox.SelectedValue
                Case 0 : strFiltre = strFiltre & " and occaz = 0 "
                Case 1 : strFiltre = strFiltre & " and occaz = 1 "
            End Select
        End If

        If (MarqueCombobox.Text <> "" And MarqueCombobox.Text <> "System.Data.DataRowView") Or IsNumeric(NeufOccazToutComboBox.SelectedValue) Then
            strFiltre = strFiltre & " and marque = '" & MarqueCombobox.Text.Replace("'", "''") & "'"
        End If


        If (MarqueCombobox.Text <> "" And MarqueCombobox.Text <> "System.Data.DataRowView") Or IsNumeric(NeufOccazToutComboBox.SelectedValue) Then
            InitCombo(FamilleComboBox, My.Settings.CLIConnectionString, "select distinct id_t_famille,famille from v_generateCodepromo where 1=1 " & strFiltre & " order by famille", "famille", "", "id_t_famille")
        End If

    End Sub
    Private Sub FamilleComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FamilleComboBox.SelectedIndexChanged
        'remise à zéro
        SousFamilleComboBox.DataSource = Nothing
        TypeComboBox.DataSource = Nothing
        EnteteComboBox.DataSource = Nothing
        DetailComboBox.DataSource = Nothing
        VersionComboBox.DataSource = Nothing

        'remplissage

        Dim strFiltre As String = ""
        If IsNumeric(NeufOccazToutComboBox.SelectedValue) Then
            Select Case NeufOccazToutComboBox.SelectedValue
                Case 0 : strFiltre = " and occaz = 0 "
                Case 1 : strFiltre = " and occaz = 1 "
            End Select
        End If
        If MarqueCombobox.Text <> "" And MarqueCombobox.Text <> "System.Data.DataRowView" Then
            strFiltre = strFiltre & " and marque = '" & MarqueCombobox.Text.Replace("'", "''") & "'"
        End If

        If IsNumeric(FamilleComboBox.SelectedValue) Then
            strFiltre = strFiltre & " and id_t_famille = " & FamilleComboBox.SelectedValue
        End If

        If IsNumeric(FamilleComboBox.SelectedValue) Then
            InitCombo(SousFamilleComboBox, My.Settings.CLIConnectionString, "select distinct id_t_sousfamille,sousfamille from v_generateCodepromo where 1=1 " & strFiltre & " order by sousfamille", "sousfamille", "", "id_t_sousfamille")
        End If

    End Sub

    Private Sub SousFamilleComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SousFamilleComboBox.SelectedIndexChanged
        'remise à zéro
        TypeComboBox.DataSource = Nothing
        EnteteComboBox.DataSource = Nothing
        DetailComboBox.DataSource = Nothing
        VersionComboBox.DataSource = Nothing

        'remplissage

        Dim strFiltre As String = ""
        If IsNumeric(NeufOccazToutComboBox.SelectedValue) Then
            Select Case NeufOccazToutComboBox.SelectedValue
                Case 0 : strFiltre = " and occaz = 0 "
                Case 1 : strFiltre = " and occaz = 1 "
            End Select
        End If
        If MarqueCombobox.Text <> "" And MarqueCombobox.Text <> "System.Data.DataRowView" Then
            strFiltre = strFiltre & " and marque = '" & MarqueCombobox.Text.Replace("'", "''") & "'"
        End If

        If IsNumeric(FamilleComboBox.SelectedValue) Then
            strFiltre = strFiltre & " and id_t_famille = " & FamilleComboBox.SelectedValue
        End If

        If IsNumeric(SousFamilleComboBox.SelectedValue) Then
            strFiltre = strFiltre & " and id_t_sousfamille = " & SousFamilleComboBox.SelectedValue
        End If

        If IsNumeric(SousFamilleComboBox.SelectedValue) Then
            InitCombo(TypeComboBox, My.Settings.CLIConnectionString, "select distinct type from v_generateCodepromo where 1=1 " & strFiltre & " order by type", "type", "", "type")

            InitCombo(EnteteComboBox, My.Settings.CLIConnectionString, "select distinct id_t_article_entete,libelleEntete from v_generateCodepromo where 1=1 " & strFiltre & " order by libelleEntete", "libelleEntete", "", "id_t_article_Entete")

        End If
    End Sub

    Private Sub TypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TypeComboBox.SelectedIndexChanged
        'remise à zéro
        EnteteComboBox.DataSource = Nothing
        DetailComboBox.DataSource = Nothing
        VersionComboBox.DataSource = Nothing

        'remplissage

        Dim strFiltre As String = ""
        If IsNumeric(NeufOccazToutComboBox.SelectedValue) Then
            Select Case NeufOccazToutComboBox.SelectedValue
                Case 0 : strFiltre = " and occaz = 0 "
                Case 1 : strFiltre = " and occaz = 1 "
            End Select
        End If
        If MarqueCombobox.Text <> "" And MarqueCombobox.Text <> "System.Data.DataRowView" Then
            strFiltre = strFiltre & " and marque = '" & MarqueCombobox.Text.Replace("'", "''") & "'"
        End If

        If IsNumeric(FamilleComboBox.SelectedValue) Then
            strFiltre = strFiltre & " and id_t_famille = " & FamilleComboBox.SelectedValue
        End If

        If IsNumeric(SousFamilleComboBox.SelectedValue) Then
            strFiltre = strFiltre & " and id_t_sousfamille = " & SousFamilleComboBox.SelectedValue
        End If
        If TypeComboBox.Text <> "" And TypeComboBox.Text <> "System.Data.DataRowView" Then
            strFiltre = strFiltre & " and type = '" & TypeComboBox.Text.Replace("'", "''") & "'"
        End If

        If TypeComboBox.Text <> "" And TypeComboBox.Text <> "System.Data.DataRowView" Or IsNumeric(SousFamilleComboBox.SelectedValue) Then
            InitCombo(EnteteComboBox, My.Settings.CLIConnectionString, "select distinct id_t_article_entete,libelleEntete from v_generateCodepromo where 1=1 " & strFiltre & " order by libelleEntete", "libelleEntete", "", "id_t_article_Entete")

        End If
    End Sub

    Private Sub EnteteComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EnteteComboBox.SelectedIndexChanged
        'remise à zéro

        DetailComboBox.DataSource = Nothing
        VersionComboBox.DataSource = Nothing


        Dim strFiltre As String = ""
        If IsNumeric(NeufOccazToutComboBox.SelectedValue) Then
            Select Case NeufOccazToutComboBox.SelectedValue
                Case 0 : strFiltre = " and occaz = 0 "
                Case 1 : strFiltre = " and occaz = 1 "
            End Select
        End If
        If MarqueCombobox.Text <> "" And MarqueCombobox.Text <> "System.Data.DataRowView" Then
            strFiltre = strFiltre & " and marque = '" & MarqueCombobox.Text.Replace("'", "''") & "'"
        End If

        If IsNumeric(FamilleComboBox.SelectedValue) Then
            strFiltre = strFiltre & " and id_t_famille = " & FamilleComboBox.SelectedValue
        End If

        If IsNumeric(SousFamilleComboBox.SelectedValue) Then
            strFiltre = strFiltre & " and id_t_sousfamille = " & SousFamilleComboBox.SelectedValue
        End If
        If TypeComboBox.Text <> "" And TypeComboBox.Text <> "System.Data.DataRowView" Then
            strFiltre = strFiltre & " and type = '" & TypeComboBox.Text.Replace("'", "''") & "'"
        End If

        If IsNumeric(EnteteComboBox.SelectedValue) Then
            strFiltre = strFiltre & " and id_t_article_entete = " & EnteteComboBox.SelectedValue
        End If
        If IsNumeric(SousFamilleComboBox.SelectedValue) Then
            Dim champtech As String = ""
            champtech = ExecuteRequeteR("select champtech from t_sousfamille where id_t_sousfamille = " & SousFamilleComboBox.SelectedValue, My.Settings.CLIConnectionString).Rows(0)("champtech").ToString

            'remplissage
            If IsNumeric(EnteteComboBox.SelectedValue) Then
                InitCombo(DetailComboBox, My.Settings.CLIConnectionString, "select distinct id_t_article_detail, convert(varchar," & champtech & ")  as libelle from v_generateCodepromo where 1=1 " & strFiltre & " order by convert(varchar," & champtech & "),id_t_article_detail", "libelle", "", "ID_t_article_detail")

            End If
        End If

    End Sub

    Private Sub DetailComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DetailComboBox.SelectedIndexChanged
        'remise à zéro
        VersionComboBox.DataSource = Nothing


        'remplissage
        Dim strFiltre As String = ""
        If IsNumeric(NeufOccazToutComboBox.SelectedValue) Then
            Select Case NeufOccazToutComboBox.SelectedValue
                Case 0 : strFiltre = " and occaz = 0 "
                Case 1 : strFiltre = " and occaz = 1 "
            End Select
        End If
        If MarqueCombobox.Text <> "" And MarqueCombobox.Text <> "System.Data.DataRowView" Then
            strFiltre = strFiltre & " and marque = '" & MarqueCombobox.Text.Replace("'", "''") & "'"
        End If

        If IsNumeric(FamilleComboBox.SelectedValue) Then
            strFiltre = strFiltre & " and id_t_famille = " & FamilleComboBox.SelectedValue
        End If

        If IsNumeric(SousFamilleComboBox.SelectedValue) Then
            strFiltre = strFiltre & " and id_t_sousfamille = " & SousFamilleComboBox.SelectedValue
        End If
        If TypeComboBox.Text <> "" And TypeComboBox.Text <> "System.Data.DataRowView" Then
            strFiltre = strFiltre & " and type = '" & TypeComboBox.Text.Replace("'", "''") & "'"
        End If

        If IsNumeric(EnteteComboBox.SelectedValue) Then
            strFiltre = strFiltre & " and id_t_article_entete = " & EnteteComboBox.SelectedValue
        End If
        If IsNumeric(DetailComboBox.SelectedValue) Then
            strFiltre = strFiltre & " and id_t_article_detail = " & DetailComboBox.SelectedValue
        End If


        If IsNumeric(DetailComboBox.SelectedValue) Then
            InitCombo(VersionComboBox, My.Settings.CLIConnectionString, "select distinct id_t_article_version, description_panier from v_generateCodepromo where 1=1 " & strFiltre & " order by description_panier", "description_panier", "", "id_t_article_version")

        End If



    End Sub
End Class