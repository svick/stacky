using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HttpClient = System.Net.WebClient;
using System.Net;

namespace StackOverflow
{
#if SILVERLIGHT
    public class WebClient : IWebClient
#else
    public class WebClientAsync : IWebClientAsync
#endif
    {
        private Action<HttpResponse> callback;
        Action<ApiException> onError;
        private Uri url;

        public void MakeRequest(Uri url, Action<HttpResponse> callback, Action<ApiException> onError)
        {
            this.callback = callback;
            this.url = url;
            this.onError = onError;

            var client = new HttpClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(url);
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
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
}