using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIPrestashopConnector.Models
{
    public class AppSettings
    {
        public string ConnectionStringCLI { get; set; }
        public string Endpoint { get; set; }
        public string ApiKey { get; set; }
        public string Password { get; set; }
        public string PrestashopBaseUrl { get; set; }
        public string InvoicePath { get; set; }
        public string MiscellaneousPath { get; set; }
        public string NoPhotoName { get; set; }
        public string WebSiteTitle { get; set; }
        public string NotificationServerUrl { get; set; }
        public string NotificationServerChannel { get; set; }
        public string NotificationServerUser { get; set; }
        public string NotificationServerPwd { get; set; }
    }
}
