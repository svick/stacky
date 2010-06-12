#if !SILVERLIGHT
using System;

namespace Stacky
{
    public interface IUrlClient
    {
        HttpResponse MakeRequest(Uri url);
    }
}
#endif