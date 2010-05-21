using Newtonsoft.Json;

namespace StackOverflow
{
    internal class ErrorResponse
    {
        [JsonProperty("error")]
        public ResponseError Error { get; set; }
    }
}