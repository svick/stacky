using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents site statistics.
    /// </summary>
    public class SiteStats
    {
        /// <summary>
        /// Gets or sets the total questions.
        /// </summary>
        /// <value>The total questions.</value>
        [JsonProperty("total_questions")]
        public long TotalQuestions { get; set; }

        /// <summary>
        /// Gets or sets the total unanswered questions.
        /// </summary>
        /// <value>The total unanswered questions.</value>
        [JsonProperty("total_unanswered")]
        public long TotalUnanswered { get; set; }

        /// <summary>
        /// Gets or sets the total answers.
        /// </summary>
        /// <value>The total answers.</value>
        [JsonProperty("total_answers")]
        public long TotalAnswers { get; set; }

        /// <summary>
        /// Gets or sets the total comments.
        /// </summary>
        /// <value>The total comments.</value>
        [JsonProperty("total_comments")]
        public long TotalComments { get; set; }

        /// <summary>
        /// Gets or sets the total votes.
        /// </summary>
        /// <value>The total votes.</value>
        [JsonProperty("total_votes")]
        public long TotalVotes { get; set; }

        /// <summary>
        /// Gets or sets the total badges.
        /// </summary>
        /// <value>The total badges.</value>
        [JsonProperty("total_badges")]
        public long TotalBadges { get; set; }

        /// <summary>
        /// Gets or sets the total users.
        /// </summary>
        /// <value>The total users.</value>
        [JsonProperty("total_users")]
        public long TotalUsers { get; set; }

        /// <summary>
        /// Gets or sets the questions per minute.
        /// </summary>
        /// <value>The questions per minute.</value>
        [JsonProperty("questions_per_minute")]
        public double QuestionsPerMinute { get; set; }

        /// <summary>
        /// Gets or sets the answers per minute.
        /// </summary>
        /// <value>The answers per minute.</value>
        [JsonProperty("answers_per_minute")]
        public double AnswersPerMinute { get; set; }

        /// <summary>
        /// Gets or sets the badges per minute.
        /// </summary>
        /// <value>The badges per minute.</value>
        [JsonProperty("badges_per_minute")]
        public double BadgesPerMinute { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ApiVersion">API version</see>.
        /// </summary>
        /// <value>The <see cref="ApiVersion">API version</see>.</value>
        [JsonProperty("api_version")]
        public ApiVersion ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        [JsonProperty("site")]
        public Site Site { get; set; }
    }

    /// <summary>
    /// Represents the API version.
    /// </summary>
    public class ApiVersion
    {
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        [JsonProperty("version")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the revision.
        /// </summary>
        /// <value>The revision.</value>
        [JsonProperty("revision")]
        public string Revision { get; set; }
    }
}