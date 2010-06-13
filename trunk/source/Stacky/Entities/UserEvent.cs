using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a user event.
    /// </summary>
    public class UserEvent
    {
        /// <summary>
        /// Gets or sets the <see cref="UserEventType"/>.
        /// </summary>
        /// <value>The <see cref="UserEventType"/>.</value>
        [JsonProperty("timeline_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public UserEventType Type { get; set; }

        /// <summary>
        /// Gets or sets the post id.
        /// </summary>
        /// <value>The post id.</value>
        [JsonProperty("post_id")]
        public int PostId { get; set; }

        /// <summary>
        /// Gets or sets the comment id.
        /// </summary>
        /// <value>The comment id.</value>
        [JsonProperty("comment_id")]
        public int CommentId { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        [JsonProperty("action")]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the detail.
        /// </summary>
        /// <value>The detail.</value>
        [JsonProperty("detail")]
        public string Detail { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }
    }
}