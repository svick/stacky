using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a tag.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the restricted to.
        /// </summary>
        /// <value>The restricted to.</value>
        [JsonProperty("restricted_to")]
        public string RestrictedTo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the tag fulfills the post requirement.
        /// </summary>
        /// <value><c>true</c> if the tag fulfills the post requirement; otherwise, <c>false</c>.</value>
        [JsonProperty("fulfills_required")]
        public bool FulfillsRequired { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        [JsonProperty("user_id")]
        public int? UserId { get; set; }
    }
}