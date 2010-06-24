using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            BadgeCounts = new BadgeCounts();
        }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        [JsonProperty("user_id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="UserType"/>.
        /// </summary>
        /// <value>The <see cref="UserType"/>.</value>
        [JsonProperty("user_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public UserType Type { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the reputation.
        /// </summary>
        /// <value>The reputation.</value>
        [JsonProperty("reputation")]
        public int Reputation { get; set; }

        /// <summary>
        /// Gets or sets the email hash.
        /// </summary>
        /// <value>The email hash.</value>
        [JsonProperty("email_hash")]
        public string EmailHash { get; set; }

        /// <summary>
        /// Gets the gravatar URL.
        /// </summary>
        /// <value>The gravatar URL.</value>
        public string GravatarUrl { get { return String.Format("http://www.gravatar.com/avatar/{0}?d=identicon&r=PG", EmailHash); } }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>The age.</value>
        [JsonProperty("age")]
        public int? Age { get; set; }

        /// <summary>
        /// Gets or sets the last access date.
        /// </summary>
        /// <value>The last access date.</value>
        [JsonProperty("last_access_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastAccessDate { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>The website.</value>
        [JsonProperty("website_url")]
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the about me.
        /// </summary>
        /// <value>The about me.</value>
        [JsonProperty("about_me")]
        public string AboutMe { get; set; }

        /// <summary>
        /// Gets or sets the question count.
        /// </summary>
        /// <value>The question count.</value>
        [JsonProperty("question_count")]
        public int QuestionCount { get; set; }

        /// <summary>
        /// Gets or sets the answer count.
        /// </summary>
        /// <value>The answer count.</value>
        [JsonProperty("answer_count")]
        public int AnswerCount { get; set; }

        /// <summary>
        /// Gets or sets the view count.
        /// </summary>
        /// <value>The view count.</value>
        [JsonProperty("view_count")]
        public int ViewCount { get; set; }

        /// <summary>
        /// Gets or sets up votes.
        /// </summary>
        /// <value>Up votes.</value>
        [JsonProperty("up_vote_count")]
        public int UpVotes { get; set; }

        /// <summary>
        /// Gets or sets down votes.
        /// </summary>
        /// <value>Down votes.</value>
        [JsonProperty("down_vote_count")]
        public int DownVotes { get; set; }

        /// <summary>
        /// Gets or sets the accept rate.
        /// </summary>
        /// <value>The accept rate.</value>
        [JsonProperty("accept_rate")]
        public int? AcceptRate { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="BadgeCounts"/>.
        /// </summary>
        /// <value>The <see cref="BadgeCounts"/>.</value>
        [JsonProperty("badge_counts")]
        public BadgeCounts BadgeCounts { get; set; }

        /// <summary>
        /// Gets or sets a global <see cref="System.Guid"/> which identifies
        /// this user across stack app sites.
        /// </summary>
        [JsonProperty("association_id")]
        public Guid AssociationId { get; set; }

        /// <summary>
        /// Gets or sets the questions URL.
        /// </summary>
        /// <value>The questions URL.</value>
        [JsonProperty("user_questions_url")]
        public string QuestionsUrl { get; set; }

        /// <summary>
        /// Gets or sets the answers URL.
        /// </summary>
        /// <value>The answers URL.</value>
        [JsonProperty("user_answers_url")]
        public string AnswersUrl { get; set; }

        /// <summary>
        /// Gets or sets the favorites URL.
        /// </summary>
        /// <value>The favorites URL.</value>
        [JsonProperty("user_favorites_url")]
        public string FavoritesUrl { get; set; }

        /// <summary>
        /// Gets or sets the tags URL.
        /// </summary>
        /// <value>The tags URL.</value>
        [JsonProperty("user_tags_url")]
        public string TagsUrl { get; set; }

        /// <summary>
        /// Gets or sets the badges URL.
        /// </summary>
        /// <value>The badges URL.</value>
        [JsonProperty("user_badges_url")]
        public string BadgesUrl { get; set; }

        /// <summary>
        /// Gets or sets the timeline URL.
        /// </summary>
        /// <value>The timeline URL.</value>
        [JsonProperty("user_timeline_url")]
        public string TimelineUrl { get; set; }

        /// <summary>
        /// Gets or sets the mentioned URL.
        /// </summary>
        /// <value>The mentioned URL.</value>
        [JsonProperty("user_mentioned_url")]
        public string MentionedUrl { get; set; }

        /// <summary>
        /// Gets or sets the comments URL.
        /// </summary>
        /// <value>The comments URL.</value>
        [JsonProperty("user_comments_url")]
        public string CommentsUrl { get; set; }

        /// <summary>
        /// Gets or sets the reputation URL.
        /// </summary>
        /// <value>The reputation URL.</value>
        [JsonProperty("user_reputation_url")]
        public string ReputationUrl { get; set; }
    }

    /// <summary>
    /// Specifies the user type.
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// Anonymous user.
        /// </summary>
        Anonymous,
        /// <summary>
        /// Unregistered user.
        /// </summary>
        Unregistered,
        /// <summary>
        /// Registered user.
        /// </summary>
        Registered,
        /// <summary>
        /// Moderator user.
        /// </summary>
        Moderator
    }
}