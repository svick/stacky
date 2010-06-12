using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    [JsonObject]
    public class ResponseError
    {
        [JsonProperty("code"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ErrorCode Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}