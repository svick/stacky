using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a <see cref="Question"/> or <see cref="Answer"/> revision.
    /// </summary>
    public class Revision
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Revision"/> class.
        /// </summary>
        public Revision()
        {
            LastTags = new List<string>();
            Tags = new List<string>();
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the last title.
        /// </summary>
        /// <value>The last title.</value>
        [JsonProperty("last_title")]
        public string LastTitle { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>The comment.</value>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the last body.
        /// </summary>
        /// <value>The last body.</value>
        [JsonProperty("last_body")]
        public string LastBody { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="Tag">tags</see>.
        /// </summary>
        /// <value>The list of <see cref="Tag">tags</see>.</value>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the last list of <see cref="Tag">tags</see>.
        /// </summary>
        /// <value>The last list of <see cref="Tag">tags</see>.</value>
        [JsonProperty("last_tags")]
        public List<string> LastTags { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is question.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is question; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("is_question")]
        public bool IsQuestion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is rollback.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is rollback; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("is_rollback")]
        public bool IsRollback { get; set; }

        /// <summary>
        /// Gets or sets the revision GUID.
        /// </summary>
        /// <value>The revision GUID.</value>
        [JsonProperty("revision_guid")]
        public Guid RevisionGuid { get; set; }

        /// <summary>
        /// Gets or sets the revision number.
        /// </summary>
        /// <value>The revision number.</value>
        [JsonProperty("revision_number")]
        public int RevisionNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of the revision.
        /// </summary>
        /// <value>The type of the revision.</value>
        [JsonProperty("revision_type")]
        public string RevisionType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [set community wiki].
        /// </summary>
        /// <value><c>true</c> if [set community wiki]; otherwise, <c>false</c>.</value>
        [JsonProperty("set_community_wiki")]
        public bool SetCommunityWiki { get; set;}

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        [JsonProperty("user_id")]
        public int UserId { get; set; }
    }
}