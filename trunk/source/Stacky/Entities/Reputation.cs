using System;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a <see cref="User">user's</see> reputation change.
    /// </summary>
    public class Reputation : Entity
    {
        private int postId;
        private PostType postType;
        private string title;
        private int positiveReputation;
        private int negativeReputation;
        private DateTime onDate;

        /// <summary>
        /// Gets or sets the post id.
        /// </summary>
        /// <value>The post id.</value>
        [JsonProperty("post_id")]
        public int PostId
        {
            get { return postId; }
            set { postId = value; NotifyOfPropertyChange(() => PostId); }
        }

        /// <summary>
        /// Gets or sets the <see cref="PostType">.
        /// </summary>
        /// <value>The type of the post.</value>
        [JsonProperty("post_type")]
        public PostType PostType
        {
            get { return postType; }
            set { postType = value; NotifyOfPropertyChange(() => PostType); }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set { title = value; NotifyOfPropertyChange(() => Title); }
        }

        /// <summary>
        /// Gets or sets the positive reputation.
        /// </summary>
        /// <value>The positive reputation.</value>
        [JsonProperty("positive_rep")]
        public int PositiveReputation
        {
            get { return positiveReputation; }
            set { positiveReputation = value; NotifyOfPropertyChange(() => PositiveReputation); }
        }

        /// <summary>
        /// Gets or sets the negative reputation.
        /// </summary>
        /// <value>The negative reputation.</value>
        [JsonProperty("negative_rep")]
        public int NegativeReputation
        {
            get { return negativeReputation; }
            set { negativeReputation = value; NotifyOfPropertyChange(() => NegativeReputation); }
        }

        /// <summary>
        /// Gets or sets the on date.
        /// </summary>
        /// <value>The on date.</value>
        [JsonProperty("on_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime OnDate
        {
            get { return onDate; }
            set { onDate = value; NotifyOfPropertyChange(() => OnDate); }
        }
    }
}