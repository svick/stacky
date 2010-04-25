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
        private IWebClient client;
        private IProtocol protocol;
        private string version;
        private string apiKey;

        public StackOverflowClient(string version, string apiKey, IWebClient client, IProtocol protocol)
        {
            this.version = version;
            this.apiKey = apiKey;
            this.client = client;
            this.protocol = protocol;
        }

        #region Methods

        private void MakeRequest(string method, bool secure, string[] urlArguments, object queryStringArguments)
        {
            string resposneText = GetResponse(method, secure, urlArguments, UrlHelper.ObjectToDictionary(queryStringArguments));
            IResponse response = protocol.GetResponse(resposneText);
            if (response.Error != null)
                throw new ApiException((int)response.Error.Code);
        }

        private T MakeRequest<T>(string method, bool secure, string[] urlArguments, object queryStringArguments)
            where T : new()
        {
            return MakeRequest<T>(method, secure, urlArguments, UrlHelper.ObjectToDictionary(queryStringArguments));
        }

        private T MakeRequest<T>(string method, bool secure, string[] urlArguments, Dictionary<string, string> queryStringArguments)
             where T : new()
        {
            string resposneText = GetResponse(method, secure, urlArguments, queryStringArguments);
            IResponse<T> response = protocol.GetResponse<T>(resposneText);
            if (response.Error != null)
                throw new ApiException((int)response.Error.Code);
            return response.Data;
        }

        private string GetResponse(string method, bool secure, string[] urlArguments, Dictionary<string, string> queryStringArguments)
        {
            Uri url = UrlHelper.BuildUrl(method, version, secure, protocol.BaseUrl, urlArguments, queryStringArguments);
            return client.MakeRequest(url);
        }

        private string GetSortDirection(SortDirection direction)
        {
            return direction == SortDirection.Ascending ? "asc" : "desc";
        }

        #endregion

        #region Properties

        public IWebClient WebClient
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