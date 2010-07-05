using System;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents information regarding a question which
    /// has been migrated from one site to another
    /// </summary>
    public class MigrationInfo : Entity
    {
        private int newQuestionId;
        private Site toSite;
        private DateTime onDate;

        /// <summary>
        /// Gets or sets the destination questionId
        /// </summary>
        [JsonProperty("new_question_id")]
        public int NewQuestionId
        {
            get { return newQuestionId; }
            set { newQuestionId = value; OnPropertyChanged("NewQuestionId"); }
        }

        /// <summary>
        /// Gets or sets the <see cref="Site"/> the <see cref="Question"/> has been migrated to
        /// </summary>
        [JsonProperty("to_site")]
        public Site ToSite
        {
            get { return toSite; }
            set { toSite = value; OnPropertyChanged("ToSite"); }
        }

        /// <summary>
        /// Gets or sets the date the <see cref="Question"/> was migrated
        /// </summary>
        [JsonProperty("on_date"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime OnDate
        {
            get { return onDate; }
            set { onDate = value; OnPropertyChanged("OnDate"); }
        }
    }
}