using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    public class TagResponse : Response
    {
        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }
    }
}
