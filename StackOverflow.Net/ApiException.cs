using System;

namespace StackOverflow
{
    public class ApiException : Exception
    {
        public int Error { get; set; }

        public ApiException() { }
        public ApiException(int error) : this("", error, null) { }
        public ApiException(int error, Exception innerException) : this("", error, innerException) { }
        public ApiException(string message, int error, Exception innerException)
            : base(message, innerException)
        {
            Error = error;
        }
    }
}