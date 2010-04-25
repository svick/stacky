using System;
using System.IO;
using System.Net;

namespace StackOverflow
{
    public class WebClient : IWebClient
    {
        public string MakeRequest(Uri url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            if (request != null)
            {
                //TODO: Figure out what user agent to use for the request
                request.UserAgent = "";
                try
                {
                    using (var response = request.GetResponse() as HttpWebResponse)
                    {
                        using (var responseStream = response.GetResponseStream())
                        {
                            var reader = new StreamReader(responseStream);
                            return reader.ReadToEnd();
                        }
                    }
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError && e.Response != null)
                    {
                        var response = (HttpWebResponse)e.Response;
                        if (response.StatusCode != HttpStatusCode.NotFound)
                        {
                            using (var responseStream = response.GetResponseStream())
                            {
                                var reader = new StreamReader(responseStream);
                                return reader.ReadToEnd();
                            }
                        }
                    }
                    throw;
                }
            }
            return String.Empty;
        }
    }
}