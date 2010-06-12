using Newtonsoft.Json;

namespace Stacky
{
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public ResponseError Error { get; set; }
    }
}