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
#if SILVERLIGHT
        private IWebClient client;
#else
        private IWebClientAsync client;
#endif
        private IProtocol protocol;
        private string version;
        private string apiKey;

        #if SILVERLIGHT
        public StackOverflowClient(string version, IWebClient client, IProtocol protocol)
#else
        public StackOverflowClientAsync(string version, string apiKey, IWebClientAsync client, IProtocol protocol)
#endif
        {
            this.version = version;
            this.client = client;
            this.protocol = protocol;
            this.apiKey = apiKey;
        }

        #region Properties

#if SILVERLIGHT
        public IWebClient WebClient
#else
        public IWebClientAsync WebClient
#endif
        {
            get { return client; }
            set { client = value; }
        }

        public IProtocol Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }


#if DEBUG
        public Uri LastRequest { get; set; }
        public string LastResponse { get; set; }
        public string LastMethod { get; set; }
#endif
        #endregion

        #region Methods

        private void MakeRequest<T>(string method, bool secure, string[] urlArguments, object queryStringArguments, Action<T> callback, Action<ApiException> onError)
            where T : new()
        {
            MakeRequest<T>(method, secure, urlArguments, UrlHelper.ObjectToDictionary(queryStringArguments), callback, onError);
        }

        private void MakeRequest<T>(string method, bool secure, string[] urlArguments, Dictionary<string, string> queryStringArguments, Action<T> callback, Action<ApiException> onError)
             where T : new()
        {
            try
            {
                GetResponse(method, secure, urlArguments, queryStringArguments, response =>
                {
                    IResponse<T> r = protocol.GetResponse<T>(response.Body);
                    if (response.Error != null)
                    {
                        if(onError != null)
                            onError(new ApiException((int)r.Error.Code));
                        return;
                    }
                    else
                    {
                        callback(r.Data);
                    }
                }, onError);
            }
            catch (Exception e)
            {
                onError(new ApiException(Int32.MinValue, e));
            }
        }

        private void GetResponse(string method, bool secure, string[] urlArguments, Dictionary<string, string> queryStringArguments, Action<HttpResponse> callback, Action<ApiException> onError)
        {
            Uri url = UrlHelper.BuildUrl(method, version, secure, protocol.BaseUrl, urlArguments, queryStringArguments);
            client.MakeRequest(url, callback, onError);
        }

        private string GetSortDirection(SortDirection direction)
        {
            return direction == SortDirection.Ascending ? "asc" : "desc";
        }

        #endregion

    }
}