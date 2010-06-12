using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    public class SiteStats
    {
        [JsonProperty("total_questions")]
        public long TotalQuestions { get; set; }

        [JsonProperty("total_unanswered")]
        public long TotalUnanswered { get; set; }

        [JsonProperty("total_answers")]
        public long TotalAnswers { get; set; }

        [JsonProperty("total_comments")]
        public long TotalComments { get; set; }

        [JsonProperty("total_votes")]
        public long TotalVotes { get; set; }

        [JsonProperty("total_badges")]
        public long TotalBadges { get; set; }
         
        [JsonProperty("total_users")]
        public long TotalUsers { get; set; }

        [JsonProperty("questions_per_minute")]
        public double QuestionsPerMinute { get; set; }

        [JsonProperty("answers_per_minute")]
        public double AnswersPerMinute { get; set; }

        [JsonProperty("badges_per_minute")]
        public double BadgesPerMinute { get; set; }

        [JsonProperty("api_version")]
        public ApiVersion ApiVersion { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }

    public class ApiVersion
    {
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("revision")]
        public string Revision { get; set; }
    }
}