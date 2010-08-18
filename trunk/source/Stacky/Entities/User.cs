using System;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    public class User : Entity
    {
        private BadgeCounts badgeCounts = new BadgeCounts();
        private int id;
        private UserType type;
        private string displayName;
        private DateTime creationDate;
        private int reputation;
        private string emailHash;
        private int? age;
        private string website;
        private DateTime lastAccessDate;
        private string webSite;
        private string location;
        private string aboutMe;
        private int questionCount;
        private int answerCount;
        private int viewCount;
        private int upVotes;
        private int downVotes;
        private int? acceptRate;
        private Guid associationId;
        private string questionsUrl;
        private string answersUrl;
        private string favoritesUrl;
        private string tagsUrl;
        private string badgesUrl;
        private string timelineUrl;
        private string mentionedUrl;
        private string commentsUrl;
        private string reputationUrl;

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        [JsonProperty("user_id")]
        public int Id
        {
            get { return id; }
            set { id = value; NotifyOfPropertyChange(() => Id); }
        }

        /// <summary>
        /// Gets or sets the <see cref="UserType"/>.
        /// </summary>
        /// <value>The <see cref="UserType"/>.</value>
        [JsonProperty("user_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public UserType Type
        {
            get { return type; }
            set { type = value; NotifyOfPropertyChange(() => Type); }
        }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        [JsonProperty("display_name")]
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; NotifyOfPropertyChange(() => DisplayName); }
        }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; NotifyOfPropertyChange(() => CreationDate); }
        }

        /// <summary>
        /// Gets or sets the reputation.
        /// </summary>
        /// <value>The reputation.</value>
        [JsonProperty("reputation")]
        public int Reputation
        {
            get { return reputation; }
            set { reputation = value; NotifyOfPropertyChange(() => Reputation); }
        }

        /// <summary>
        /// Gets or sets the email hash.
        /// </summary>
        /// <value>The email hash.</value>
        [JsonProperty("email_hash")]
        public string EmailHash
        {
            get { return emailHash; }
            set { emailHash = value; NotifyOfPropertyChange(() => EmailHash); NotifyOfPropertyChange(() => GravatarUrl); }
        }

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
        public int? Age
        {
            get { return age; }
            set { age = value; NotifyOfPropertyChange(() => Age); }
        }

        /// <summary>
        /// Gets or sets the last access date.
        /// </summary>
        /// <value>The last access date.</value>
        [JsonProperty("last_access_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastAccessDate
        {
            get { return lastAccessDate; }
            set { lastAccessDate = value; NotifyOfPropertyChange(() => LastAccessDate); }
        }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>The website.</value>
        [JsonProperty("website_url")]
        public string Website
        {
            get { return website; }
            set { website = value; NotifyOfPropertyChange(() => Website); }
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        [JsonProperty("location")]
        public string Location
        {
            get { return location; }
            set { location = value; NotifyOfPropertyChange(() => Location); }
        }

        /// <summary>
        /// Gets or sets the about me.
        /// </summary>
        /// <value>The about me.</value>
        [JsonProperty("about_me")]
        public string AboutMe
        {
            get { return aboutMe; }
            set { aboutMe = value; NotifyOfPropertyChange(() => AboutMe); }
        }

        /// <summary>
        /// Gets or sets the question count.
        /// </summary>
        /// <value>The question count.</value>
        [JsonProperty("question_count")]
        public int QuestionCount
        {
            get { return questionCount; }
            set { questionCount = value; NotifyOfPropertyChange(() => QuestionCount); }
        }

        /// <summary>
        /// Gets or sets the answer count.
        /// </summary>
        /// <value>The answer count.</value>
        [JsonProperty("answer_count")]
        public int AnswerCount
        {
            get { return answerCount; }
            set { answerCount = value; NotifyOfPropertyChange(() => AnswerCount); }
        }

        /// <summary>
        /// Gets or sets the view count.
        /// </summary>
        /// <value>The view count.</value>
        [JsonProperty("view_count")]
        public int ViewCount
        {
            get { return viewCount; }
            set { viewCount = value; NotifyOfPropertyChange(() => ViewCount); }
        }

        /// <summary>
        /// Gets or sets up votes.
        /// </summary>
        /// <value>Up votes.</value>
        [JsonProperty("up_vote_count")]
        public int UpVotes
        {
            get { return upVotes; }
            set { upVotes = value; NotifyOfPropertyChange(() => UpVotes); }
        }

        /// <summary>
        /// Gets or sets down votes.
        /// </summary>
        /// <value>Down votes.</value>
        [JsonProperty("down_vote_count")]
        public int DownVotes
        {
            get { return downVotes; }
            set { downVotes = value; NotifyOfPropertyChange(() => DownVotes); }
        }

        /// <summary>
        /// Gets or sets the accept rate.
        /// </summary>
        /// <value>The accept rate.</value>
        [JsonProperty("accept_rate")]
        public int? AcceptRate
        {
            get { return acceptRate; }
            set { acceptRate = value; NotifyOfPropertyChange(() => AcceptRate); }
        }

        /// <summary>
        /// Gets or sets the <see cref="BadgeCounts"/>.
        /// </summary>
        /// <value>The <see cref="BadgeCounts"/>.</value>
        [JsonProperty("badge_counts")]
        public BadgeCounts BadgeCounts
        {
            get { return badgeCounts; }
            set { badgeCounts = value; NotifyOfPropertyChange(() => BadgeCounts); }
        }

        /// <summary>
        /// Gets or sets a global <see cref="System.Guid"/> which identifies
        /// this user across stack app sites.
        /// </summary>
        [JsonProperty("association_id")]
        public Guid AssociationId
        {
            get { return associationId; }
            set { associationId = value; NotifyOfPropertyChange(() => AssociationId); }
        }

        /// <summary>
        /// Gets or sets the questions URL.
        /// </summary>
        /// <value>The questions URL.</value>
        [JsonProperty("user_questions_url")]
        public string QuestionsUrl
        {
            get { return questionsUrl; }
            set { questionsUrl = value; NotifyOfPropertyChange(() => QuestionsUrl); }
        }

        /// <summary>
        /// Gets or sets the answers URL.
        /// </summary>
        /// <value>The answers URL.</value>
        [JsonProperty("user_answers_url")]
        public string AnswersUrl
        {
            get { return answersUrl; }
            set { answersUrl = value; NotifyOfPropertyChange(() => AnswersUrl); }
        }

        /// <summary>
        /// Gets or sets the favorites URL.
        /// </summary>
        /// <value>The favorites URL.</value>
        [JsonProperty("user_favorites_url")]
        public string FavoritesUrl
        {
            get { return favoritesUrl; }
            set { favoritesUrl = value; NotifyOfPropertyChange(() => FavoritesUrl); }
        }

        /// <summary>
        /// Gets or sets the tags URL.
        /// </summary>
        /// <value>The tags URL.</value>
        [JsonProperty("user_tags_url")]
        public string TagsUrl
        {
            get { return tagsUrl; }
            set { tagsUrl = value; NotifyOfPropertyChange(() => TagsUrl); }
        }

        /// <summary>
        /// Gets or sets the badges URL.
        /// </summary>
        /// <value>The badges URL.</value>
        [JsonProperty("user_badges_url")]
        public string BadgesUrl
        {
            get { return badgesUrl; }
            set { badgesUrl = value; NotifyOfPropertyChange(() => BadgesUrl); }
        }

        /// <summary>
        /// Gets or sets the timeline URL.
        /// </summary>
        /// <value>The timeline URL.</value>
        [JsonProperty("user_timeline_url")]
        public string TimelineUrl
        {
            get { return timelineUrl; }
            set { timelineUrl = value; NotifyOfPropertyChange(() => TimelineUrl); }
        }

        /// <summary>
        /// Gets or sets the mentioned URL.
        /// </summary>
        /// <value>The mentioned URL.</value>
        [JsonProperty("user_mentioned_url")]
        public string MentionedUrl
        {
            get { return mentionedUrl; }
            set { mentionedUrl = value; NotifyOfPropertyChange(() => MentionedUrl); }
        }

        /// <summary>
        /// Gets or sets the comments URL.
        /// </summary>
        /// <value>The comments URL.</value>
        [JsonProperty("user_comments_url")]
        public string CommentsUrl
        {
            get { return commentsUrl; }
            set { commentsUrl = value; NotifyOfPropertyChange(() => CommentsUrl); }
        }

        /// <summary>
        /// Gets or sets the reputation URL.
        /// </summary>
        /// <value>The reputation URL.</value>
        [JsonProperty("user_reputation_url")]
        public string ReputationUrl
        {
            get { return reputationUrl; }
            set { reputationUrl = value; NotifyOfPropertyChange(() => ReputationUrl); }
        }
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