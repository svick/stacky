using System;
using System.IO;
using System.Net;

namespace Stacky
{
    public class UrlClient : IUrlClient
    {
        public HttpResponse MakeRequest(Uri url)
        {
            HttpResponse httpResponse = new HttpResponse
            {
                Url = url
            };
            var request = WebRequest.Create(url) as HttpWebRequest;
            if (request != null)
            {
                request.UserAgent = "Stacky";
                request.Accept = "gzip,deflate";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                try
                {
                    using (var response = request.GetResponse() as HttpWebResponse)
                    {
                        httpResponse.ParseRateLimit(response.Headers);
                        using (var responseStream = response.GetResponseStream())
                        {
                            var reader = new StreamReader(responseStream);
                            httpResponse.Body = reader.ReadToEnd();
                        }
                    }
                }
                catch (WebException e)
                {
                    httpResponse.Error = e;
                    if (e.Status == WebExceptionStatus.ProtocolError && e.Response != null)
                    {
                        var response = (HttpWebResponse)e.Response;
                        if (response.StatusCode != HttpStatusCode.NotFound)
                        {
                            httpResponse.ParseRateLimit(response.Headers);
                            using (var responseStream = response.GetResponseStream())
                            {
                                using (var reader = new StreamReader(responseStream))
                                {
                                    httpResponse.Body = reader.ReadToEnd();
                                }
                            }
                        }
                    }
                }
            }
            return httpResponse;
        }
    }
}