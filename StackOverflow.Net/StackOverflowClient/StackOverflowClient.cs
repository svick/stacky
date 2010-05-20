#if !SILVERLIGHT
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace StackOverflow
{
    public partial class StackOverflowClient
    {
        private IUrlClient client;
        private IProtocol protocol;
        private string version;
        private string apiKey;

        public StackOverflowClient(string version, string apiKey, IUrlClient client, IProtocol protocol)
        {
            this.version = version;
            this.apiKey = apiKey;
            this.client = client;
            this.protocol = protocol;
        }

        #region Methods

        private T MakeRequest<T>(string method, string[] urlArguments, object queryStringArguments)
            where T : new()
        {
            return MakeRequest<T>(method, urlArguments, UrlHelper.ObjectToDictionary(queryStringArguments));
        }

        private T MakeRequest<T>(string method, string[] urlArguments, Dictionary<string, string> queryStringArguments)
             where T : new()
        {
            string responseText = GetResponse(method, urlArguments, queryStringArguments);
            return SerializationHelper.DeserializeJson<T>(responseText);
        }

        private string GetResponse(string method, string[] urlArguments, Dictionary<string, string> queryStringArguments)
        {
            Uri url = UrlHelper.BuildUrl(method, version, protocol.BaseUrl, urlArguments, queryStringArguments);
            return client.MakeRequest(url);
        }

        private string GetSortDirection(SortDirection direction)
        {
            return direction == SortDirection.Ascending ? "asc" : "desc";
        }

        #endregion

        #region Properties

        public IUrlClient WebClient
        {
            get { return client; }
            set { client = value; }
        }

        public IProtocol Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }

        #endregion
    }
}
#endif