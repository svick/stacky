#if !SILVERLIGHT
using System;

namespace StackOverflow
{
    public interface IUrlClient
    {
        HttpResponse MakeRequest(Uri url);
    }
}
#endif