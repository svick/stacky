﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace StackOverflow
{
    public class User
    {
        [JsonProperty("user_id")]
        public long Id { get; set; }
        [JsonProperty("user_type")]
        public string Type { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("creation_date")]
        public long CreationDate { get; set; }
        [JsonProperty("reputation")]
        public int Reputation { get; set; }
        [JsonProperty("email_hash")]
        public string EmailHash { get; set; }
        [JsonProperty("age")]
        public int? Age { get; set; }
        [JsonProperty("last_access_date")]
        public long LastAccessDate { get; set; }
        [JsonProperty("website_url")]
        public string Website { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("about_me")]
        public string AboutMe { get; set; }
        [JsonProperty("question_count")]
        public int QuestionCount { get; set; }
        [JsonProperty("answer_count")]
        public int AnswerCount { get; set; }
        [JsonProperty("view_count")]
        public int ViewCount { get; set; }
        [JsonProperty("up_vote_count")]
        public int UpVotes { get; set; }
        [JsonProperty("down_vote_count")]
        public int DownVotes { get; set; }
        [JsonProperty("accept_rate")]
        public int? AcceptRate { get; set; }
    }

    public enum UserType
    {
        Anonymous,
        Unregistered,
        Registered,
        Moderator
    }
}