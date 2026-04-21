Imports System.Net
Imports DocumentFormat.OpenXml.Drawing.Diagrams
Imports DocumentFormat.OpenXml.Presentation
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports RestSharp

Public Class CliApi



    Shared Function ApiCall(actionUrl As String, method As Method, json As Object, ByRef outobject As Object, Optional ByRef outobject2 As Object = Nothing) As Boolean


        Dim restClient As New RestClient(gCliMinimalApiUrl)
        ServicePointManager.SecurityProtocol = CType(768, SecurityProtocolType) Or CType(3072, SecurityProtocolType)
        Dim RestRequest As New RestRequest(actionUrl, method)
        RestRequest.RequestFormat = DataFormat.Json
        RestRequest.AddHeader("XApiKey", gCliMinimalApiXApiKey)
        RestRequest.AddBody(json)

        Dim response As RestResponse = restClient.Execute(restRequest)

        Dim Message As ResponseMessage = JsonConvert.DeserializeObject(Of ResponseMessage)(response.Content)


        Dim MessageContent As String = ""
        If Not IsNothing(Message) Then
            outobject = Message.ImageDatas
            outobject2 = Message.Objects
            For Each responseMessageLine As ResponseMessageLine In Message.ResponseMessageLines
                MessageContent = responseMessageLine.Type.ToString & " : " & responseMessageLine.Entry & " / " & responseMessageLine.Detail & vbCrLf
            Next

        End If


        If response.StatusCode = Net.HttpStatusCode.InternalServerError Then
            MessageContent = "Erreur interne de serveur"
        End If

        If response.ResponseStatus <> ResponseStatus.Completed Then
            MessageContent = response.ResponseStatus.ToString & ":" & response.ErrorMessage
        End If

        If MessageContent <> "" Then
            Dim formCustomMessage As New FormCustomMessage
            formCustomMessage.Text = "Message Prestashop"
            formCustomMessage.TextBoxMessage.Text = MessageContent
            formCustomMessage.ShowDialog()
        End If

        Return True
    End Function
    Shared Function ApiCallBuffer(actionUrl As String, method As Method, json As Object, ByRef outobject As Object) As Boolean

        'insertion dans la table T_ApiCall
        Dim strsql As String
        strsql = "INSERT INTO [dbo].[T_ApiCall] ([CreatedDate], [Url], [Params], [HttpMethod])
VALUES ('" & Now & "', '" & actionUrl & "', '" & JsonConvert.SerializeObject(json) & "', '" & method.ToString() & "')
"
        ExecuteRequeteR(strsql, gCnn.ConnectionString)




        Return True
    End Function
    Shared Sub CustomerDeletePSByIdAsync(toCliDto As ToCliDto)
        ApiCallBuffer("/customer/DeletePSByIdAsync", Method.POST, toCliDto, Nothing)
    End Sub
    Shared Sub CustomerAddOrUpdatePSfromCLIByIdAsync(toCliDto As ToCliDto)
        ApiCallBuffer("customer/AddOrUpdatePSfromCLIByIdAsync", Method.POST, toCliDto, Nothing)
    End Sub
    Shared Sub CustomerAddOrUpdateAvoirPSfromCLIByIdAsync(toCliDto As ToCliDto)
        ApiCallBuffer("customer/AddOrUpdateAvoirPSfromCLIByIdAsync", Method.POST, toCliDto, Nothing)
    End Sub
    Shared Sub AddressAddOrUpdatePSfromCLIByIdAsync(toCliDto As ToCliDto)
        ApiCallBuffer("address/AddOrUpdatePSfromCLIByIdAsync", Method.POST, toCliDto, Nothing)
    End Sub
    Shared Sub ProductAddOrUpdateMultiplePSfromCLIByIdsAsync(toCliDto As ToCliDto)
        ApiCallBuffer("product/AddOrUpdateMultiplePSfromCLIByIdsAsync", Method.POST, toCliDto, Nothing)
        'ApiCall("product/AddOrUpdatePSfromCLIByIdAsync", Method.POST, toCliDto, Nothing)
    End Sub
    Shared Sub ProductAddOrUpdatePSfromCLIByIdAsync(toCliDto As ToCliDto)
        ApiCallBuffer("product/AddOrUpdatePSfromCLIByIdAsync", Method.POST, toCliDto, Nothing)
        'ApiCall("product/AddOrUpdatePSfromCLIByIdAsync", Method.POST, toCliDto, Nothing)
    End Sub
    Shared Sub ProductDeletePSCombinaisonfromCLIByIdAsync(toCliDto As ToCliDto)
        ApiCallBuffer("product/DeletePSCombinaisonfromCLIByIdAsync", Method.POST, toCliDto, Nothing)
    End Sub
    Shared Sub ProductUpdatePSStockfromCLIByIdAsync(toCliDto As ToCliDto)
        ApiCallBuffer("product/UpdatePSStockfromCLIByIdAsync", Method.POST, toCliDto, Nothing)
        'ApiCall("product/AddOrUpdatePSfromCLIByIdAsync", Method.POST, toCliDto, Nothing)
    End Sub
    Shared Sub ProductAddProductImagesAsync(toCliDto As ToCliDto)

        ApiCallBuffer("product/AddProductImagesAsync", Method.POST, toCliDto, Nothing)
    End Sub
    Shared Sub ProductDeleteProductImagesAsync(toCliDto As ToCliDto)

        ApiCallBuffer("product/DeleteProductImagesAsync", Method.POST, toCliDto, Nothing)
    End Sub
    Shared Sub ProductGetProductDefaultImageIdAsync(toCliDto As ToCliDto, ByRef defaultImageId As List(Of Object))

        ApiCall("product/GetProductDefaultImageIdAsync", Method.POST, toCliDto, Nothing, defaultImageId)
    End Sub
    Shared Function ProductGetImagesPSfromCLIByIdAsync(toCliDto As ToCliDto, ByRef images As List(Of ImageData)) As Boolean

        Return ApiCall("product/GetImagesPSfromCLIByIdAsync", Method.POST, toCliDto, images)
    End Function
    Shared Sub ProductGetProductUrlFromPSAsync(toCliDto As ToCliDto, ByRef url As List(Of Object))

        ApiCall("product/GetProductUrlFromPSAsync", Method.POST, toCliDto, Nothing, url)
    End Sub

    Shared Sub ProductSetProductDefaultImageIdAsync(toCliDto As ToCliDto)

        ApiCallBuffer("product/SetProductDefaultImageIdAsync", Method.POST, toCliDto, Nothing)
    End Sub
    Shared Sub CustomerImportFromCLIAsync(toCliDto As ToCliDto)

        ApiCallBuffer("customer/ImportFromCLIAsync", Method.POST, toCliDto, Nothing)
    End Sub

    Shared Sub OrderUpdateOrderStatusFromCLIByIdAsync(toCliDto As ToCliDto)

        ApiCallBuffer("order/UpdateOrderStatusFromCLIByIdAsync", Method.POST, toCliDto, Nothing)
    End Sub
    Shared Sub OrderSetInvoiceByOrderIdAsync(toCliDto As ToCliDto)

        ApiCallBuffer("order/SetInvoiceByOrderIdAsync", Method.POST, toCliDto, Nothing)
    End Sub
    Shared Function ProductGetUniqueAvailableNowMessagesFromPSAsync(toCliDto As ToCliDto, ByRef messages As List(Of Object)) As Boolean
        Dim images As List(Of ImageData) = Nothing

        Return ApiCall("product/GetUniqueAvailableNowMessagesFromPSAsync", Method.POST, toCliDto, images, messages)
    End Function
    Shared Function ProductGetUniqueAvailableLaterMessagesFromPSAsync(toCliDto As ToCliDto, ByRef messages As List(Of Object)) As Boolean
        Dim images As List(Of ImageData) = Nothing

        Return ApiCall("product/GetUniqueAvailableLaterMessagesFromPSAsync", Method.POST, toCliDto, images, messages)
    End Function
    Shared Sub ProductUpdateAvailableNowMessageAsync(toCliDto As ToCliDto)
        ApiCallBuffer("product/UpdateAvailableNowMessageAsync", Method.POST, toCliDto, Nothing)
    End Sub
    Shared Sub ProductUpdateAvailableLaterMessageAsync(toCliDto As ToCliDto)
        ApiCallBuffer("product/UpdateAvailableLaterMessageAsync", Method.POST, toCliDto, Nothing)
    End Sub

End Class
