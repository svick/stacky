using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    public class Answer
    {
        public Answer()
        {
            Comments = new List<Comment>();
        }

        [JsonProperty("answer_id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("accepted")]
        public bool Accepted { get; set; }

        [JsonProperty("question_id")]
        public int QuestionId { get; set; }

        [JsonProperty("owner_user_id")]
        public int OwnerUserId { get; set; }

        [JsonProperty("owner_display_name")]
        public string OwnerDisplayName { get; set; }

        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }

        [JsonProperty("last_activity_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastActivityDate { get; set; }

        [JsonProperty("last_edit_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastEditDate { get; set; }

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
        public bool CommunityOwned { get; set; }

        public List<Comment> Comments { get; set; }

        [JsonProperty("answer_comments_url")]
        public string CommentsUrl { get; set; }
    }
}