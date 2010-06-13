using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    /// <summary>
    /// Unix time helper methods.
    /// </summary>
    public static class DateHelper
    {
        static DateTime _unixEpoch = new DateTime(1970, 1, 1);

        /// <summary>
        /// Converts unix time to <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="self">The <see cref="System.DateTime"/>.</param>
        /// <returns></returns>
        public static DateTime FromUnixTime(this Int64 self)
        {
            return _unixEpoch.AddSeconds(self);
        }

        /// <summary>
        /// Converts <see cref="System.DateTime"/> to unix time.
        /// </summary>
        /// <param name="self">The unix time.</param>
        /// <returns></returns>
        public static Int64 ToUnixTime(this DateTime self)
        {
            var delta = self - _unixEpoch;

            if (delta.TotalSeconds < 0) throw new ArgumentOutOfRangeException("self", "Unix epoch starts January 1st, 1970");

            return (long)delta.TotalSeconds;
        }
    }
}