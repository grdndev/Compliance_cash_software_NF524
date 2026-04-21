Imports System.Security.AccessControl

Public Class FormMessageDispo
    Private Sub BT_RecupLibelles_Click(sender As Object, e As EventArgs) Handles BT_RecupLibelles.Click
        Dim messages As List(Of Object)
        Dim message As String
        Dim toClidto As New ToCliDto()
        Dim AvailabilityMessagesPrestashop As List(Of AvailabilityMessagePrestashop) = New List(Of AvailabilityMessagePrestashop)
        Dim AvailabilityMessageReplacement As List(Of String) = New List(Of String)
        AvailabilityMessageReplacement.Add("")
        AvailabilityMessageReplacement.Add(GetParam("PS_SurCommandeTexte"))
        AvailabilityMessageReplacement.Add(GetParam("PS_PreCommandeTexte"))
        AvailabilityMessageReplacement.Add(GetParam("PS_EnStockTexte"))

        MessageDeRemplacement.DataSource = AvailabilityMessageReplacement



        'Récupération des messages de disponibilité actuels
        'Afficher un message pour dire de cliquer sur Ok et attendre
        MessageBox.Show("Cliquer sur OK et attendre la fin du traitement", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        CliApi.ProductGetUniqueAvailableNowMessagesFromPSAsync(toClidto, messages)
        For Each message In messages
            If message <> "" Then
                Dim availabilityMessagePrestashop As New AvailabilityMessagePrestashop()
                availabilityMessagePrestashop.TypeDeMessage = "available_now"
                availabilityMessagePrestashop.MessageActuelPrestashop = message
                availabilityMessagePrestashop.MessageDeRemplacement = ""
                AvailabilityMessagesPrestashop.Add(availabilityMessagePrestashop)
            End If

        Next
        CliApi.ProductGetUniqueAvailableLaterMessagesFromPSAsync(toClidto, messages)
        For Each message In messages
            If message <> "" Then
                Dim availabilityMessagePrestashop As New AvailabilityMessagePrestashop()
                availabilityMessagePrestashop.TypeDeMessage = "available_later"
                availabilityMessagePrestashop.MessageActuelPrestashop = message
                availabilityMessagePrestashop.MessageDeRemplacement = ""
                AvailabilityMessagesPrestashop.Add(availabilityMessagePrestashop)
            End If

        Next
        DGV_Data.DataSource = AvailabilityMessagesPrestashop


        DGV_Data.Refresh()



    End Sub

    Private Sub BT_Envoi_Click(sender As Object, e As EventArgs) Handles BT_Envoi.Click
        DGV_Data.EndEdit()

        For Each availabilityMessagePrestashop As AvailabilityMessagePrestashop In DGV_Data.DataSource
            If availabilityMessagePrestashop.MessageDeRemplacement <> "" Then
                Dim toCliDto As New ToCliDto()
                toCliDto.NewMessage = availabilityMessagePrestashop.MessageDeRemplacement.Replace("'", "''")
                toCliDto.CurrentMessage = availabilityMessagePrestashop.MessageActuelPrestashop.Replace("'", "''")

                If availabilityMessagePrestashop.TypeDeMessage = "available_now" Then
                    CliApi.ProductUpdateAvailableNowMessageAsync(toCliDto)
                End If
                If availabilityMessagePrestashop.TypeDeMessage = "available_later" Then
                    CliApi.ProductUpdateAvailableLaterMessageAsync(toCliDto)

                End If

            End If
        Next


    End Sub
End Class