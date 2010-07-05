using System;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a user event.
    /// </summary>
    public class UserEvent : Entity
    {
        private UserEventType type;
        private int postId;
        private int commentId;
        private string action;
        private string description;
        private string detail;
        private DateTime creationDate;

        /// <summary>
        /// Gets or sets the <see cref="UserEventType"/>.
        /// </summary>
        /// <value>The <see cref="UserEventType"/>.</value>
        [JsonProperty("timeline_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public UserEventType Type
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
        /// Gets or sets the comment id.
        /// </summary>
        /// <value>The comment id.</value>
        [JsonProperty("comment_id")]
        public int CommentId
        {
            get { return commentId; }
            set { commentId = value; OnPropertyChanged("CommentId"); }
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
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        /// <summary>
        /// Gets or sets the detail.
        /// </summary>
        /// <value>The detail.</value>
        [JsonProperty("detail")]
        public string Detail
        {
            get { return detail; }
            set { detail = value; OnPropertyChanged("Detail"); }
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
    }
}