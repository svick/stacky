using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a response error.
    /// </summary>
    [JsonObject]
    public class ResponseError
    {
        /// <summary>
        /// Gets or sets the response <see cref="ErrorCode"/>.
        /// </summary>
        /// <value>The response <see cref="ErrorCode"/>.</value>
        [JsonProperty("code"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ErrorCode Code { get; set; }

        /// <summary>
        /// Gets or sets the response error message.
        /// </summary>
        /// <value>The response error message.</value>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}