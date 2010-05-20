using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    internal class RevisionResponse : Response
    {
        [JsonProperty("revisions")]
        public List<Revision> Revisions { get; set; }
    }
}
