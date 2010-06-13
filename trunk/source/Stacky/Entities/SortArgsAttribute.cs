using System;

namespace Stacky
{
    /// <summary>
    /// Specifies the sort arguments from JSON. 
    /// </summary>
    public class SortArgsAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SortArgsAttribute"/> class.
        /// </summary>
        /// <param name="sort">The sort type.</param>
        /// <param name="urlArgs">The URL args.</param>
        public SortArgsAttribute(string sort, params string[] urlArgs)
        {
            UrlArgs = urlArgs;
            Sort = sort;
        }

        /// <summary>
        /// Gets the URL arguments.
        /// </summary>
        /// <value>The URL arguments.</value>
        public string[] UrlArgs { get; private set; }


        /// <summary>
        /// Gets or sets the sort type.
        /// </summary>
        /// <value>The sort type.</value>
        public string Sort { get; set; }
    }
}