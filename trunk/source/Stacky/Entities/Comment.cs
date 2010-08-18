using System;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a comment.
    /// </summary>
    public class Comment : Entity
    {
        private int id;
        private string body;
        private DateTime creationDate;
        private PostType postType;
        private int postId;
        private int score;
        private int editCount;
        private User owner;
        private User replyTo;

        /// <summary>
        /// Gets or sets the <see cref="Comment"/> id.
        /// </summary>
        /// <value>The <see cref="Comment"/> id.</value>
        [JsonProperty("comment_id")]
        public int Id
        {
            get { return id; }
            set { id = value; NotifyOfPropertyChange(() => Id); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Comment"/> body.
        /// </summary>
        /// <value>The <see cref="Comment"/> body.</value>
        [JsonProperty("body")]
        public string Body
        {
            get { return body; }
            set { body = value; NotifyOfPropertyChange(() => Body); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Comment"/> creation date.
        /// </summary>
        /// <value>The <see cref="Comment"/> creation date.</value>
        [JsonProperty("creation_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; NotifyOfPropertyChange(() => CreationDate); }
        }

        /// <summary>
        /// Gets or sets the <see cref="PostType">post type</see>.
        /// </summary>
        /// <value>The type of the post.</value>
        [JsonProperty("post_type"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PostType PostType
        {
            get { return postType; }
            set { postType = value; NotifyOfPropertyChange(() => PostType); }
        }

        /// <summary>
        /// Gets or sets the Id of the post this comment is on
        /// </summary>
        [JsonProperty("post_id")]
        public int PostId
        {
            get { return postId; }
            set { postId = value; NotifyOfPropertyChange(() => PostId); }
        }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>The score.</value>
        [JsonProperty("score")]
        public int Score
        {
            get { return score; }
            set { score = value; NotifyOfPropertyChange(() => Score); }
        }

        /// <summary>
        /// Gets or sets the edit count.
        /// </summary>
        /// <value>The edit count.</value>
        [JsonProperty("edit_count")]
        public int EditCount
        {
            get { return editCount; }
            set { editCount = value; NotifyOfPropertyChange(() => EditCount); }
        }

        /// <summary>
        /// Gets or sets the <see cref="User"/> associated with this <see cref="Comment"/>.
        /// </summary>
        [JsonProperty("owner")]
        public User Owner
        {
            get { return owner; }
            set { owner = value; NotifyOfPropertyChange(() => Owner); }
        }

        /// <summary>
        /// Gets or sets the <see cref="User"/> which this <see cref="Comment"/> was in reply to.
        /// </summary>
        [JsonProperty("reply_to_user")]
        public User ReplyTo
        {
            get { return replyTo; }
            set { replyTo = value; NotifyOfPropertyChange(() => ReplyTo); }
        }
    }
}