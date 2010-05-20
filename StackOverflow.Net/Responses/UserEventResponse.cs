using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    internal class UserEventResponse : Response
    {
        [JsonProperty("user_timelines")]
        public List<UserEvent> Events { get; set; }
    }
}
