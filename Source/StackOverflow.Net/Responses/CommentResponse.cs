using System.Collections.Generic;
using Newtonsoft.Json;

namespace StackOverflow
{
    public class CommentResponse : Response
    {
        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }
    }
}
