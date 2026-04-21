using System;
namespace CLIPrestashopConnector.Models
{
    public class ResponseMessage
    {
        public List<ResponseMessageLine> ResponseMessageLines { get; set; }
        public List<ImageData> ImageDatas { get; set; }
        public List<Object> Objects { get; set; }
        public bool ConstainsError {
            get
            {
                return ResponseMessageLines.Where(c => c.Type == ResponseMessageType.Error).Count() > 0;
            }
        }

        public ResponseMessage()
        {
            ResponseMessageLines = new List<ResponseMessageLine>();
            ImageDatas = new List<ImageData>();
            Objects = new List<object>();

        }

        public void AddResponseMessageLine(ResponseMessageType type, string entry, string detail="")
        {
            ResponseMessageLines.Add(new ResponseMessageLine(type, entry, detail));
        }

        public void AddResponseMessageLinesFromResponseMessage(ResponseMessage responseMessage)
        {
            foreach (var responMessageLine in responseMessage.ResponseMessageLines)
            {
                ResponseMessageLines.Add(new ResponseMessageLine(responMessageLine.Type, responMessageLine.Entry, responMessageLine.Detail));
            }
           
        }

    }
}

