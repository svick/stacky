#if !SILVERLIGHT
using System;

namespace StackOverflow
{
    public interface IUrlClient
    {
        string MakeRequest(Uri url);
    }
}
#endif