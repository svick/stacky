using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace StackOverflow
{
    public class Comment
    {
        [JsonProperty("comment_id")]
        public long Id { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }

        [JsonProperty("owner_user_id")]
        public int OwnerUserId { get; set; }

        [JsonProperty("owner_display_name")]
        public string OwnerDisplayName { get; set; }

        [JsonProperty("post_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PostType PostType { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }

    public enum PostType
    {
        Answer,
        Question,
        Comment
    }
}