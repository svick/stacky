using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a <see cref="User">User's</see> badge count. 
    /// </summary>
    public class BadgeCounts : Entity
    {
        private int gold;
        private int silver;
        private int bronze;

        /// <summary>
        /// Gets or sets the gold badge count.
        /// </summary>
        /// <value>The gold badge count.</value>
        [JsonProperty("gold")]
        public int Gold
        {
            get { return gold; }
            set { gold = value; NotifyOfPropertyChange(() => Gold); }
        }

        /// <summary>
        /// Gets or sets the silver badge count.
        /// </summary>
        /// <value>The silver badge count.</value>
        [JsonProperty("silver")]
        public int Silver
        {
            get { return silver; }
            set { silver = value; NotifyOfPropertyChange(() => Silver); }
        }

        /// <summary>
        /// Gets or sets the bronze.
        /// </summary>
        /// <value>The bronze badge count.</value>
        [JsonProperty("bronze")]
        public int Bronze
        {
            get { return bronze; }
            set { bronze = value; NotifyOfPropertyChange(() => Bronze); }
        }
    }
}