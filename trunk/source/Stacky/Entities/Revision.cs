using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a <see cref="Question"/> or <see cref="Answer"/> revision.
    /// </summary>
    public class Revision : Entity
    {
        private List<string> lastTags = new List<string>();
        private List<string> tags = new List<string>();
        private string title;
        private string lastTitle;
        private string comment;
        private string body;
        private string lastBody;
        private DateTime creationDate;
        private bool isQuestion;
        private bool isRollback;
        private Guid revisionGuid;
        private int revisionNumber;
        private string revisionType;
        private bool setCommunityWiki;
        private int userId;


        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set { title = value; NotifyOfPropertyChange(() => Title); }
        }

        /// <summary>
        /// Gets or sets the last title.
        /// </summary>
        /// <value>The last title.</value>
        [JsonProperty("last_title")]
        public string LastTitle
        {
            get { return lastTitle; }
            set { lastTitle = value; NotifyOfPropertyChange(() => LastTitle); }
        }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>The comment.</value>
        [JsonProperty("comment")]
        public string Comment
        {
            get { return comment; }
            set { comment = value; NotifyOfPropertyChange(() => Comment); }
        }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        [JsonProperty("body")]
        public string Body
        {
            get { return body; }
            set { body = value; NotifyOfPropertyChange(() => Body); }
        }

        /// <summary>
        /// Gets or sets the last body.
        /// </summary>
        /// <value>The last body.</value>
        [JsonProperty("last_body")]
        public string LastBody
        {
            get { return lastBody; }
            set { lastBody = value; NotifyOfPropertyChange(() => LastBody); }
        }

        /// <summary>
        /// Gets or sets the list of <see cref="Tag">tags</see>.
        /// </summary>
        /// <value>The list of <see cref="Tag">tags</see>.</value>
        [JsonProperty("tags")]
        public List<string> Tags
        {
            get { return tags; }
            set { tags = value; NotifyOfPropertyChange(() => Tags); }
        }

        /// <summary>
        /// Gets or sets the last list of <see cref="Tag">tags</see>.
        /// </summary>
        /// <value>The last list of <see cref="Tag">tags</see>.</value>
        [JsonProperty("last_tags")]
        public List<string> LastTags
        {
            get { return lastTags; }
            set { lastTags = value; NotifyOfPropertyChange(() => LastTags); }
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
        /// Gets or sets a value indicating whether this instance is question.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is question; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("is_question")]
        public bool IsQuestion
        {
            get { return isQuestion; }
            set { isQuestion = value; NotifyOfPropertyChange(() => IsQuestion); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is rollback.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is rollback; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("is_rollback")]
        public bool IsRollback
        {
            get { return isRollback; }
            set { isRollback = value; NotifyOfPropertyChange(() => IsRollback); }
        }

        /// <summary>
        /// Gets or sets the revision GUID.
        /// </summary>
        /// <value>The revision GUID.</value>
        [JsonProperty("revision_guid")]
        public Guid RevisionGuid
        {
            get { return revisionGuid; }
            set { revisionGuid = value; NotifyOfPropertyChange(() => RevisionGuid); }
        }

        /// <summary>
        /// Gets or sets the revision number.
        /// </summary>
        /// <value>The revision number.</value>
        [JsonProperty("revision_number")]
        public int RevisionNumber
        {
            get { return revisionNumber; }
            set { revisionNumber = value; NotifyOfPropertyChange(() => RevisionNumber); }
        }

        /// <summary>
        /// Gets or sets the type of the revision.
        /// </summary>
        /// <value>The type of the revision.</value>
        [JsonProperty("revision_type")]
        public string RevisionType
        {
            get { return revisionType; }
            set { revisionType = value; NotifyOfPropertyChange(() => RevisionType); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [set community wiki].
        /// </summary>
        /// <value><c>true</c> if [set community wiki]; otherwise, <c>false</c>.</value>
        [JsonProperty("set_community_wiki")]
        public bool SetCommunityWiki
        {
            get { return setCommunityWiki; }
            set { setCommunityWiki = value; NotifyOfPropertyChange(() => SetCommunityWiki); }
        }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        [JsonProperty("user_id")]
        public int UserId
        {
            get { return userId; }
            set { userId = value; NotifyOfPropertyChange(() => UserId); }
        }
    }
}