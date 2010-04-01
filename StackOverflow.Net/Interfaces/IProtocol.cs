using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackOverflow
{
    public interface IProtocol
    {
        IResponse GetResponse(string message);
        IResponse<T> GetResponse<T>(string message) where T : new();
        string BaseUrl { get; }
        string ResponseType { get; }
    }
}