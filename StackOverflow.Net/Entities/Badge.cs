using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace StackOverflow
{
    public class Badge
    {
        [JsonProperty("badge_id")]
        public int Id { get; set; }
        [JsonProperty("class"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public BadgeClass Class { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("award_count")]
        public int AwardCount { get; set; }
    }

    public enum BadgeClass
    {
        Gold,
        Silver,
        Bronze
    }
}