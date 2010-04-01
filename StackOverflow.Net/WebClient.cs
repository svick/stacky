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
                request.UserAgent = Config.UserAgent;
                try
                {
                    using (var response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response != null)
                        {
                            var reader = new StreamReader(response.GetResponseStream());
                            return reader.ReadToEnd();
                        }
                    }
                }
                catch (WebException e)
                {
                    throw;
                }
            }
            return String.Empty;
        }
    }
}