using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    public class BadgeResponse : Response
    {
        [JsonProperty("badges")]
        public List<Badge> Badges { get; set; }
    }
}
