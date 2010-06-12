using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    public class ReputationResponse : Response
    {
        [JsonProperty("rep_changes")]
        public List<Reputation> Reputation { get; set; }
    }
}
