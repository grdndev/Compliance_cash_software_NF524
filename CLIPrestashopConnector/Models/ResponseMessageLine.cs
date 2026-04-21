using System;
namespace CLIPrestashopConnector.Models
{
    public class ResponseMessageLine
    {
        public ResponseMessageType Type { get; set; }
        public string Entry { get; set; }
        public string Detail { get; set; }

        public ResponseMessageLine(ResponseMessageType type,string entry,string detail)
        {
            Type = type;
            Entry = entry;
            Detail = detail;
        }

    }

    public enum ResponseMessageType
    {
        Information = 0,
        Warning = 1,
        Error = 2
    }
}

