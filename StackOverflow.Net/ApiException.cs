using System;

namespace StackOverflow
{
    public class ApiException : Exception
    {
        public ResponseError Error { get; set; }

        public ApiException() { }
        public ApiException(ResponseError error) : this("", error, null) { }
        public ApiException(ResponseError error, Exception innerException) : this("", error, innerException) { }
        public ApiException(string message, ResponseError error, Exception innerException)
            : base(message, innerException)
        {
            Error = error;
        }
    }
}