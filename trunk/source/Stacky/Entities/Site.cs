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

        [JsonProperty("state"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public SiteState State { get; set; }

        [JsonProperty("aliases")]
        public string[] Aliases { get; set; }

        [JsonProperty("styling")]
        public SiteStyle Styling { get; set; }
    }

    public class SiteStyle
    {
        [JsonProperty("link_color")]
        public string LinkColor { get; set; }

        [JsonProperty("tag_foreground_color")]
        public string TagForegroundColor { get; set; }

        [JsonProperty("tag_background_color")]
        public string TagBackgroundColor { get; set; }
    }
}