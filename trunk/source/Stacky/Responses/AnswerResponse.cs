using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    public class AnswerResponse : Response
    {
        [JsonProperty("answers")]
        public List<Answer> Answers { get; set; }
    }
}
