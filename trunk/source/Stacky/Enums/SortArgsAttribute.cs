using System;

namespace Stacky
{
    public class SortArgsAttribute : Attribute
    {
        public SortArgsAttribute(string sort, params string[] urlArgs)
        {
            UrlArgs = urlArgs;
            Sort = sort;
        }

        public string[] UrlArgs { get; private set; }
        public string Sort { get; set; }
    }
}