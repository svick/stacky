using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    public class UserEventResponse : Response
    {
        [JsonProperty("user_timelines")]
        public List<UserEvent> Events { get; set; }
    }
}
