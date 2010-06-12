using System;
using System.Net;

namespace Stacky
{
    public class HttpResponse
    {
        public string Body { get; set; }
        public Uri Url { get; set; }
        public Exception Error { get; set; }

        public int RemainingRequests { get; set; }
        public int MaxRequests { get; set; }

        public static string RateLimitCurrent = "X-RateLimit-Current";
        public static string RateLimitMax = "X-RateLimit-Max";

        internal void ParseRateLimit(WebHeaderCollection headers)
        {
            var rateLimitCurrent = headers[HttpResponse.RateLimitCurrent];
            var rateLimitMax = headers[HttpResponse.RateLimitMax];

            int current = 0;
            int max = 0;
            Int32.TryParse(rateLimitCurrent, out current);
            Int32.TryParse(rateLimitMax, out max);

            RemainingRequests = current;
            MaxRequests = max;
        }
    }
}