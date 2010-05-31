using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HttpClient = System.Net.WebClient;
using System.Net;
#if !SILVERLIGHT
using System.IO.Compression;
using System.IO;
#endif

namespace StackOverflow
{
#if SILVERLIGHT
    public class UrlClient : IUrlClient
#else
    public class UrlClientAsync : IUrlClientAsync
#endif
    {
        private class RequestContext
        {
            public Uri Url;
            public Action<HttpResponse> OnSuccess;
            public Action<ApiException> OnError;
        }

        public void MakeRequest(Uri url, Action<HttpResponse> onSuccess, Action<ApiException> onError)
        {
            var client = new HttpClient();

            //TODO: Set the User Agent string to something useful
            //client.Headers[HttpRequestHeader.UserAgent] = "";
#if !SILVERLIGHT
            client.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
            client.Encoding = Encoding.UTF8;
            client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
            client.DownloadDataAsync(url, new RequestContext{Url = url, OnSuccess = onSuccess, OnError = onError});
#else
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(url, new RequestContext{Url = url, OnSuccess = onSuccess, OnError = onError});
#endif
        }

#if !SILVERLIGHT
        public void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            RequestContext context = e.UserState as RequestContext;
            WebClient client = sender as WebClient;

            if (context != null)
            {
                if (e.Error != null)
                {
                    if (context.OnError != null)
                        context.OnError(new ApiException(null, e.Error));
                    return;
                }

                var response = new HttpResponse
                {
                    Body = "",
                    Url = context.Url
                };
                //response.ParseRateLimit(client.ResponseHeaders);

                using (var memoryStream = new MemoryStream(e.Result))
                {
                    using (var stream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        var decompressed = new List<byte>();
                        int i;
                        while ((i = stream.ReadByte()) != -1)
                            decompressed.Add((byte)i);
                        string decoded = Encoding.UTF8.GetString(decompressed.ToArray());

                        response.Body = decoded;
                    }
                }

                context.OnSuccess(response);
            }
        }
#endif

        public void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            RequestContext context = e.UserState as RequestContext;
            WebClient client = sender as WebClient;

            if (context != null)
            {
                if (e.Error != null)
                {
                    if (context.OnError != null)
                        context.OnError(new ApiException(null, e.Error));
                    return;
                }

                var response = new HttpResponse
                {
                    Body = e.Result,
                    Url = context.Url
                };

                //TODO: Figure out how to get the ResponseHeaders in Silverlight
                //response.ParseRateLimit(client.ResponseHeaders);
                context.OnSuccess(response);
            }
        }
    }
}