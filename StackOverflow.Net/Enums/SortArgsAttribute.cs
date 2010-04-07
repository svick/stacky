using System;

namespace StackOverflow
{
    public class SortArgsAttribute : Attribute
    {
        public SortArgsAttribute(string sort, params string[] urlArgs)
        {
            UrlArgs = urlArgs;
        }

        public string[] UrlArgs { get; private set; }
        public string Sort { get; set; }
    }
}