using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Stacky.Mvc
{
    public static class StringExtensions
    {
        public static String HtmlSanitize(this string input)
        {
            //Quick and dirty. I am sure there is a better way to do this.
            if (!string.IsNullOrEmpty(input))
            {
                return new Regex("<[^>]+?>").Replace(input, "");
            }
            return string.Empty;
        }
    }
}