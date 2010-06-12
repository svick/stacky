using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    public class Revision
    {
        public Revision()
        {
            LastTags = new List<string>();
            Tags = new List<string>();
        }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("last_title")]
        public string LastTitle { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("last_body")]
        public string LastBody { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("last_tags")]
        public List<string> LastTags { get; set; }

        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }

        [JsonProperty("is_question")]
        public bool IsQuestion { get; set; }

        [JsonProperty("is_rollback")]
        public bool IsRollback { get; set; }

        [JsonProperty("revision_guid")]
        public Guid RevisionGuid { get; set; }

        [JsonProperty("revision_number")]
        public int RevisionNumber { get; set; }

        [JsonProperty("revision_type")]
        public string RevisionType { get; set; }

        [JsonProperty("set_community_wiki")]
        public bool SetCommunityWiki { get; set;}

        [JsonProperty("user_id")]
        public int UserId { get; set; }
    }
}