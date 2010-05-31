using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    public class RevisionResponse : Response
    {
        [JsonProperty("revisions")]
        public List<Revision> Revisions { get; set; }
    }
}
