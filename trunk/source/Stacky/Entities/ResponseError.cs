using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a response error.
    /// </summary>
    [JsonObject]
    public class ResponseError : Entity
    {
        private ErrorCode code;
        private string message;

        /// <summary>
        /// Gets or sets the response <see cref="ErrorCode"/>.
        /// </summary>
        /// <value>The response <see cref="ErrorCode"/>.</value>
        [JsonProperty("code"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ErrorCode Code
        {
            get { return code; }
            set { code = value; OnPropertyChanged("Code"); }
        }

        /// <summary>
        /// Gets or sets the response error message.
        /// </summary>
        /// <value>The response error message.</value>
        [JsonProperty("message")]
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }
    }
}