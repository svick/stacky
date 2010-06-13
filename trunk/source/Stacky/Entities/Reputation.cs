using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a <see cref="User">user's</see> reputation change.
    /// </summary>
    public class Reputation
    {
        /// <summary>
        /// Gets or sets the post id.
        /// </summary>
        /// <value>The post id.</value>
        [JsonProperty("post_id")]
        public long PostId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PostType">.
        /// </summary>
        /// <value>The type of the post.</value>
        [JsonProperty("post_type")]
        public PostType PostType { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the positive reputation.
        /// </summary>
        /// <value>The positive reputation.</value>
        [JsonProperty("positive_rep")]
        public int PositiveReputation { get; set; }

        /// <summary>
        /// Gets or sets the negative reputation.
        /// </summary>
        /// <value>The negative reputation.</value>
        [JsonProperty("negative_rep")]
        public int NegativeReputation { get; set; }

        /// <summary>
        /// Gets or sets the on date.
        /// </summary>
        /// <value>The on date.</value>
        [JsonProperty("on_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime OnDate { get; set; }
    }
}