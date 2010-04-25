using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace StackOverflow
{
    public class BadgeCounts
    {
        [JsonProperty("gold")]
        public int Gold { get; set; }

        [JsonProperty("silver")]
        public int Silver { get; set; }

        [JsonProperty("bronze")]
        public int Bronze { get; set; }
    }
}