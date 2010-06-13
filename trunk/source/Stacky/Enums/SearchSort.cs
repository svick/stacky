using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    /// <summary>
    /// Specifies the search sort order.
    /// </summary>
    public enum SearchSort
    {
        /// <summary>
        /// Activity.
        /// </summary>
        Activity,
        /// <summary>
        /// View count.
        /// </summary>
        Views,
        /// <summary>
        /// Creation date.
        /// </summary>
        Creation,
        /// <summary>
        /// Vote count.
        /// </summary>
        Votes
    }
}