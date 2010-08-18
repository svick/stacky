using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents an Answer.
    /// </summary>
    public class Answer : Entity
    {
        #region private members

        private int id;
        private string title;
        private string body;
        private bool accepted;
        private int questionId;
        private DateTime creationDate;
        private DateTime lastActivityDate;
        private DateTime lockedDate;
        private DateTime lastEditDate;
        private int upVoteCount;
        private int downVoteCount;
        private int favoriteCount;
        private int viewCount;
        private int score;
        private bool communityOwned;
        private string commentsUrl;
        private User owner;
        private List<Comment> comments = new List<Comment>();

        #endregion

        /// <summary>
        /// Gets or sets the <see cref="Answer"/> id.
        /// </summary>
        /// <value>The <see cref="Answer"/> id.</value>
        [JsonProperty("answer_id")]
        public int Id
        {
            get { return id; }
            set { id = value; NotifyOfPropertyChange(() => Id); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Answer"/> title.
        /// </summary>
        /// <value>The <see cref="Answer"/> title.</value>
        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set { title = value; NotifyOfPropertyChange(() => Title); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Answer"/> body.
        /// </summary>
        /// <value>The <see cref="Answer"/> body.</value>
        [JsonProperty("body")]
        public string Body
        {
            get { return body; }
            set { body = value; NotifyOfPropertyChange(() => Body); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Answer"/> is accepted.
        /// </summary>
        /// <value><c>true</c> if accepted; otherwise, <c>false</c>.</value>
        [JsonProperty("accepted")]
        public bool Accepted
        {
            get { return accepted; }
            set { accepted = value; NotifyOfPropertyChange(() => Accepted); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Question"/> id.
        /// </summary>
        /// <value>The <see cref="Question"/> id.</value>
        [JsonProperty("question_id")]
        public int QuestionId
        {
            get { return questionId; }
            set { questionId = value; NotifyOfPropertyChange(() => QuestionId); }
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
        /// Gets or sets the last activity date.
        /// </summary>
        /// <value>The last activity date.</value>
        [JsonProperty("last_activity_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastActivityDate
        {
            get { return lastActivityDate; }
            set { lastActivityDate = value; NotifyOfPropertyChange(() => LastActivityDate); }
        }

        /// <summary>
        /// Gets or sets the date this answer was locked.
        /// </summary>
        [JsonProperty("locked_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LockedDate
        {
            get { return lockedDate; }
            set { lockedDate = value; NotifyOfPropertyChange(() => LockedDate); }
        }

        /// <summary>
        /// Gets or sets the last edit date.
        /// </summary>
        /// <value>The last edit date.</value>
        [JsonProperty("last_edit_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastEditDate
        {
            get { return lastEditDate; }
            set { lastEditDate = value; NotifyOfPropertyChange(() => LastEditDate); }
        }

        /// <summary>
        /// Gets or sets up vote count.
        /// </summary>
        /// <value>Up vote count.</value>
        [JsonProperty("up_vote_count")]
        public int UpVoteCount
        {
            get { return upVoteCount; }
            set { upVoteCount = value; NotifyOfPropertyChange(() => UpVoteCount); }
        }

        /// <summary>
        /// Gets or sets down vote count.
        /// </summary>
        /// <value>Down vote count.</value>
        [JsonProperty("down_vote_count")]
        public int DownVoteCount
        {
            get { return downVoteCount; }
            set { downVoteCount = value; NotifyOfPropertyChange(() => DownVoteCount); }
        }

        /// <summary>
        /// Gets or sets the favorite count.
        /// </summary>
        /// <value>The favorite count.</value>
        [JsonProperty("favorite_count")]
        public int FavoriteCount
        {
            get { return favoriteCount; }
            set { favoriteCount = value; NotifyOfPropertyChange(() => FavoriteCount); }
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
        /// Gets or sets the score.
        /// </summary>
        /// <value>The score.</value>
        [JsonProperty("score")]
        public int Score
        {
            get { return score; }
            set { score = value; NotifyOfPropertyChange(() => Score); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="Answer"/> is community owned.
        /// </summary>
        /// <value><c>true</c> if community owned; otherwise, <c>false</c>.</value>
        [JsonProperty("community_owned")]
        public bool CommunityOwned
        {
            get { return communityOwned; }
            set { communityOwned = value; NotifyOfPropertyChange(() => CommunityOwned); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Comment">Comments</see> URL for this <see cref="Answer"/>.
        /// </summary>
        /// <value>The <see cref="Comment">Comments</see> URL for this <see cref="Answer"/>.</value>
        [JsonProperty("answer_comments_url")]
        public string CommentsUrl
        {
            get { return commentsUrl; }
            set { commentsUrl = value; NotifyOfPropertyChange(() => CommentsUrl); }
        }

        /// <summary>
        /// Gets or sets the <see cref="User"/> associated with this <see cref="Answer"/>.
        /// </summary>
        [JsonProperty("owner")]
        public User Owner
        {
            get { return owner; }
            set { owner = value; NotifyOfPropertyChange(() => Owner); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Comment">Comments</see>.
        /// </summary>
        /// <value>The <see cref="Comment">Comments</see>.</value>
        public List<Comment> Comments
        {
            get { return comments; }
            set { comments = value; NotifyOfPropertyChange(() => Comments); }
        }
    }
}