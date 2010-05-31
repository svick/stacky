using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    public class QuestionTimelineResponse
    {
        [JsonProperty("post_timelines")]
        public List<PostEvent> Events { get; set; }
    }
}
