using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Collections.Specialized;
using System.Resources;
using System.Reflection;
using System.Globalization;
using Stacky.OfflineClient.Properties;

namespace Stacky.OfflineClient
{
    public class ResourceUrlClient : IUrlClient
    {
        private IEnumerable<OfflineResponse> responses = null;
        private IEnumerable<OfflineResponse> Responses
        {
            get
            {
                if (responses == null)
                {
                    responses = ResponseCollector.GetResponses().ToList();
                }
                return responses;
            }
        }

        private IResponseCollector ResponseCollector { get; set; }
        private IUrlMatcher UrlMatcher { get; set; }
        
        public ResourceUrlClient(IResponseCollector responseCollector, IUrlMatcher urlMatcher)
        {
            ResponseCollector = responseCollector;
            UrlMatcher = urlMatcher;
        }

        public HttpResponse MakeRequest(Uri url)
        {
            foreach (var response in Responses)
            {
                if (UrlMatcher.IsMatch(url, response.Url))
                {
                    return new HttpResponse
                    {
                        Body = response.Body,
                        Url = url
                    };
                }
            }
            return null;
        }
    }

    public class OfflineResponse
    {
        public Uri Url { get; set; }
        public string Body { get; set; }

        public OfflineResponse(string response)
        {
            StringReader sr = new StringReader(response);
            Url = new Uri(sr.ReadLine());
            Body = sr.ReadToEnd();
        }
    }

    public interface IUrlMatcher
    {
        bool IsMatch(Uri actualUrl, Uri templateUrl);
    }

    public class UrlMatcher : IUrlMatcher
    {
        public static readonly string OptionalParameterStart = "<";
        public static readonly string OptionalParameterEnd = ">";

        public static readonly string EnumeratedListStart = "[";
        public static readonly string EnumeratedListEnd = "]";

        public bool IsMatch(Uri actualUrl, Uri templateUrl)
        {
            if (actualUrl.ToString() == templateUrl.ToString())
                return true;

            if (actualUrl.AbsolutePath != templateUrl.AbsolutePath)
                return false;

            var templateQueryString = ParseQueryString(templateUrl.Query).ToList();
            var actualQueryString = ParseQueryString(actualUrl.Query).ToList();
            foreach (var item in templateQueryString)
            {
                var actualItem = (from i in actualQueryString
                                   where i.Key == item.Key
                                   select i).FirstOrDefault();

                if (actualItem == null)
                {
                    if (item.IsEnumerated)
                    {
                        if (item.IsKeyEnumerated)
                        {
                            actualItem = (from i in actualQueryString
                                          where item.EnumerationContains(item.Key, i.Key)
                                          select i).FirstOrDefault();
                            if (!item.EnumerationContains(item.Key, actualItem.Key))
                                return false;
                        }

                        if (item.IsValueEnumerated)
                        {
                            actualItem = (from i in actualQueryString
                                          where item.EnumerationContains(item.Value, i.Value)
                                          select i).FirstOrDefault();
                            if (!item.EnumerationContains(item.Value, actualItem.Value))
                                return false;
                        }
                    }
                    else if(!item.IsOptional)
                        return false;
                    continue;
                }

                if (!item.IsWildcard && item.Value != actualItem.Value)
                {
                    return false;
                }
            }

            return true;
        }

        private string Normalize(string item)
        {
            if (String.IsNullOrEmpty(item))
                return "";

            if (IsOptional(item))
                return item.Substring(1, item.Length - 1);
            return item;
        }

        private bool IsOptional(string key)
        {
            if (String.IsNullOrEmpty(key))
                return false;
            return key.StartsWith(OptionalParameterStart) && key.EndsWith(OptionalParameterEnd);
        }

        private bool IsEnumerated(string item)
        {
            if (String.IsNullOrEmpty(item))
                return false;
            return item.StartsWith(EnumeratedListStart) && item.EndsWith(EnumeratedListEnd);
        }

        private IEnumerable<QueryStringParameter> ParseQueryString(string queryString)
        {
            var parsed = HttpUtility.ParseQueryString(queryString);
            foreach (string key in parsed.AllKeys)
            {
                string value = parsed[key];
                yield return new QueryStringParameter
                {
                    Key = Normalize(key),
                    Value = Normalize(value),
                    IsWildcard = value == "*",
                    IsOptional = IsOptional(key),
                    IsKeyEnumerated = IsEnumerated(key),
                    IsValueEnumerated = IsEnumerated(value)
                };
            }
        }
    }

    internal class QueryStringParameter
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public bool IsOptional { get; set; }
        public bool IsWildcard { get; set; }
        public bool IsKeyEnumerated { get; set; }
        public bool IsValueEnumerated { get; set; }
        public bool IsEnumerated { get { return IsKeyEnumerated || IsValueEnumerated; } }

        internal bool EnumerationContains(string enumeration, string item)
        {
            if (String.IsNullOrEmpty(enumeration) || String.IsNullOrEmpty(item))
                return false;
            IEnumerable<string> items = enumeration.Split('|');
            return items.Contains(item);
        }
    }

    public interface IResponseCollector
    {
        IEnumerable<OfflineResponse> GetResponses();
    }

    public class ResourceResponseCollector : IResponseCollector
    {
        public IEnumerable<OfflineResponse> GetResponses()
        {
            var type = typeof(Resources);
            var instance = new Resources();
            var props = type.GetProperties(BindingFlags.Static | BindingFlags.Public);
            foreach (var prop in props.Where(info => !ShouldIgnoreProperty(info.Name)))
            {
                var value = prop.GetValue(instance, null);
                if (value != null)
                {
                    yield return new OfflineResponse(value.ToString());
                }
            }
        }

        private bool ShouldIgnoreProperty(string name)
        {
            return name == "ResourceManager" ||
                name == "Culture";
        }
    }

}