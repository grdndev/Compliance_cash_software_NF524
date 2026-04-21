Public Class FormApiCall
    Private Sub FormApiCall_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = ExecuteRequeteR("select Top(100) [id]
      ,[CreatedDate]
      ,[Url]
      ,[Params]
      ,[HttpMethod]
      ,[CallDate] from t_apicall order by CreatedDate desc", gCnn.ConnectionString)

    End Sub
End Class