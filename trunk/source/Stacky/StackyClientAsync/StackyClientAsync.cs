using System;
using System.Collections.Generic;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        private string version;
        private string apiKey;

#if SILVERLIGHT
        public StackyClient(string version, string apiKey, Site site, IUrlClient client, IProtocol protocol)
#else
        public StackyClientAsync(string version, string apiKey, Site site, IUrlClientAsync client, IProtocol protocol)
#endif
            : this(version, apiKey, site.ApiEndpoint, client, protocol)
        {
        }

#if SILVERLIGHT
        public StackyClient(string version, string apiKey, string baseUrl, IUrlClient client, IProtocol protocol)
#else
        public StackyClientAsync(string version, string apiKey, string baseUrl, IUrlClientAsync client, IProtocol protocol)
#endif
        {
            Require.NotNullOrEmpty(version, "version");
            Require.NotNullOrEmpty(baseUrl, "baseUrl");
            Require.NotNull(client, "client");
            Require.NotNull(client, "client");

            this.version = version;
            WebClient = client;
            BaseUrl = baseUrl;
            Protocol = protocol;
            this.apiKey = apiKey;
        }

        #region Properties

#if SILVERLIGHT
        public IUrlClient WebClient
#else
        public IUrlClientAsync WebClient
#endif
        { get; set; }

        public IProtocol Protocol { get; set; }
        public string BaseUrl { get; set; }

        public int RemainingRequests { get; internal set; }
        public int MaxRequests { get; internal set; }

        #endregion

        #region Methods

        public virtual void MakeRequest<T>(string method, string[] urlArguments, object queryStringArguments, Action<T> onSuccess, Action<ApiException> onError)
            where T : new()
        {
            MakeRequest<T>(method, urlArguments, UrlHelper.ObjectToDictionary(queryStringArguments), onSuccess, onError);
        }

        public virtual void MakeRequest<T>(string method, string[] urlArguments, Dictionary<string, string> queryStringArguments, Action<T> onSuccess, Action<ApiException> onError)
             where T : new()
        {
            try
            {
                HttpResponse httpResponse = null;
                GetResponse(method, urlArguments, queryStringArguments, response =>
                {
                    httpResponse = response;
                    ParseResponse<T>(httpResponse, onSuccess, onError);
                }, onError);
            }
            catch (Exception e)
            {
                onError(new ApiException(e));
            }
        }

        public virtual void ParseResponse<T>(HttpResponse httpResponse, Action<T> onSuccess, Action<ApiException> onError)
            where T : new()
        {
            if (httpResponse.Error != null && String.IsNullOrEmpty(httpResponse.Body))
                onError(new ApiException("Error retrieving url", null, httpResponse.Error, httpResponse.Url));

            RemainingRequests = httpResponse.RemainingRequests;
            MaxRequests = httpResponse.MaxRequests;

            var response = Protocol.GetResponse<T>(httpResponse.Body);
            if (response.Error != null)
                onError(new ApiException(response.Error));

            onSuccess(response.Data);
        }

        public virtual void GetResponse(string method, string[] urlArguments, Dictionary<string, string> queryStringArguments, Action<HttpResponse> onSuccess, Action<ApiException> onError)
        {
            Uri url = UrlHelper.BuildUrl(method, version, BaseUrl, urlArguments, queryStringArguments);
            WebClient.MakeRequest(url, onSuccess, onError);
        }

        private string GetSortDirection(SortDirection direction)
        {
            return direction == SortDirection.Ascending ? "asc" : "desc";
        }

        #endregion
    }
}