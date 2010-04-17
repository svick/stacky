using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace StackOverflow
{
    [JsonObject]
    public class Question
    {
        public Question()
        {
            Tags = new List<string>();
            Answers = new List<Answer>();
            Comments = new List<Comment>();
        }

        [JsonProperty("question_id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("answer_count")]
        public int AnswerCount { get; set; }

        [JsonProperty("owner_user_id")]
        public int OwnerUserId { get; set; }

        [JsonProperty("owner_display_name")]
        public string OwnerDisplayName { get; set; }

        [JsonProperty("owner_email_hash")]
        public string OwnerEmailHash { get; set; }

        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }

        [JsonProperty("last_activity_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastActivityDate { get; set; }

        [JsonProperty("last_edit_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastEditDate { get; set; }

        [JsonProperty("locked_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LockedDate { get; set; }

        [JsonProperty("closed_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ClosedDate { get; set; }

        [JsonProperty("closed_reason")]
        public int ClosedReason { get; set; }

        [JsonProperty("up_vote_count")]
        public int UpVoteCount { get; set; }

        [JsonProperty("down_vote_count")]
        public int DownVoteCount { get; set; }

        [JsonProperty("favorite_count")]
        public int FavoriteCount { get; set; }

        [JsonProperty("view_count")]
        public int ViewCount { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("community_owned")]
        public string CommunityOwned { get; set; }

        [JsonProperty("accepted_answer_id")]
        public int AcceptedAnswerId { get; set; }

        [JsonProperty("bounty_amount")]
        public int BountyAmount { get; set; }

        public List<string> Tags { get; set; }

        public List<Answer> Answers { get; set; }

        public List<Comment> Comments { get; set; }
    }
}