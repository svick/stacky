using System;
using System.Collections.Generic;

namespace Stacky
{
#if SILVERLIGHT
    public class StackAuthClient
#else
    public class StackAuthClientAsync
#endif
    {
#if SILVERLIGHT
		    public StackAuthClient(IUrlClient client, IProtocol protocol)
#else
        public StackAuthClientAsync(IUrlClientAsync client, IProtocol protocol)
#endif
        {
            BaseUrl = "http://stackauth.com";
            WebClient = client;
            Protocol = protocol;
        }

#if SILVERLIGHT
		    public IUrlClient WebClient { get; set; }
#else
        public IUrlClientAsync WebClient { get; set; }
#endif
        public IProtocol Protocol { get; set; }
        public string BaseUrl { get; private set; }

        #region Methods

        public void MakeRequest<T>(string method, string[] urlArguments, Action<T> onSuccess, Action<ApiException> onError)
                where T : new()
        {
            try
            {
                HttpResponse httpResponse = null;
                GetResponse(method, urlArguments, response =>
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

        public void ParseResponse<T>(HttpResponse httpResponse, Action<T> onSuccess, Action<ApiException> onError)
            where T : new()
        {
            if (httpResponse.Error != null && String.IsNullOrEmpty(httpResponse.Body))
                onError(new ApiException("Error retrieving url", null, httpResponse.Error, httpResponse.Url));

            var response = Protocol.GetResponse<T>(httpResponse.Body);
            if (response.Error != null)
                onError(new ApiException(response.Error));

            onSuccess(response.Data);
        }

        public void GetResponse(string method, string[] urlArguments, Action<HttpResponse> onSuccess, Action<ApiException> onError)
        {
            Uri url = UrlHelper.BuildUrl(method, "", BaseUrl, urlArguments, null);
            WebClient.MakeRequest(url, onSuccess, onError);
        }

        #endregion

        public void GetSites(Action<IEnumerable<Site>> onSuccess, Action<ApiException> onError)
        {
            MakeRequest<SitesResponse>("sites", null, response => onSuccess(response.Sites), onError);
        }

        public void GetAssociatedUsers(Guid associationId, Action<IEnumerable<AssociatedUser>> onSuccess, Action<ApiException> onError)
        {
            MakeRequest<AssociatedUsersResponse>("users", new string[] { associationId.ToString(), "associated" }, response => onSuccess(response.Users), onError);
        }
    }
}