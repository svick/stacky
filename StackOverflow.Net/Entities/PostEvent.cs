using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace StackOverflow
{
    public class PostEvent
    {
        [JsonProperty("timeline_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PostEventType Type { get; set; }

        [JsonProperty("post_id")]
        public int PostId { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("action_user_id")]
        public int ActionUserId { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }
    }

    public enum PostEventType
    {
        Question,
        Answer,
        Comment,
        Revision,
        Votes
    }
}