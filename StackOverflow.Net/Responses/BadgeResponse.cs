using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    internal class BadgeResponse : Response
    {
        [JsonProperty("badges")]
        public List<Badge> Badges { get; set; }
    }
}
