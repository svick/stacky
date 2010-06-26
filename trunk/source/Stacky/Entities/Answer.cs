using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents an Answer.
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Answer"/> class.
        /// </summary>
        public Answer()
        {
            Comments = new List<Comment>();
        }

        /// <summary>
        /// Gets or sets the <see cref="Answer"/> id.
        /// </summary>
        /// <value>The <see cref="Answer"/> id.</value>
        [JsonProperty("answer_id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Answer"/> title.
        /// </summary>
        /// <value>The <see cref="Answer"/> title.</value>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Answer"/> body.
        /// </summary>
        /// <value>The <see cref="Answer"/> body.</value>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Answer"/> is accepted.
        /// </summary>
        /// <value><c>true</c> if accepted; otherwise, <c>false</c>.</value>
        [JsonProperty("accepted")]
        public bool Accepted { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Question"/> id.
        /// </summary>
        /// <value>The <see cref="Question"/> id.</value>
        [JsonProperty("question_id")]
        public int QuestionId { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the last activity date.
        /// </summary>
        /// <value>The last activity date.</value>
        [JsonProperty("last_activity_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastActivityDate { get; set; }

        /// <summary>
        /// Gets or sets the date this answer was locked.
        /// </summary>
        [JsonProperty("locked_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LockedDate { get; set; }

        /// <summary>
        /// Gets or sets the last edit date.
        /// </summary>
        /// <value>The last edit date.</value>
        [JsonProperty("last_edit_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastEditDate { get; set; }

        /// <summary>
        /// Gets or sets up vote count.
        /// </summary>
        /// <value>Up vote count.</value>
        [JsonProperty("up_vote_count")]
        public int UpVoteCount { get; set; }

        /// <summary>
        /// Gets or sets down vote count.
        /// </summary>
        /// <value>Down vote count.</value>
        [JsonProperty("down_vote_count")]
        public int DownVoteCount { get; set; }

        /// <summary>
        /// Gets or sets the favorite count.
        /// </summary>
        /// <value>The favorite count.</value>
        [JsonProperty("favorite_count")]
        public int FavoriteCount { get; set; }

        /// <summary>
        /// Gets or sets the view count.
        /// </summary>
        /// <value>The view count.</value>
        [JsonProperty("view_count")]
        public int ViewCount { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>The score.</value>
        [JsonProperty("score")]
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="Answer"/> is community owned.
        /// </summary>
        /// <value><c>true</c> if community owned; otherwise, <c>false</c>.</value>
        [JsonProperty("community_owned")]
        public bool CommunityOwned { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Comment">Comments</see>.
        /// </summary>
        /// <value>The <see cref="Comment">Comments</see>.</value>
        public List<Comment> Comments { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Comment">Comments</see> URL for this <see cref="Answer"/>.
        /// </summary>
        /// <value>The <see cref="Comment">Comments</see> URL for this <see cref="Answer"/>.</value>
        [JsonProperty("answer_comments_url")]
        public string CommentsUrl { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="User"/> associated with this <see cref="Answer"/>.
        /// </summary>
        [JsonProperty("owner")]
        public User Owner { get; set; }
    }
}