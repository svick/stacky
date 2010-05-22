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
        private class RequestHelper
        {
            public RequestHelper(Uri url, Action<HttpResponse> callback, Action<ApiException> onError)
            {
                this.callback = callback;
                this.url = url;
                this.onError = onError;
            }

            private Action<HttpResponse> callback;
            Action<ApiException> onError;
            private Uri url;

#if !SILVERLIGHT
            public void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
            {
                if (e.Error != null)
                {
                    if (onError != null)
                        onError(new ApiException(null, e.Error));
                    return;
                }

                using (var memoryStream = new MemoryStream(e.Result))
                {
                    using (var stream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        var decompressed = new List<byte>();
                        int i;
                        while ((i = stream.ReadByte()) != -1)
                            decompressed.Add((byte)i);
                        string decoded = Encoding.UTF8.GetString(decompressed.ToArray());
                        var response = new HttpResponse
                        {
                            Body = decoded,
                            Url = url
                        };
                        callback(response);
                    }
                }
            }
#endif

            public void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
            {
                if (e.Error != null)
                {
                    if (onError != null)
                        onError(new ApiException(null, e.Error));
                    return;
                }

                var response = new HttpResponse
                {
                    Body = e.Result,
                    Url = url
                };
                callback(response);
            }
        }

        public void MakeRequest(Uri url, Action<HttpResponse> callback, Action<ApiException> onError)
        {
            var client = new HttpClient();
            var requestHelper = new RequestHelper(url, callback, onError);

            //TODO: Set the User Agent string to something useful
            //client.Headers[HttpRequestHeader.UserAgent] = "";
#if !SILVERLIGHT
            client.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
            client.Encoding = Encoding.UTF8;
            client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(requestHelper.client_DownloadDataCompleted);
            client.DownloadDataAsync(url);
#else
            // TODO: This assumes that the client app will not start new web request before the previous one has completed
            // Need to create a wrapper instance per request
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(requestHelper.client_DownloadStringCompleted);
            client.DownloadStringAsync(url);
#endif
        }
    }
}