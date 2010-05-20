using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    internal class TagResponse : Response
    {
        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }
    }
}
