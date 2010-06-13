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
        public long Id { get; set; }

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
        /// Gets or sets the owner <see cref="User"/> id.
        /// </summary>
        /// <value>The owner user id.</value>
        [JsonProperty("owner_user_id")]
        public int OwnerUserId { get; set; }

        /// <summary>
        /// Gets or sets the display name of the owner.
        /// </summary>
        /// <value>The display name of the owner.</value>
        [JsonProperty("owner_display_name")]
        public string OwnerDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PostType">post type</see>.
        /// </summary>
        /// <value>The type of the post.</value>
        [JsonProperty("post_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PostType PostType { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>The score.</value>
        [JsonProperty("score")]
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the reply to <see cref="User"/> id.
        /// </summary>
        /// <value>The reply to <see cref="User"/> id.</value>
        [JsonProperty("reply_to_user_id")]
        public int ReplyToUserId { get; set; }

        /// <summary>
        /// Gets or sets the edit count.
        /// </summary>
        /// <value>The edit count.</value>
        [JsonProperty("edit_count")]
        public int EditCount { get; set; }
    }
}