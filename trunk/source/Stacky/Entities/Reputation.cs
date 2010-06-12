using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    public class Reputation
    {
        [JsonProperty("post_id")]
        public long PostId { get; set; }

        [JsonProperty("post_type")]
        public PostType PostType { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("positive_rep")]
        public int PositiveReputation { get; set; }

        [JsonProperty("negative_rep")]
        public int NegativeReputation { get; set; }

        [JsonProperty("on_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime OnDate { get; set; }
    }
}