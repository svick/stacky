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
            set { linkColor = value; OnPropertyChanged("LinkColor"); }
        }

        [JsonProperty("tag_foreground_color")]
        public string TagForegroundColor
        {
            get { return tagForegroundColor; }
            set { tagForegroundColor = value; OnPropertyChanged("TagForegroundColor"); }
        }

        [JsonProperty("tag_background_color")]
        public string TagBackgroundColor
        {
            get { return tagBackgroundColor; }
            set { tagBackgroundColor = value; OnPropertyChanged("TagBackgroundColor"); }
        }
    }
}