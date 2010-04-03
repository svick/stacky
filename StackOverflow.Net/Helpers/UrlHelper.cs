﻿#region Using Directives

using System;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
#if SILVERLIGHT && !PHONE
using System.Windows.Browser;
#endif
#if !PHONE && !SILVERLIGHT
using System.Web;
#endif

#endregion

namespace StackOverflow
{
    public static class UrlHelper
    {
        public static Uri BuildUrl(string method, bool secure, string serviceUrl, string[] urlParameters, object queryStringParameters)
        {
            return BuildUrl(method, secure, serviceUrl, urlParameters, BuildParameters(queryStringParameters));
        }

        public static Uri BuildUrl(string method, bool secure, string serviceUrl, string[] urlParameters, Dictionary<string, string> queryStringParameters)
        {
            return BuildUrl(method, secure, serviceUrl, urlParameters, BuildParameters(queryStringParameters));
        }

        private static Uri BuildUrl(string method, bool secure, string serviceUrl, string[] urlParameters, string queryString)
        {
            Require.NotNullOrEmpty(method, "method");
            Require.NotNullOrEmpty(serviceUrl, "serviceUrl");

            string scheme = secure ? Uri.UriSchemeHttps : Uri.UriSchemeHttp;

            string urlBase = String.Format(CultureInfo.CurrentCulture, "{0}://{1}/{2}/", scheme, serviceUrl, method);
            if (urlParameters != null)
            {
                foreach (string param in urlParameters)
                {
#if PHONE
                    urlBase += String.Format("{0}/", param);
#else
                    urlBase += String.Format("{0}/", HttpUtility.UrlEncode(param));
#endif
                }
            }
            Uri url = new Uri(urlBase);

            if (!String.IsNullOrEmpty(queryString))
            {
                url = new Uri(url, "?" + queryString);
            }
            return url;
        }

        public static string BuildParameters(Dictionary<string, string> parameters)
        {
            if (parameters == null)
                return String.Empty;

            StringBuilder s = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in parameters)
            {
#if PHONE
                s.AppendFormat("{0}={1}&", pair.Key, pair.Value);
#else
                s.AppendFormat("{0}={1}&", HttpUtility.UrlEncode(pair.Key), HttpUtility.UrlEncode(pair.Value));
#endif
            }
            if (s.Length > 0)
                s.Remove(s.Length - 1, 1);
            return s.ToString();
        }

        public static string BuildParameters(object parameters)
        {
            if (parameters == null)
                return String.Empty;

            return BuildParameters(ObjectToDictionary(parameters));
        }

        public static Dictionary<string, string> ObjectToDictionary(object item)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            if (item == null)
                return values;

            foreach (PropertyInfo property in item.GetType().GetProperties())
            {
                if (property.CanRead)
                {
                    object o = property.GetValue(item, null);
                    if (o != null)
                    {
                        values.Add(property.Name, o.ToString());
                    }
                }
            }

            return values;
        }
    }
}