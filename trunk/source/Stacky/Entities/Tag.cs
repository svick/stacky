using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a tag.
    /// </summary>
    public class Tag : Entity
    {
        private string name;
        private int count;
        private string restrictedTo;
        private bool fulfillsRequired;
        private int? userId;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set { name = value; NotifyOfPropertyChange(() => Name); }
        }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        [JsonProperty("count")]
        public int Count
        {
            get { return count; }
            set { count = value; NotifyOfPropertyChange(() => Count); }
        }

        /// <summary>
        /// Gets or sets the restricted to.
        /// </summary>
        /// <value>The restricted to.</value>
        [JsonProperty("restricted_to")]
        public string RestrictedTo
        {
            get { return restrictedTo; }
            set { restrictedTo = value; NotifyOfPropertyChange(() => RestrictedTo); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the tag fulfills the post requirement.
        /// </summary>
        /// <value><c>true</c> if the tag fulfills the post requirement; otherwise, <c>false</c>.</value>
        [JsonProperty("fulfills_required")]
        public bool FulfillsRequired
        {
            get { return fulfillsRequired; }
            set { fulfillsRequired = value; NotifyOfPropertyChange(() => FulfillsRequired); }
        }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        [JsonProperty("user_id")]
        public int? UserId
        {
            get { return userId; }
            set { userId = value; NotifyOfPropertyChange(() => UserId); }
        }
    }
}