#if !SILVERLIGHT
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Diagnostics.Contracts;

namespace StackOverflow
{
    public partial class StackOverflowClient
    {
        private IUrlClient client;
        private IProtocol protocol;
        private string version;
        private string apiKey;
        private string baseUrl;

        public StackOverflowClient(string version, string apiKey, HostSite site, IUrlClient client, IProtocol protocol)
            : this(version, apiKey, site.GetAddress(), client, protocol)
        {
        }

        public StackOverflowClient(string version, string apiKey, string baseUrl, IUrlClient client, IProtocol protocol)
        {
            Contract.Requires(!String.IsNullOrEmpty(version), "version cannot be null or empty");
            Contract.Requires(!String.IsNullOrEmpty(baseUrl), "baseUrl cannot be null or empty");
            Contract.Requires(client != null, "client cannot be null");
            Contract.Requires(protocol != null, "protocol cannot be null");

            this.version = version;
            this.apiKey = apiKey;
            this.baseUrl = baseUrl;
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
            var httpResponse = GetResponse(method, urlArguments, queryStringArguments);
            if (httpResponse.Error != null)
                throw new ApiException("Error retrieving url", null, httpResponse.Error);

            var response = protocol.GetResponse<T>(httpResponse.Body);
            if (response.Error != null)
                throw new ApiException(response.Error);

            return response.Data;
        }

        private HttpResponse GetResponse(string method, string[] urlArguments, Dictionary<string, string> queryStringArguments)
        {
            Uri url = UrlHelper.BuildUrl(method, version, baseUrl, urlArguments, queryStringArguments);
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