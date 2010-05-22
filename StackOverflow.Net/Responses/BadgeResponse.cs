using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    public class BadgeResponse : Response
    {
        [JsonProperty("badges")]
        public List<Badge> Badges { get; set; }
    }
}
