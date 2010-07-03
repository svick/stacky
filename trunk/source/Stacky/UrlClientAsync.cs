using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HttpClient = System.Net.WebClient;
using System.Net;
#if WINDOWSPHONE
using ICSharpCode.SharpZipLib.GZip;
using System.IO;
#endif
#if !SILVERLIGHT
using System.IO.Compression;
using System.IO;
#endif

namespace Stacky
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
            //client.Headers[HttpRequestHeader.UserAgent] = "Stacky";
#if !SILVERLIGHT
            client.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
            client.Encoding = Encoding.UTF8;
            client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
            client.DownloadDataAsync(url, new RequestContext{Url = url, OnSuccess = onSuccess, OnError = onError});
#else
#if WINDOWSPHONE
            client.OpenReadAsync(url, new RequestContext { Url = url, OnSuccess = onSuccess, OnError = onError });
            client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
#else
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(url, new RequestContext{Url = url, OnSuccess = onSuccess, OnError = onError});
#endif
#endif
        }

#if !SILVERLIGHT
        public void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            RequestContext context = e.UserState as RequestContext;
            WebClient client = sender as WebClient;

            if (context != null)
            {
                var httpResponse = new HttpResponse
                {
                    Body = "",
                    Url = context.Url
                };

                if (e.Error != null)
                {
                    httpResponse.Error = e.Error;
                    var webError = e.Error as WebException;
                    if (webError != null)
                    {
                        if (webError.Status == WebExceptionStatus.ProtocolError && webError.Response != null)
                        {
                            var response = (HttpWebResponse)webError.Response;
                            if (response.StatusCode != HttpStatusCode.NotFound)
                            {
                                using (var responseStream = response.GetResponseStream())
                                {
                                    httpResponse.Body = DecodeResponseStream(responseStream);
                                    ErrorResponse errorResponse = SerializationHelper.DeserializeJson<ErrorResponse>(httpResponse.Body);
                                    if (context.OnError != null)
                                        context.OnError(new ApiException(errorResponse.Error, e.Error, httpResponse.Url));
                                    return;
                                }
                            }
                        }
                        if (context.OnError != null)
                            context.OnError(new ApiException(e.Error));
                        return;
                    }
                }

                //response.ParseRateLimit(client.ResponseHeaders);
                using (var memoryStream = new MemoryStream(e.Result))
                {
                    httpResponse.Body = DecodeResponseStream(memoryStream);
                }
                context.OnSuccess(httpResponse);
            }
        }

        private string DecodeResponseStream(Stream stream)
        {
            using (var gzipStream = new GZipStream(stream, CompressionMode.Decompress))
            {
                var decompressed = new List<byte>();
                int i;
                while ((i = gzipStream.ReadByte()) != -1)
                    decompressed.Add((byte)i);
                return Encoding.UTF8.GetString(decompressed.ToArray());
            }
        }
#endif
#if WINDOWSPHONE
        void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            string data;
            using (var gzip = new GZipInputStream(e.Result))
            using (var reader = new StreamReader(gzip))
            {
                data = reader.ReadToEnd();
            }

            RequestContext context = e.UserState as RequestContext;
            WebClient client = sender as WebClient;

            if (context != null)
            {
                var httpResponse = new HttpResponse
                {
                    Url = context.Url
                };

                if (e.Error != null)
                {
                    httpResponse.Error = e.Error;
                    var webError = e.Error as WebException;
                    if (context.OnError != null)
                        context.OnError(new ApiException(e.Error, httpResponse.Url));
                    return;
                }

                httpResponse.Body = data;
                context.OnSuccess(httpResponse);
            }
        }
#endif

        public void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            RequestContext context = e.UserState as RequestContext;
            WebClient client = sender as WebClient;

            if (context != null)
            {
                var httpResponse = new HttpResponse
                {
                    Url = context.Url
                };

                if (e.Error != null)
                {
                    httpResponse.Error = e.Error;
                    var webError = e.Error as WebException;
                    if (context.OnError != null)
                        context.OnError(new ApiException(e.Error, httpResponse.Url));
                    return;
                }
                
                //TODO: Figure out how to get the ResponseHeaders in Silverlight
                //response.ParseRateLimit(client.ResponseHeaders);
                httpResponse.Body = e.Result;
                context.OnSuccess(httpResponse);
            }
        }
    }
}