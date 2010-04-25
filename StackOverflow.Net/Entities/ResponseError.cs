using System.Xml.Serialization;
using Newtonsoft.Json;

namespace StackOverflow
{
    [JsonObject]
    public class ResponseError
    {
        [JsonProperty("code")]
        public ErrorCode Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}