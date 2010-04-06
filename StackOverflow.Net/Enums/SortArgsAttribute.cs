using System;

namespace StackOverflow
{
    public class SortArgsAttribute : Attribute
    {
        public SortArgsAttribute(params string[] args)
        {
            Args = args;
        }

        public string[] Args { get; private set; }
    }
}