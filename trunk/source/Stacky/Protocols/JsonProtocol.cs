using System;

namespace Stacky
{
    public class JsonProtocol : IProtocol
    {
        public IResponse<T> GetResponse<T>(string message) where T : new()
        {
            return new JsonResponse<T>(message);
        }
    }
}