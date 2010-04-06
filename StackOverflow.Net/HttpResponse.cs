using System;

namespace StackOverflow
{
    public class HttpResponse
    {
        public string Body { get; set; }
        public Uri Url { get; set; }
        public Exception Error { get; set; }
    }
}