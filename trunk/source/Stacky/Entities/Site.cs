using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    public class Site
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("api_endpoint")]
        public string ApiEndpoint { get; set; }

        [JsonProperty("site_url")]
        public string SiteUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }
    }
}