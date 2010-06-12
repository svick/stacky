using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    public class StatsResponse
    {
        [JsonProperty("statistics")]
        public List<SiteStats> Statistics { get; set; }
    }
}
