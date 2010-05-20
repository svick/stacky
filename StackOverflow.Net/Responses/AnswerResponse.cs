using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    internal class AnswerResponse : Response
    {
        [JsonProperty("answers")]
        public List<Answer> Answers { get; set; }
    }
}
