using Newtonsoft.Json;

namespace StackOverflow
{
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public ResponseError Error { get; set; }
    }
}