using System;

namespace StackOverflow
{
#if SILVERLIGHT
    public interface IWebClient
#else
    public interface IWebClientAsync
#endif
    {
        void MakeRequest(Uri url, Action<HttpResponse> callback);
    }
}