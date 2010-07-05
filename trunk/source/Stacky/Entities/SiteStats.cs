using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents site statistics.
    /// </summary>
    public class SiteStats : Entity
    {
        private int totalQuestions;
        private int totalUnanswered;
        private int totalAnswers;
        private int totalComments;
        private int totalVotes;
        private int totalBadges;
        private int totalUsers;
        private double questionsPerMinute;
        private double answersPerMinute;
        private double badgesPerMinute;
        private ApiVersion apiVersion;
        private Site site;

        /// <summary>
        /// Gets or sets the total questions.
        /// </summary>
        /// <value>The total questions.</value>
        [JsonProperty("total_questions")]
        public int TotalQuestions
        {
            get { return totalQuestions; }
            set { totalQuestions = value; OnPropertyChanged("TotalQuestions"); }
        }

        /// <summary>
        /// Gets or sets the total unanswered questions.
        /// </summary>
        /// <value>The total unanswered questions.</value>
        [JsonProperty("total_unanswered")]
        public int TotalUnanswered
        {
            get { return totalUnanswered; }
            set { totalUnanswered = value; OnPropertyChanged("TotalUnanswered"); }
        }

        /// <summary>
        /// Gets or sets the total answers.
        /// </summary>
        /// <value>The total answers.</value>
        [JsonProperty("total_answers")]
        public int TotalAnswers
        {
            get { return totalAnswers; }
            set { totalAnswers = value; OnPropertyChanged("TotalAnswers"); }
        }

        /// <summary>
        /// Gets or sets the total comments.
        /// </summary>
        /// <value>The total comments.</value>
        [JsonProperty("total_comments")]
        public int TotalComments
        {
            get { return totalComments; }
            set { totalComments = value; OnPropertyChanged("TotalComments"); }
        }

        /// <summary>
        /// Gets or sets the total votes.
        /// </summary>
        /// <value>The total votes.</value>
        [JsonProperty("total_votes")]
        public int TotalVotes
        {
            get { return totalVotes; }
            set { totalVotes = value; OnPropertyChanged("TotalVotes"); }
        }

        /// <summary>
        /// Gets or sets the total badges.
        /// </summary>
        /// <value>The total badges.</value>
        [JsonProperty("total_badges")]
        public int TotalBadges
        {
            get { return totalBadges; }
            set { totalBadges = value; OnPropertyChanged("TotalBadges"); }
        }

        /// <summary>
        /// Gets or sets the total users.
        /// </summary>
        /// <value>The total users.</value>
        [JsonProperty("total_users")]
        public int TotalUsers
        {
            get { return totalUsers; }
            set { totalUsers = value; OnPropertyChanged("TotalUsers"); }
        }

        /// <summary>
        /// Gets or sets the questions per minute.
        /// </summary>
        /// <value>The questions per minute.</value>
        [JsonProperty("questions_per_minute")]
        public double QuestionsPerMinute
        {
            get { return questionsPerMinute; }
            set { questionsPerMinute = value; OnPropertyChanged("QuestionsPerMinute"); }
        }

        /// <summary>
        /// Gets or sets the answers per minute.
        /// </summary>
        /// <value>The answers per minute.</value>
        [JsonProperty("answers_per_minute")]
        public double AnswersPerMinute
        {
            get { return answersPerMinute; }
            set { answersPerMinute = value; OnPropertyChanged("AnswersPerMinute"); }
        }

        /// <summary>
        /// Gets or sets the badges per minute.
        /// </summary>
        /// <value>The badges per minute.</value>
        [JsonProperty("badges_per_minute")]
        public double BadgesPerMinute
        {
            get { return badgesPerMinute; }
            set { badgesPerMinute = value; OnPropertyChanged("BadgesPerMinute"); }
        }

        /// <summary>
        /// Gets or sets the <see cref="ApiVersion">API version</see>.
        /// </summary>
        /// <value>The <see cref="ApiVersion">API version</see>.</value>
        [JsonProperty("api_version")]
        public ApiVersion ApiVersion
        {
            get { return apiVersion; }
            set { apiVersion = value; OnPropertyChanged("ApiVersion"); }
        }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        [JsonProperty("site")]
        public Site Site
        {
            get { return site; }
            set { site = value; OnPropertyChanged("Site"); }
        }
    }
}