using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    internal class StatsResponse
    {
        [JsonProperty("statistics")]
        public List<SiteStats> Statistics { get; set; }
    }
}
