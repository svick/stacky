using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents the API version.
    /// </summary>
    public class ApiVersion : Entity
    {
        private string version;
        private string revision;

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        [JsonProperty("version")]
        public string Version
        {
            get { return version; }
            set { version = value; NotifyOfPropertyChange(() => Version); }
        }

        /// <summary>
        /// Gets or sets the revision.
        /// </summary>
        /// <value>The revision.</value>
        [JsonProperty("revision")]
        public string Revision
        {
            get { return revision; }
            set { revision = value; NotifyOfPropertyChange(() => Revision); }
        }
    }
}
