using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    public class User
    {
        public User()
        {
            BadgeCounts = new BadgeCounts();
        }

        [JsonProperty("user_id")]
        public long Id { get; set; }

        [JsonProperty("user_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public UserType Type { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }

        [JsonProperty("reputation")]
        public int Reputation { get; set; }

        [JsonProperty("email_hash")]
        public string EmailHash { get; set; }

        public string GravatarUrl { get { return String.Format("http://www.gravatar.com/avatar/{0}?d=identicon&r=PG", EmailHash); } }

        [JsonProperty("age")]
        public int? Age { get; set; }
        [JsonProperty("last_access_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastAccessDate { get; set; }

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

        [JsonProperty("badge_counts")]
        public BadgeCounts BadgeCounts { get; set; }

        [JsonProperty("user_questions_url")]
        public string QuestionsUrl { get; set; }

        [JsonProperty("user_answers_url")]
        public string AnswersUrl { get; set; }

        [JsonProperty("user_favorites_url")]
        public string FavoritesUrl { get; set; }

        [JsonProperty("user_tags_url")]
        public string TagsUrl { get; set; }

        [JsonProperty("user_badges_url")]
        public string BadgesUrl { get; set; }

        [JsonProperty("user_timeline_url")]
        public string TimelineUrl { get; set; }

        [JsonProperty("user_mentioned_url")]
        public string MentionedUrl { get; set; }

        [JsonProperty("user_comments_url")]
        public string CommentsUrl { get; set; }

        [JsonProperty("user_reputation_url")]
        public string ReputationUrl { get; set; }
    }

    public enum UserType
    {
        Anonymous,
        Unregistered,
        Registered,
        Moderator
    }
}