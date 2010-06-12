using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    public static class DateHelper
    {
        static DateTime _unixEpoch = new DateTime(1970, 1, 1);

        public static DateTime FromUnixTime(this Int64 self)
        {
            return _unixEpoch.AddSeconds(self);
        }

        public static Int64 ToUnixTime(this DateTime self)
        {
            var delta = self - _unixEpoch;

            if (delta.TotalSeconds < 0) throw new ArgumentOutOfRangeException("self", "Unix epoch starts January 1st, 1970");

            return (long)delta.TotalSeconds;
        }
    }
}