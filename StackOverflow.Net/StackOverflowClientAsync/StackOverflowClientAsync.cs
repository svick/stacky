using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace StackOverflow
{
#if SILVERLIGHT
    public partial class StackOverflowClient
#else
    public partial class StackOverflowClientAsync
#endif
    {
        private string version;
        private string apiKey;

#if SILVERLIGHT
        public StackOverflowClient(string version, string apiKey, HostSite site, IUrlClient client, IProtocol protocol)
#else
        public StackOverflowClientAsync(string version, string apiKey, HostSite site, IUrlClientAsync client, IProtocol protocol)
#endif
            : this(version, apiKey, site.GetAddress(), client, protocol)
        {
        }

#if SILVERLIGHT
        public StackOverflowClient(string version, string apiKey, string baseUrl, IUrlClient client, IProtocol protocol)
#else
        public StackOverflowClientAsync(string version, string apiKey, string baseUrl, IUrlClientAsync client, IProtocol protocol)
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


#if DEBUG
        public Uri LastRequest { get; set; }
        public string LastResponse { get; set; }
        public string LastMethod { get; set; }
#endif
        #endregion

        #region Methods

        private void MakeRequest<T>(string method, string[] urlArguments, object queryStringArguments, Action<T> onSuccess, Action<ApiException> onError)
            where T : new()
        {
            MakeRequest<T>(method, urlArguments, UrlHelper.ObjectToDictionary(queryStringArguments), onSuccess, onError);
        }

        private void MakeRequest<T>(string method, string[] urlArguments, Dictionary<string, string> queryStringArguments, Action<T> onSuccess, Action<ApiException> onError)
             where T : new()
        {
            try
            {
                GetResponse(method, urlArguments, queryStringArguments, response =>
                {
                    IResponse<T> r = Protocol.GetResponse<T>(response.Body);
                    if (response.Error != null)
                    {
                        if(onError != null)
                            onError(new ApiException(null, response.Error));
                        return;
                    }
                    else
                    {
                        onSuccess(r.Data);
                    }
                }, onError);
            }
            catch (Exception e)
            {
                onError(new ApiException(null, e));
            }
        }

        private void GetResponse(string method, string[] urlArguments, Dictionary<string, string> queryStringArguments, Action<HttpResponse> onSuccess, Action<ApiException> onError)
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