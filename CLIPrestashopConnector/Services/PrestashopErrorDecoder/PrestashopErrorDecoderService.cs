using System;
using System.Text.RegularExpressions;
using System.Xml;
using Newtonsoft.Json;

namespace CLIPrestashopConnector.Services.PrestashopErrorDecoder
{
	public class PrestashopErrorDecoderService :IPrestashopErrorDecoderService
	{
		public PrestashopErrorDecoderService()
		{
		}

        public List<string> Decode(string input)
        {
            //var pattern = @"\<.*\>";
            var pattern = @"(?<=^|>)[^<]*(?=<|$)";
            var match = Regex.Match(input, pattern, RegexOptions.Multiline | RegexOptions.Singleline);
            if (match.Success)
            {
                
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(match.Groups[0].Value);

                string json = JsonConvert.SerializeXmlNode(doc);
                var dynamicObject = JsonConvert.DeserializeObject<dynamic>(json)!;

            }

            return new List<string>();


        }
    }
}

