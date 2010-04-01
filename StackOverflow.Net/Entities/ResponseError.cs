using System.Xml.Serialization;
using Newtonsoft.Json;

namespace StackOverflow
{
    [JsonObject]
    public class ResponseError
    {
        [XmlAttribute("Code"), JsonProperty("Code")]
        public int ErrorCode { get; set; }
        [XmlAttribute("Message"), JsonProperty("Message")]
        public string Message { get; set; }
    }
}