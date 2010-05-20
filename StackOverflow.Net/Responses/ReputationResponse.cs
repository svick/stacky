using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    internal class ReputationResponse : Response
    {
        [JsonProperty("rep_changes")]
        public List<Reputation> Reputation { get; set; }
    }
}
