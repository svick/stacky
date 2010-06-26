using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a comment.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Gets or sets the <see cref="Comment"/> id.
        /// </summary>
        /// <value>The <see cref="Comment"/> id.</value>
        [JsonProperty("comment_id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Comment"/> body.
        /// </summary>
        /// <value>The <see cref="Comment"/> body.</value>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Comment"/> creation date.
        /// </summary>
        /// <value>The <see cref="Comment"/> creation date.</value>
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PostType">post type</see>.
        /// </summary>
        /// <value>The type of the post.</value>
        [JsonProperty("post_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PostType PostType { get; set; }

        /// <summary>
        /// Gets or sets the Id of the post this comment is on
        /// </summary>
        [JsonProperty("post_id")]
        public int PostId { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>The score.</value>
        [JsonProperty("score")]
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the edit count.
        /// </summary>
        /// <value>The edit count.</value>
        [JsonProperty("edit_count")]
        public int EditCount { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="User"/> associated with this <see cref="Comment"/>.
        /// </summary>
        [JsonProperty("owner")]
        public User Owner { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="User"/> which this <see cref="Comment"/> was in reply to.
        /// </summary>
        [JsonProperty("reply_to_user")]
        public User ReplyTo { get; set; }
    }
}