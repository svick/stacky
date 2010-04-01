using System;

namespace StackOverflow
{
    public class JsonProtocol : IProtocol
    {
        #region IProtocol Members

        public IResponse GetResponse(string message)
        {
            return new JsonResponse(message);
        }

        public IResponse<T> GetResponse<T>(string message) where T : new()
        {
            return new JsonResponse<T>(message);
        }

        public string BaseUrl
        {
            get { return "api.stackoverflow.com"; }
        }

        public string ResponseType
        {
            get { return "JSON"; }
        }

        #endregion
    }
}
