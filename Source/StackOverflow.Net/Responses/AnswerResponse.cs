using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    public class AnswerResponse : Response
    {
        [JsonProperty("answers")]
        public List<Answer> Answers { get; set; }
    }
}
