using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    internal class QuestionTimelineResponse
    {
        [JsonProperty("post_timelines")]
        public List<PostEvent> Events { get; set; }
    }
}
