using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace StackOverflow
{
    public class Tag
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}