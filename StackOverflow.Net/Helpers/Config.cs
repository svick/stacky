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
            get { return GetString("StackOverflow.ServiceVersion", ".5"); }
        }

        public static string ApiKey
        {
            get { return GetString("StackOverflow.ApiKey", ""); }
        }

        public static string UserAgent
        {
            get { return GetString("StackOverflow.UserAgent", ""); }
        }

        public static int? GetInt32(string key, int? defaultValue)
        {
            string s = ConfigurationManager.AppSettings[key];
            int val;
            if(Int32.TryParse(s, out val))
            {
                return val;
            }
            return defaultValue;
        }

        public static string GetString(string key, string defaultValue)
        {
            string s = ConfigurationManager.AppSettings[key];
            if(String.IsNullOrEmpty(s))
            {
                return defaultValue;
            }
            return s;
        }

        public static bool? GetBoolean(string key, bool? defaultValue)
        {
            string s = ConfigurationManager.AppSettings[key];
            bool val;
            if (Boolean.TryParse(s, out val))
            {
                return val;
            }
            return defaultValue;
        }
    }
}