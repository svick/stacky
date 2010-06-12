using System;

namespace Stacky
{
#if SILVERLIGHT
    public interface IUrlClient
#else
    public interface IUrlClientAsync
#endif
    {
        void MakeRequest(Uri url, Action<HttpResponse> onSuccess, Action<ApiException> onError);
    }
}