using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Stacky
{
    public class UserInfo
    {
        [JsonProperty("user_id")]
        public int? UserId { get; set; }

        [JsonProperty("user_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public UserType Type { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("reputation")]
        public int? Reputation { get; set; }

        [JsonProperty("email_hash")]
        public string EmailHash { get; set; }

        public string GravatarUrl { get { return String.Format("http://www.gravatar.com/avatar/{0}?d=identicon&r=PG", EmailHash); } }
    }
}