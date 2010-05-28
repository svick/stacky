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
        private string version;
        private string apiKey;

        public StackOverflowClient(string version, string apiKey, HostSite site, IUrlClient client, IProtocol protocol)
            : this(version, apiKey, site.GetAddress(), client, protocol)
        {
        }

        public StackOverflowClient(string version, string apiKey, string baseUrl, IUrlClient client, IProtocol protocol)
        {
            Require.NotNullOrEmpty(version, "version");
            Require.NotNullOrEmpty(baseUrl, "baseUrl");
            Require.NotNull(client, "client");
            Require.NotNull(client, "client");

            this.version = version;
            this.apiKey = apiKey;
            BaseUrl = baseUrl;
            WebClient = client;
            Protocol = protocol;
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

            var response = Protocol.GetResponse<T>(httpResponse.Body);
            if (response.Error != null)
                throw new ApiException(response.Error);

            return response.Data;
        }

        private HttpResponse GetResponse(string method, string[] urlArguments, Dictionary<string, string> queryStringArguments)
        {
            Uri url = UrlHelper.BuildUrl(method, version, BaseUrl, urlArguments, queryStringArguments);
            return WebClient.MakeRequest(url);
        }

        private string GetSortDirection(SortDirection direction)
        {
            return direction == SortDirection.Ascending ? "asc" : "desc";
        }

        #endregion

        #region Properties

        public IUrlClient WebClient { get; set; }
        public IProtocol Protocol { get; set; }
        public string BaseUrl { get; set; }

        #endregion
    }
}
#endif