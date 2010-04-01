using System;

namespace StackOverflow
{
    public interface IWebClient
    {
        string MakeRequest(Uri url);
    }
}