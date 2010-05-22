using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    public class StatsResponse
    {
        [JsonProperty("statistics")]
        public List<SiteStats> Statistics { get; set; }
    }
}
