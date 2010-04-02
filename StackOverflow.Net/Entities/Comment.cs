﻿using System;
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
        [JsonProperty("creation_date")]
        public long CreationDate { get; set; }
        [JsonProperty("owner_user_id")]
        public int OwnerUserId { get; set; }
        [JsonProperty("owner_display_name")]
        public string OwnerDisplayName { get; set; }
        [JsonProperty("post_type")]
        public string PostType { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }
    }
}