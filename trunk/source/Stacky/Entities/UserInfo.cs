using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents user information.
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        [JsonProperty("user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="UserType"/>.
        /// </summary>
        /// <value>The <see cref="UserType"/>.</value>
        [JsonProperty("user_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public UserType Type { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the reputation.
        /// </summary>
        /// <value>The reputation.</value>
        [JsonProperty("reputation")]
        public int? Reputation { get; set; }

        /// <summary>
        /// Gets or sets the email hash.
        /// </summary>
        /// <value>The email hash.</value>
        [JsonProperty("email_hash")]
        public string EmailHash { get; set; }

        /// <summary>
        /// Gets the gravatar URL.
        /// </summary>
        /// <value>The gravatar URL.</value>
        public string GravatarUrl { get { return String.Format("http://www.gravatar.com/avatar/{0}?d=identicon&r=PG", EmailHash); } }
    }
}