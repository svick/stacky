using Newtonsoft.Json;

namespace Stacky
{
    public class SiteStyle : Entity
    {
        private string linkColor;
        private string tagForegroundColor;
        private string tagBackgroundColor;

        [JsonProperty("link_color")]
        public string LinkColor
        {
            get { return linkColor; }
            set { linkColor = value; NotifyOfPropertyChange(() => LinkColor); }
        }

        [JsonProperty("tag_foreground_color")]
        public string TagForegroundColor
        {
            get { return tagForegroundColor; }
            set { tagForegroundColor = value; NotifyOfPropertyChange(() => TagForegroundColor); }
        }

        [JsonProperty("tag_background_color")]
        public string TagBackgroundColor
        {
            get { return tagBackgroundColor; }
            set { tagBackgroundColor = value; NotifyOfPropertyChange(() => TagBackgroundColor); }
        }
    }
}