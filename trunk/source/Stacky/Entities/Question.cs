using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a question.
    /// </summary>
    [JsonObject]
    public class Question : Entity
    {
        #region private members

        private List<string> tags = new List<string>();
        private List<Answer> answers = new List<Answer>();
        private List<Comment> comments = new List<Comment>();
        private int id;
        private string title;
        private string body;
        private int answerCount;
        private DateTime creationDate;
        private DateTime lastActivityDate;
        private DateTime lastEditDate;
        private DateTime lockedDate;
        private DateTime closedDate;
        private string closedReason;
        private int upVoteCount;
        private int downVoteCount;
        private int favoriteCount;
        private int viewCount;
        private int score;
        private bool communityOwned;
        private int acceptedAnswerId;
        private int bountyAmount;
        private string timelineUrl;
        private string commentsUrl;
        private MigrationInfo migrated;
        private UserInfo owner;

        #endregion

        /// <summary>
        /// Gets or sets the <see cref="Question"/> id.
        /// </summary>
        /// <value>The <see cref="Question"/> id.</value>
        [JsonProperty("question_id")]
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Question"/> title.
        /// </summary>
        /// <value>The <see cref="Question"/> title.</value>
        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged("Title"); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Question"/> body.
        /// </summary>
        /// <value>The <see cref="Question"/> body.</value>
        [JsonProperty("body")]
        public string Body
        {
            get { return body; }
            set { body = value; OnPropertyChanged("Body"); }
        }

        /// <summary>
        /// Gets or sets the answer count.
        /// </summary>
        /// <value>The answer count.</value>
        [JsonProperty("answer_count")]
        public int AnswerCount
        {
            get { return answerCount; }
            set { answerCount = value; OnPropertyChanged("AnswerCount"); }
        }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; OnPropertyChanged("CreationDate"); }
        }

        /// <summary>
        /// Gets or sets the last activity date.
        /// </summary>
        /// <value>The last activity date.</value>
        [JsonProperty("last_activity_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastActivityDate
        {
            get { return lastActivityDate; }
            set { lastActivityDate = value; OnPropertyChanged("LastActivityDate"); }
        }

        /// <summary>
        /// Gets or sets the last edit date.
        /// </summary>
        /// <value>The last edit date.</value>
        [JsonProperty("last_edit_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastEditDate
        {
            get { return lastEditDate; }
            set { lastEditDate = value; OnPropertyChanged("LastEditDate"); }
        }

        /// <summary>
        /// Gets or sets the locked date.
        /// </summary>
        /// <value>The locked date.</value>
        [JsonProperty("locked_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LockedDate
        {
            get { return lockedDate; }
            set { lockedDate = value; OnPropertyChanged("LockedDate"); }
        }

        /// <summary>
        /// Gets or sets the closed date.
        /// </summary>
        /// <value>The closed date.</value>
        [JsonProperty("closed_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ClosedDate
        {
            get { return closedDate; }
            set { closedDate = value; OnPropertyChanged("ClosedDate"); }
        }

        /// <summary>
        /// Gets or sets the closed reason.
        /// </summary>
        /// <value>The closed reason.</value>
        [JsonProperty("closed_reason")]
        public string ClosedReason
        {
            get { return closedReason; }
            set { closedReason = value; OnPropertyChanged("ClosedReason"); }
        }

        /// <summary>
        /// Gets or sets up vote count.
        /// </summary>
        /// <value>Up vote count.</value>
        [JsonProperty("up_vote_count")]
        public int UpVoteCount
        {
            get { return upVoteCount; }
            set { upVoteCount = value; OnPropertyChanged("UpVoteCount"); }
        }

        /// <summary>
        /// Gets or sets down vote count.
        /// </summary>
        /// <value>Down vote count.</value>
        [JsonProperty("down_vote_count")]
        public int DownVoteCount
        {
            get { return downVoteCount; }
            set { downVoteCount = value; OnPropertyChanged("DownVoteCount"); }
        }

        /// <summary>
        /// Gets or sets the favorite count.
        /// </summary>
        /// <value>The favorite count.</value>
        [JsonProperty("favorite_count")]
        public int FavoriteCount
        {
            get { return favoriteCount; }
            set { favoriteCount = value; OnPropertyChanged("FavoriteCount"); }
        }

        /// <summary>
        /// Gets or sets the view count.
        /// </summary>
        /// <value>The view count.</value>
        [JsonProperty("view_count")]
        public int ViewCount
        {
            get { return viewCount; }
            set { viewCount = value; OnPropertyChanged("ViewCount"); }
        }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>The score.</value>
        [JsonProperty("score")]
        public int Score
        {
            get { return score; }
            set { score = value; OnPropertyChanged("Score"); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="Question"/> is community owned.
        /// </summary>
        /// <value><c>true</c> if community owned; otherwise, <c>false</c>.</value>
        [JsonProperty("community_owned")]
        public bool CommunityOwned
        {
            get { return communityOwned; }
            set { communityOwned = value; OnPropertyChanged("CommunityOwned"); }
        }

        /// <summary>
        /// Gets or sets the accepted <see cref="Answer"/> id.
        /// </summary>
        /// <value>The accepted <see cref="Answer"/> id.</value>
        [JsonProperty("accepted_answer_id")]
        public int AcceptedAnswerId
        {
            get { return acceptedAnswerId; }
            set { acceptedAnswerId = value; OnPropertyChanged("AcceptedAnswerId"); }
        }

        /// <summary>
        /// Gets or sets the bounty amount.
        /// </summary>
        /// <value>The bounty amount.</value>
        [JsonProperty("bounty_amount")]
        public int BountyAmount
        {
            get { return bountyAmount; }
            set { bountyAmount = value; OnPropertyChanged("BountyAmount"); }
        }

        /// <summary>
        /// Gets or sets the timeline URL for this <see cref="Question"/>.
        /// </summary>
        /// <value>The timeline URL.</value>
        [JsonProperty("question_timeline_url")]
        public string TimelineUrl
        {
            get { return timelineUrl; }
            set { timelineUrl = value; OnPropertyChanged("TimelineUrl"); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Comment">Comments</see> URL for this <see cref="Question"/>.
        /// </summary>
        /// <value>The <see cref="Comment">Comments</see> URL for this <see cref="Question"/>.</value>
        [JsonProperty("question_comments_url")]
        public string CommentsUrl
        {
            get { return commentsUrl; }
            set { commentsUrl = value; OnPropertyChanged("CommentsUrl"); }
        }

        /// <summary>
        /// Gets or sets the <see cref="MigrationInfo"/> for this <see cref="Question"/>.
        /// </summary>
        [JsonProperty("migrated")]
        public MigrationInfo Migrated
        {
            get { return migrated; }
            set { migrated = value; OnPropertyChanged("Migrated"); }
        }

        /// <summary>
        /// Gets or sets the <see cref="UserInfo">owner</see>.
        /// </summary>
        /// <value>The <see cref="UserInfo">owner</see>.</value>
        public UserInfo Owner
        {
            get { return owner; }
            set { owner = value; OnPropertyChanged("Owner"); }
        }

        /// <summary>
        /// Gets or sets the list of <see cref="Tag">tags</see>.
        /// </summary>
        /// <value>The list of <see cref="Tag">tags</see>.</value>
        public List<string> Tags
        {
            get { return tags; }
            set { tags = value; OnPropertyChanged("Tags"); }
        }

        /// <summary>
        /// Gets or sets the list of <see cref="Answer">answers</see>.
        /// </summary>
        /// <value>The list of <see cref="Answer">answers</see>.</value>
        public List<Answer> Answers
        {
            get { return answers; }
            set { answers = value; OnPropertyChanged("Answers"); }
        }

        /// <summary>
        /// Gets or sets the list of <see cref="Comment">comments</see>.
        /// </summary>
        /// <value>The list of <see cref="Comment">comments</see>.</value>
        public List<Comment> Comments
        {
            get { return comments; }
            set { comments = value; OnPropertyChanged("Comments"); }
        }
    }
}