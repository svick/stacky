using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    public class SitesResponse
    {
        [JsonProperty("api_sites")]
        public List<Site> Sites { get; set; }
    }
}