using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a question.
    /// </summary>
    [JsonObject]
    public class Question
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Question"/> class.
        /// </summary>
        public Question()
        {
            Tags = new List<string>();
            Answers = new List<Answer>();
            Comments = new List<Comment>();
        }

        /// <summary>
        /// Gets or sets the <see cref="Question"/> id.
        /// </summary>
        /// <value>The <see cref="Question"/> id.</value>
        [JsonProperty("question_id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Question"/> title.
        /// </summary>
        /// <value>The <see cref="Question"/> title.</value>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Question"/> body.
        /// </summary>
        /// <value>The <see cref="Question"/> body.</value>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the answer count.
        /// </summary>
        /// <value>The answer count.</value>
        [JsonProperty("answer_count")]
        public int AnswerCount { get; set; }

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
        /// Gets or sets the last edit date.
        /// </summary>
        /// <value>The last edit date.</value>
        [JsonProperty("last_edit_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastEditDate { get; set; }

        /// <summary>
        /// Gets or sets the locked date.
        /// </summary>
        /// <value>The locked date.</value>
        [JsonProperty("locked_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LockedDate { get; set; }

        /// <summary>
        /// Gets or sets the closed date.
        /// </summary>
        /// <value>The closed date.</value>
        [JsonProperty("closed_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ClosedDate { get; set; }

        /// <summary>
        /// Gets or sets the closed reason.
        /// </summary>
        /// <value>The closed reason.</value>
        [JsonProperty("closed_reason")]
        public string ClosedReason { get; set; }

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
        /// Gets or sets a value indicating whether the <see cref="Question"/> is community owned.
        /// </summary>
        /// <value><c>true</c> if community owned; otherwise, <c>false</c>.</value>
        [JsonProperty("community_owned")]
        public bool CommunityOwned { get; set; }

        /// <summary>
        /// Gets or sets the accepted <see cref="Answer"/> id.
        /// </summary>
        /// <value>The accepted <see cref="Answer"/> id.</value>
        [JsonProperty("accepted_answer_id")]
        public int AcceptedAnswerId { get; set; }

        /// <summary>
        /// Gets or sets the bounty amount.
        /// </summary>
        /// <value>The bounty amount.</value>
        [JsonProperty("bounty_amount")]
        public int BountyAmount { get; set; }

        /// <summary>
        /// Gets or sets the timeline URL for this <see cref="Question"/>.
        /// </summary>
        /// <value>The timeline URL.</value>
        [JsonProperty("question_timeline_url")]
        public string TimelineUrl { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Comment">Comments</see> URL for this <see cref="Question"/>.
        /// </summary>
        /// <value>The <see cref="Comment">Comments</see> URL for this <see cref="Question"/>.</value>
        [JsonProperty("question_comments_url")]
        public string CommentsUrl { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="MigrationInfo"/> for this <see cref="Question"/>.
        /// </summary>
        [JsonProperty("migrated")]
        public MigrationInfo Migrated { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="UserInfo">owner</see>.
        /// </summary>
        /// <value>The <see cref="UserInfo">owner</see>.</value>
        public UserInfo Owner { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="Tag">tags</see>.
        /// </summary>
        /// <value>The list of <see cref="Tag">tags</see>.</value>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="Answer">answers</see>.
        /// </summary>
        /// <value>The list of <see cref="Answer">answers</see>.</value>
        public List<Answer> Answers { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="Comment">comments</see>.
        /// </summary>
        /// <value>The list of <see cref="Comment">comments</see>.</value>
        public List<Comment> Comments { get; set; }
    }
}