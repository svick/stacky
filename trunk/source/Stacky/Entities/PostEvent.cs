using System;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a post event.
    /// </summary>
    public class PostEvent : Entity
    {
        private PostEventType type;
        private int postId;
        private int userId;
        private int ownerUserId;
        private string action;
        private DateTime creationDate;
        private Guid revisionGuid;

        /// <summary>
        /// Gets or sets the <see cref="PostEventType">post type</see>.
        /// </summary>
        /// <value>The <see cref="PostEventType">type</see>.</value>
        [JsonProperty("timeline_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PostEventType Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged("Type"); }
        }

        /// <summary>
        /// Gets or sets the post id.
        /// </summary>
        /// <value>The post id.</value>
        [JsonProperty("post_id")]
        public int PostId
        {
            get { return postId; }
            set { postId = value; OnPropertyChanged("PostId"); }
        }

        /// <summary>
        /// Gets or sets the <see cref="User"/> id.
        /// </summary>
        /// <value>The <see cref="User"/> id.</value>
        [JsonProperty("user_id")]
        public int UserId
        {
            get { return userId; }
            set { userId = value; OnPropertyChanged("UserId"); }
        }

        /// <summary>
        /// Gets or sets the owner <see cref="User"/> id.
        /// </summary>
        /// <value>The owner <see cref="User"/> id.</value>
        [JsonProperty("owner_user_id")]
        public int OwnerUserId
        {
            get { return ownerUserId; }
            set { ownerUserId = value; OnPropertyChanged("OwnerUserId"); }
        }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        [JsonProperty("action")]
        public string Action
        {
            get { return action; }
            set { action = value; OnPropertyChanged("Action"); }
        }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; OnPropertyChanged("CreationDate"); }
        }

        /// <summary>
        /// Gets or sets the revision GUID.
        /// </summary>
        /// <value>The revision GUID.</value>
        [JsonProperty("revision_guid")]
        public Guid RevisionGuid
        {
            get { return revisionGuid; }
            set { revisionGuid = value; OnPropertyChanged("RevisionGuid"); }
        }
    }
}