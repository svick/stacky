using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a badge.
    /// </summary>
    public class Badge
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [JsonProperty("badge_id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="BadgeClass"/>.
        /// </summary>
        /// <value>The BadgeClass.</value>
        [JsonProperty("rank"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public BadgeClass Rank { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Badge"/> name.
        /// </summary>
        /// <value>The <see cref="Badge"/> name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Badge"/> description.
        /// </summary>
        /// <value>The <see cref="Badge"/> description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the award count of this <see cref="Badge"/>.
        /// </summary>
        /// <value>The award count of this <see cref="Badge"/>.</value>
        [JsonProperty("award_count")]
        public int AwardCount { get; set; }

        /// <summary>
        /// Gets or sets whether or not this <see cref="Badge"/> is tag based or not.
        /// </summary>
        [JsonProperty("tag_based")]
        public bool IsTagBased { get; set; }

        /// <summary>
        /// Gets or sets the url link to the badge recipients.
        /// </summary>
        [JsonProperty("badges_recipients_url")]
        public string BadgeRecipientsUrl { get; set; }

    }
}