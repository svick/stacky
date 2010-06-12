using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    public class CommentResponse : Response
    {
        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }
    }
}
