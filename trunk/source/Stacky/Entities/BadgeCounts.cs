using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// Represents a <see cref="User">User's</see> badge count. 
    /// </summary>
    public class BadgeCounts
    {
        /// <summary>
        /// Gets or sets the gold badge count.
        /// </summary>
        /// <value>The gold badge count.</value>
        [JsonProperty("gold")]
        public int Gold { get; set; }

        /// <summary>
        /// Gets or sets the silver badge count.
        /// </summary>
        /// <value>The silver badge count.</value>
        [JsonProperty("silver")]
        public int Silver { get; set; }

        /// <summary>
        /// Gets or sets the bronze.
        /// </summary>
        /// <value>The bronze badge count.</value>
        [JsonProperty("bronze")]
        public int Bronze { get; set; }
    }
}