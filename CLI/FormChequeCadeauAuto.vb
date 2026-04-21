Imports System.Linq

Public Class FormChequeCadeauAuto
    Private Sub T_CodePromoBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.T_ChequeCadeauAutoBindingSource.EndEdit()
        Me.T_ChequeCadeauAutoTableAdapter.Update(Me.CLIDataSet.T_ChequeCadeauAuto)

    End Sub

    Private Sub FormCodePromo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'CLIDataSet.T_ChequeCadeauAuto'. Vous pouvez la déplacer ou la supprimer selon les besoins.
        Me.T_ChequeCadeauAutoTableAdapter.Fill(Me.CLIDataSet.T_ChequeCadeauAuto)

    End Sub


    Private Sub T_CodePromoDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles T_CodePromoDataGridView.CellContentDoubleClick


        AfficheDetail(e)

    End Sub

    Private Sub AfficheDetail(e As DataGridViewCellEventArgs)

        'suppression des evenements
        RemoveHandler FamilleComboBox.SelectedIndexChanged, AddressOf FamilleComboBox_SelectedIndexChanged
        RemoveHandler SousFamilleComboBox.SelectedIndexChanged, AddressOf SousFamilleComboBox_SelectedIndexChanged
        RemoveHandler TypeComboBox.SelectedIndexChanged, AddressOf TypeComboBox_SelectedIndexChanged


        'Mappage des éléments de la grille vers le detail
        IDTextBox.Text = T_CodePromoDataGridView.Rows(e.RowIndex).Cells("I_Id_t_ChequeCadeauAuto").Value


        'recup des valeurs depuis la base de données

        Dim dt As DataTable = ExecuteRequeteR("select * from T_ChequeCadeauAuto where id_t_chequecadeauauto = " & IDTextBox.Text, My.Settings.CLIConnectionString)

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
            InitCombo(TypeComboBox, My.Settings.CLIConnectionString, "select distinct rtrim(ltrim([type])) as [type] from t_article_detail,t_article_entete where t_article_detail.id_t_article_entete=t_article_entete.id_t_article_entete and id_t_sousfamille=" & SousFamilleComboBox.SelectedValue & " order by rtrim(ltrim([type]))", "type", "", "type")
            If dt.Rows(0)("type").ToString <> "" Then
                TypeComboBox.SelectedValue = dt.Rows(0)("type").ToString
            End If

        End If


        'ajout des evenements
        AddHandler FamilleComboBox.SelectedIndexChanged, AddressOf FamilleComboBox_SelectedIndexChanged
        AddHandler SousFamilleComboBox.SelectedIndexChanged, AddressOf SousFamilleComboBox_SelectedIndexChanged
        AddHandler TypeComboBox.SelectedIndexChanged, AddressOf TypeComboBox_SelectedIndexChanged

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

            strSql = "UPDATE [dbo].[T_ChequeCadeauAuto]
   SET 
      [Du] = '" & DuDateTimePicker.Value.Date & "'
      ,[Au] = '" & AuDateTimePicker.Value.Date & "'
      ,[id_t_famille] =" & IIf(Not FamilleComboBox.SelectedValue Is DBNull.Value And Not FamilleComboBox.SelectedValue Is Nothing, FamilleComboBox.SelectedValue, "null") & "
      ,[id_t_sousfamille] = " & IIf(Not SousFamilleComboBox.SelectedValue Is DBNull.Value And Not SousFamilleComboBox.SelectedValue Is Nothing, SousFamilleComboBox.SelectedValue, "null") & "
      ,[type] = '" & TypeComboBox.SelectedValue & "'
      ,[NeufOccazTout] = " & NeufOccazToutComboBox.SelectedValue & "
      ,[PourcentageRemise] = " & RemiseTextBox.Text.Replace(",", ".") & "
      ,[Valide] = " & IIf(ValideCheckBox.Checked, 1, 0) & "
      , [Description] = '" & DescriptionTextBox.Text.Replace("'", "''") & "'
 WHERE id_t_chequecadeauauto = " & IDTextBox.Text



        Else
            strSql = "INSERT INTO [dbo].[T_chequeCadeauAuto]
           (
           [Du]
           ,[Au]
           ,[id_t_famille]
           ,[id_t_sousfamille]
           ,[type]
           ,[NeufOccazTout]
           ,[PourcentageRemise]
           ,[Valide]
           ,[Description])
     VALUES
           ('" & DuDateTimePicker.Value.Date & "'
           ,'" & AuDateTimePicker.Value.Date & "'
           ," & IIf(Not FamilleComboBox.SelectedValue Is DBNull.Value And Not FamilleComboBox.SelectedValue Is Nothing, FamilleComboBox.SelectedValue, "null") & "
           ," & IIf(Not SousFamilleComboBox.SelectedValue Is DBNull.Value And Not SousFamilleComboBox.SelectedValue Is Nothing, SousFamilleComboBox.SelectedValue, "null") & "
           ,'" & TypeComboBox.SelectedValue & "'
           ," & NeufOccazToutComboBox.SelectedValue & "
           ," & RemiseTextBox.Text.Replace(",", ".") & "
           ," & IIf(ValideCheckBox.Checked, 1, 0) & "
           ,'" & DescriptionTextBox.Text.Replace("'", "''") & "')"
        End If

        ExecuteRequeteR(strSql, My.Settings.CLIConnectionString)

        DetailPanel.Hide()
        Me.T_ChequeCadeauAutoTableAdapter.Fill(Me.CLIDataSet.T_ChequeCadeauAuto)
        ListPanel.Show()


    End Sub





    Private Sub BT_supprimer_Click(sender As Object, e As EventArgs) Handles BT_supprimer.Click
        If MessageBox.Show("Etes-vous sûr ?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
            ExecuteRequeteR("delete from t_chequecadeauauto where id_t_chequecadeauauto = " & IDTextBox.Text, My.Settings.CLIConnectionString)
        End If
        DetailPanel.Hide()
        Me.T_ChequeCadeauAutoTableAdapter.Fill(Me.CLIDataSet.T_ChequeCadeauAuto)
        ListPanel.Show()

    End Sub

    Private Sub BT_Annuler_Click(sender As Object, e As EventArgs) Handles BT_Annuler.Click
        DetailPanel.Hide()
        Me.T_ChequeCadeauAutoTableAdapter.Fill(Me.CLIDataSet.T_ChequeCadeauAuto)
        ListPanel.Show()
    End Sub

    Private Sub BT_Ajouter_Click(sender As Object, e As EventArgs) Handles BT_Ajouter.Click
        NouveauCode()

    End Sub

    Sub NouveauCode()

        'initialisation des combobox
        'NeufOccazTout
        InitCombo(NeufOccazToutComboBox, My.Settings.CLIConnectionString, "select id,libelle from t_neufoccaztout order by libelle", "libelle", Nothing, "id")
        'Famille
        InitCombo(FamilleComboBox, My.Settings.CLIConnectionString, "select id_t_famille,libelle from t_famille order by libelle", "libelle", "", "id_t_famille")



        IDTextBox.Text = ""

        DescriptionTextBox.Text = ""

        DuDateTimePicker.ResetText()
        AuDateTimePicker.ResetText()
        RemiseTextBox.ResetText()

        NeufOccazToutComboBox.SelectedIndex = -1

        FamilleComboBox.SelectedIndex = -1

        SousFamilleComboBox.DataSource = Nothing
        TypeComboBox.DataSource = Nothing

        NeufOccazToutComboBox.SelectedIndex = -1

        DetailPanel.Show()
        ListPanel.Hide()
    End Sub

    Private Sub FamilleComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FamilleComboBox.SelectedIndexChanged

        'remise à zéro
        SousFamilleComboBox.DataSource = Nothing
        TypeComboBox.DataSource = Nothing


        'remplissage
        If FamilleComboBox.SelectedIndex > 0 Then
            InitCombo(SousFamilleComboBox, My.Settings.CLIConnectionString, "select id_t_Sousfamille,libelle from t_sousfamille where id_t_famille=" & FamilleComboBox.SelectedValue & " order by libelle", "libelle", "", "id_t_sousfamille")
        End If


    End Sub

    Private Sub SousFamilleComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SousFamilleComboBox.SelectedIndexChanged
        'remise à zéro
        TypeComboBox.DataSource = Nothing


        'remplissage
        If SousFamilleComboBox.SelectedIndex > 0 Then
            InitCombo(TypeComboBox, My.Settings.CLIConnectionString, "select distinct rtrim(ltrim([type])) as [type] from t_article_detail,t_article_entete where t_article_detail.id_t_article_entete=t_article_entete.id_t_article_entete and id_t_sousfamille=" & SousFamilleComboBox.SelectedValue & " order by rtrim(ltrim([type]))", "type", "", "type")

        End If
    End Sub

    Private Sub TypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TypeComboBox.SelectedIndexChanged

    End Sub


End Class