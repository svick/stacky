using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    public class StackAuthClient
    {
        public StackAuthClient(IUrlClient client, IProtocol protocol)
        {
            BaseUrl = "http://stackauth.com";
            WebClient = client;
            Protocol = protocol;
        }

        public IUrlClient WebClient { get; set; }
        public IProtocol Protocol { get; set; }
        public string BaseUrl { get; private set; }

        #region Methods
       
        public T MakeRequest<T>(string method, string[] urlArguments)
             where T : new()
        {
            var httpResponse = GetResponse(method, urlArguments, null);
            return ParseResponse<T>(httpResponse);
        }

        public T ParseResponse<T>(HttpResponse httpResponse)
            where T : new()
        {
            if (httpResponse.Error != null && String.IsNullOrEmpty(httpResponse.Body))
                throw new ApiException("Error retrieving url", null, httpResponse.Error, httpResponse.Url);

            var response = Protocol.GetResponse<T>(httpResponse.Body);
            if (response.Error != null)
                throw new ApiException(response.Error);

            return response.Data;
        }

        public HttpResponse GetResponse(string method, string[] urlArguments, Dictionary<string, string> queryStringArguments)
        {
            Uri url = UrlHelper.BuildUrl(method, "", BaseUrl, urlArguments, queryStringArguments);
            return WebClient.MakeRequest(url);
        }

        #endregion

        public IEnumerable<Site> GetSites()
        {
            return MakeRequest<SitesResponse>("sites", null).Sites;
        }

        public IEnumerable<AssociatedUser> GetAssociatedUsers(Guid associationId)
        {
            return MakeRequest<AssociatedUsersResponse>("users", new string[] { associationId.ToString(), "associated" }).Users;
        }
    }
}