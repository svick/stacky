using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    public class QuestionTimelineResponse : Response
    {
        [JsonProperty("post_timelines")]
        public List<PostEvent> Events { get; set; }
    }
}
