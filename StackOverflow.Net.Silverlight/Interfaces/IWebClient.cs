using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using HttpClient = System.Net.WebClient;

namespace StackOverflow
{
    public interface IWebClient
    {
        void MakeRequest(Uri url, Action<HttpResponse> callback);
    }

    public class HttpResponse
    {
        public string Body { get; set; }
        public Uri Url { get; set; }
        public Exception Error { get; set; }
    }

    public class WebClient : IWebClient
    {
        private Action<HttpResponse> callback;
        private Uri url;

        public void MakeRequest(Uri url, Action<HttpResponse> callback)
        {
            this.callback = callback;
            this.url = url;

            var client = new HttpClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(url);
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var response = new HttpResponse
            {
                Body = e.Result,
                Url = url,
                Error = e.Error
            };
            callback(response);
        }
    }

}
