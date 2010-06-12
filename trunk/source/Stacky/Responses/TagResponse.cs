using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    public class TagResponse : Response
    {
        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }
    }
}
