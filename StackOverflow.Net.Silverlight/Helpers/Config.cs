using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;

namespace StackOverflow
{
    public static class Config
    {
        public static string ServiceVersion
        {
            get { return "0.5"; }
        }

        public static string ApiKey
        {
            get { return "knockknock"; }
        }
    }
}