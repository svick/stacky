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
        private IUrlClient client;
#else
        private IUrlClientAsync client;
#endif
        private IProtocol protocol;
        private string version;
        private string apiKey;

        #if SILVERLIGHT
        public StackOverflowClient(string version, string apiKey, IUrlClient client, IProtocol protocol)
#else
        public StackOverflowClientAsync(string version, string apiKey, IUrlClientAsync client, IProtocol protocol)
#endif
        {
            this.version = version;
            this.client = client;
            this.protocol = protocol;
            this.apiKey = apiKey;
        }

        #region Properties

#if SILVERLIGHT
        public IUrlClient WebClient
#else
        public IUrlClientAsync WebClient
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

        private void MakeRequest<T>(string method, string[] urlArguments, object queryStringArguments, Action<T> callback, Action<ApiException> onError)
            where T : new()
        {
            MakeRequest<T>(method, urlArguments, UrlHelper.ObjectToDictionary(queryStringArguments), callback, onError);
        }

        private void MakeRequest<T>(string method, string[] urlArguments, Dictionary<string, string> queryStringArguments, Action<T> callback, Action<ApiException> onError)
             where T : new()
        {
            try
            {
                GetResponse(method, urlArguments, queryStringArguments, response =>
                {
                    IResponse<T> r = protocol.GetResponse<T>(response.Body);
                    if (response.Error != null)
                    {
                        if(onError != null)
                            onError(new ApiException(null, response.Error));
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
                onError(new ApiException(null, e));
            }
        }

        private void GetResponse(string method, string[] urlArguments, Dictionary<string, string> queryStringArguments, Action<HttpResponse> callback, Action<ApiException> onError)
        {
            Uri url = UrlHelper.BuildUrl(method, version, protocol.BaseUrl, urlArguments, queryStringArguments);
            client.MakeRequest(url, callback, onError);
        }

        private string GetSortDirection(SortDirection direction)
        {
            return direction == SortDirection.Ascending ? "asc" : "desc";
        }

        #endregion

    }
}