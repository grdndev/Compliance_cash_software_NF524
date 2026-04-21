using System;
using System.Runtime.CompilerServices;
using System.Net.Http.Headers;
using System.Text;
using CLIPrestashopConnector.Models;
using Microsoft.Extensions.Options;

namespace CLIPrestashopConnector.Services.Push
{
	public class PushService : IPushService
	{

        private readonly AppSettings _appSettings;
public PushService(IOptions<AppSettings> appSettings)
{
               _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
    
}
public async Task<bool> Notify(string Title, string Detail)
{
    // Send a POST request to https://dev.chinook-leucate.com:8180/cli
    using (var client = new HttpClient())
    {
       

            var authValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_appSettings.NotificationServerUser}:{_appSettings.NotificationServerPwd}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authValue);
            client.DefaultRequestHeaders.Add("Tag", "surfing_man");

        var url = $"{_appSettings.NotificationServerUrl}/{_appSettings.NotificationServerChannel}";
        var content = new StringContent(Detail, Encoding.UTF8, "text/plain");
        var response = await client.PostAsync(url, content);

     
    }
    return true;
}  
    }
}
