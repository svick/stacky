using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    public abstract class Response
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("page")]
        public int CurrentPage { get; set; }

        [JsonProperty("pagesize")]
        public int PageSize { get; set; }

        public ResponseError Error { get; set; }
    }
}