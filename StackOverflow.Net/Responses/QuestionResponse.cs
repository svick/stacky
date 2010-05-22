using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    public class QuestionResponse : Response
    {
        [JsonProperty("questions")]
        public List<Question> Questions { get; set; }
    }
}