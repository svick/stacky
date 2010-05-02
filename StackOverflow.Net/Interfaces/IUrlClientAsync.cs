﻿using System;

namespace StackOverflow
{
#if SILVERLIGHT
    public interface IUrlClient
#else
    public interface IUrlClientAsync
#endif
    {
        void MakeRequest(Uri url, Action<HttpResponse> callback, Action<ApiException> onError);
    }
}