using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    internal class QuestionResponse : Response
    {
        [JsonProperty("questions")]
        public List<Question> Questions { get; set; }
    }
}