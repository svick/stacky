using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a post event.
    /// </summary>
    public class PostEvent
    {
        /// <summary>
        /// Gets or sets the <see cref="PostEventType">post type</see>.
        /// </summary>
        /// <value>The <see cref="PostEventType">type</see>.</value>
        [JsonProperty("timeline_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PostEventType Type { get; set; }

        /// <summary>
        /// Gets or sets the post id.
        /// </summary>
        /// <value>The post id.</value>
        [JsonProperty("post_id")]
        public int PostId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="User"/> id.
        /// </summary>
        /// <value>The <see cref="User"/> id.</value>
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the owner <see cref="User"/> id.
        /// </summary>
        /// <value>The owner <see cref="User"/> id.</value>
        [JsonProperty("owner_user_id")]
        public int OwnerUserId { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        [JsonProperty("action")]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the revision GUID.
        /// </summary>
        /// <value>The revision GUID.</value>
        [JsonProperty("revision_guid")]
        public Guid RevisionGuid { get; set; }
    }
}