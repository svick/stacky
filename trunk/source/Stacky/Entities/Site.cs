using Newtonsoft.Json;

namespace Stacky
{
    public class Site : Entity
    {
        private string name;
        private string logoUrl;
        private string apiEndpoint;
        private string siteUrl;
        private string description;
        private string iconUrl;
        private SiteState state;
        private string[] aliases;
        private SiteStyle styling;

        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        [JsonProperty("logo_url")]
        public string LogoUrl
        {
            get { return logoUrl; }
            set { logoUrl = value; OnPropertyChanged("LogoUrl"); }
        }

        [JsonProperty("api_endpoint")]
        public string ApiEndpoint
        {
            get { return apiEndpoint; }
            set { apiEndpoint = value; OnPropertyChanged("ApiEndpoint"); }
        }

        [JsonProperty("site_url")]
        public string SiteUrl
        {
            get { return siteUrl; }
            set { siteUrl = value; OnPropertyChanged("SiteUrl"); }
        }

        [JsonProperty("description")]
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        [JsonProperty("icon_url")]
        public string IconUrl
        {
            get { return iconUrl; }
            set { iconUrl = value; OnPropertyChanged("IconUrl"); }
        }

        [JsonProperty("state"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public SiteState State
        {
            get { return state; }
            set { state = value; OnPropertyChanged("State"); }
        }

        [JsonProperty("aliases")]
        public string[] Aliases
        {
            get { return aliases; }
            set { aliases = value; OnPropertyChanged("Aliases"); }
        }

        [JsonProperty("styling")]
        public SiteStyle Styling
        {
            get { return styling; }
            set { styling = value; OnPropertyChanged("Styling"); }
        }
    }
}