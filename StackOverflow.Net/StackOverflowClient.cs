using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace StackOverflow
{
    public class StackOverflowClient
    {
        private IWebClient client;
        private IProtocol protocol;
        private string version;

        public StackOverflowClient(string version, IWebClient client, IProtocol protocol)
        {
            this.version = version;
            this.client = client;
            this.protocol = protocol;
        }

        #region Methods

        private void MakeRequest(string method, bool secure, string[] urlArguments, object queryStringArguments)
        {
            string resposneText = GetResponse(method, secure, urlArguments, UrlHelper.ObjectToDictionary(queryStringArguments));
            IResponse response = protocol.GetResponse(resposneText);
            if (response.Error != null)
                throw new ApiException(response.Error.ErrorCode);
        }

        private T MakeRequest<T>(string method, bool secure, string[] urlArguments, object queryStringArguments)
            where T : new()
        {
            return MakeRequest<T>(method, secure, urlArguments, UrlHelper.ObjectToDictionary(queryStringArguments));
        }

        private T MakeRequest<T>(string method, bool secure, string[] urlArguments, Dictionary<string, string> queryStringArguments)
             where T : new()
        {
            string resposneText = GetResponse(method, secure, urlArguments, queryStringArguments);
            IResponse<T> response = protocol.GetResponse<T>(resposneText);
            if (response.Error != null)
                throw new ApiException(response.Error.ErrorCode);
            return response.Data;
        }

        private string GetResponse(string method, bool secure, string[] urlArguments, Dictionary<string, string> queryStringArguments)
        {
            ClearLastResponse();
#if DEBUG
            LastMethod = method;
#endif

            Uri url = UrlHelper.BuildUrl(method, secure, ServiceUrl, urlArguments, queryStringArguments);
#if DEBUG
            LastRequest = url;
#endif

            string response = client.MakeRequest(url);

#if DEBUG
            LastResponse = response;
#endif
            return response;
        }

        private void ClearLastResponse()
        {
#if DEBUG
            LastMethod = null;
            LastRequest = null;
            LastResponse = null;
#endif
        }

        #endregion

        #region Properties

        private string ServiceUrl
        {
            get
            {
                return String.Format(CultureInfo.CurrentCulture, "{0}/{1}", protocol.BaseUrl, version);
            }
        }

        public IWebClient WebClient
        {
            get { return client; }
            set { client = value; }
        }

        public IProtocol Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }


#if DEBUG
        public Uri LastRequest { get; set; }
        public string LastResponse { get; set; }
        public string LastMethod { get; set; }
#endif
        #endregion

        #region API Methods

        public IList<Question> GetQuestions()
        {
            return MakeRequest<List<Question>>("questions", false, (string[])null, new
            {
                key = Config.ApiKey
            });
        }

        public Question GetQuestion(int id, bool includeBody)
        {
            return MakeRequest<Question>("questions", false, new string[] { id.ToString() }, new
            {
                key = Config.ApiKey,
                body = includeBody ? "true" : "false"
            });
        }

        #endregion
    }

    public enum QuestionSort
    {
        Active,
        Newest,
        Featured,
        Hot,
        Week,
        Month,
        Votes,
        UnAnswered,
        UnAnsweredNewest,
        UnAnsweredVotes
    }
}