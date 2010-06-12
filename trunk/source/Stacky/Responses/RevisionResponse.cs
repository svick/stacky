using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    public class RevisionResponse : Response
    {
        [JsonProperty("revisions")]
        public List<Revision> Revisions { get; set; }
    }
}
