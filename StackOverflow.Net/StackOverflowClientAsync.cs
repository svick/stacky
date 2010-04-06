using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace StackOverflow
{
#if SILVERLIGHT
    public class StackOverflowClient
#else
    public class StackOverflowClientAsync
#endif
    {
#if SILVERLIGHT
        private IWebClient client;
#else
        private IWebClientAsync client;
#endif
        private IProtocol protocol;
        private string version;

        #if SILVERLIGHT
        public StackOverflowClient(string version, IWebClient client, IProtocol protocol)
#else
        public StackOverflowClientAsync(string version, IWebClientAsync client, IProtocol protocol)
#endif
        {
            this.version = version;
            this.client = client;
            this.protocol = protocol;
        }

        #region Properties

        private string ServiceUrl
        {
            get
            {
                return String.Format(CultureInfo.CurrentCulture, "{0}/{1}", protocol.BaseUrl, version);
            }
        }

#if SILVERLIGHT
        public IWebClient WebClient
#else
        public IWebClientAsync WebClient
#endif
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

        #region Methods

        private void MakeRequest<T>(string method, bool secure, string[] urlArguments, object queryStringArguments, Action<T> callback)
            where T : new()
        {
            MakeRequest<T>(method, secure, urlArguments, UrlHelper.ObjectToDictionary(queryStringArguments), callback);
        }

        private void MakeRequest<T>(string method, bool secure, string[] urlArguments, Dictionary<string, string> queryStringArguments, Action<T> callback)
             where T : new()
        {
            GetResponse(method, secure, urlArguments, queryStringArguments, response =>
            {
                IResponse<T> r = protocol.GetResponse<T>(response.Body);
                if (response.Error != null)
                    throw new ApiException(r.Error.ErrorCode);
                callback(r.Data);
            });
        }

        private void GetResponse(string method, bool secure, string[] urlArguments, Dictionary<string, string> queryStringArguments, Action<HttpResponse> callback)
        {
            Uri url = UrlHelper.BuildUrl(method, secure, ServiceUrl, urlArguments, queryStringArguments);
            client.MakeRequest(url, callback);
        }

        #endregion

        #region API Methods

        #region Question Methods

        public void GetQuestions(Action<List<Question>> callback, QuestionSort sortBy = QuestionSort.Active, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            var sortArgs = sortBy.GetAttribute<SortArgsAttribute>();
            GetQuestions(callback, "questions", sortArgs.Args, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetQuestionsByUser(int userId, Action<List<Question>> callback, QuestionsByUserSort sortBy = QuestionsByUserSort.Recent, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "users", new string[] { userId.ToString(), "questions", sortBy.ToString().ToLower() }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetFavoriteQuestionsByUser(int userId, Action<List<Question>> callback, FavoriteQuestionsSort sortBy = FavoriteQuestionsSort.Recent, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "users", new string[] { userId.ToString(), "favorites", sortBy.ToString().ToLower() }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        private void GetQuestions(Action<List<Question>> callback, string method, string[] sort, int? page, int? pageSize, bool includeBody, bool includeComments, DateTime? fromDate, DateTime? toDate, params string[] tags)
        {
            MakeRequest<List<Question>>(method, false, sort, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
                tagged = tags == null ? (string)null : String.Join(" ", tags)
            }, callback);
        }

        public void GetQuestion(int id, Action<Question> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            MakeRequest<List<Question>>("questions", false, new string[] { id.ToString() }, new
            {
                key = Config.ApiKey,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                page = page ?? null,
                pagesize = pageSize ?? null
            }, returnedQuestions => callback(returnedQuestions.FirstOrDefault()));
        }

        public void GetQuestionTimeline(int questionId, Action<List<PostEvent>> callback, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<List<PostEvent>>("questions", false, new string[] { questionId.ToString(), "timeline" }, new
            {
                key = Config.ApiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, callback);
        }

        #endregion

        #region User Methods

        public void GetUsers(Action<List<User>> callback, UserSort sortBy = UserSort.Reputation, int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<List<User>>("users", false, new string[] { sortBy.ToString().ToLower() }, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter
            }, callback);
        }

        public void GetUser(int userId, Action<User> callback)
        {
            MakeRequest<List<User>>("users", false, new string[] { userId.ToString() }, new
            {
                key = Config.ApiKey
            }, results => callback(results.FirstOrDefault()));
        }

        public void GetUserMentions(int userId, Action<List<Comment>> callback, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<List<Comment>>("users", false, new string[] { userId.ToString(), "mentioned" }, new
            {
                key = Config.ApiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, callback);
        }

        public void GetUserTimeline(int userId, Action<List<UserEvent>> callback, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<List<UserEvent>>("users", false, new string[] { userId.ToString(), "timeline" }, new
            {
                key = Config.ApiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, callback);
        }

        public void GetUserReputation(int userId, Action<List<Reputation>> callback, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<List<Reputation>>("users", false, new string[] { userId.ToString(), "reputation" }, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, callback);
        }

        #endregion

        #region Badge Methods

        public void GetBadges(Action<List<Badge>> callback, BadgeSort sortBy = BadgeSort.Name)
        {
            GetBadges(callback, "badges", new string[] { sortBy.ToString().ToLower() });
        }

        private void GetBadges(Action<List<Badge>> callback, string method, string[] sort)
        {
            MakeRequest<List<Badge>>(method, false, sort, new
            {
                key = Config.ApiKey
            }, callback);
        }

        public void GetBadgesByUser(int userId, Action<List<Badge>> callback)
        {
            GetBadges(callback, "users", new string[] { userId.ToString(), "badges" });
        }

        #endregion

        #region Tag Methods

        public void GetTags(Action<List<Tag>> callback, TagSort sortBy = TagSort.Popular, int? page = null, int? pageSize = null)
        {
            GetTags(callback, "tags", new string[] { sortBy.ToString().ToLower() }, page, pageSize);
        }

        private void GetTags(Action<List<Tag>> callback, string method, string[] urlParameters, int? page = null, int? pageSize = null)
        {
            MakeRequest<List<Tag>>(method, false, urlParameters, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null
            }, callback);
        }

        public void GetTagsByUser(int userId, Action<List<Tag>> callback, int? page = null, int? pageSize = null)
        {
            GetTags(callback, "users", new string[] { userId.ToString(), "tags" }, page, pageSize);
        }

        #endregion

        #region Answer Methods

        public void GetUsersAnswers(int userId, Action<List<Answer>> callback, QuestionsByUserSort sortBy = QuestionsByUserSort.Recent, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            MakeRequest<List<Answer>>("users", false, new string[] { userId.ToString(), "answers", sortBy.ToString().ToLower() }, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null
            }, callback);
        }

        #endregion

        #region Comment Methods

        public void GetComments(int fromUserId, Action<List<Comment>> callback, CommentSort sortBy = CommentSort.Recent, int? toUserId = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            string[] urlParameters = null;
            if (toUserId.HasValue)
            {
                urlParameters = new string[] { fromUserId.ToString(), "comments", toUserId.ToString(), sortBy.ToString().ToLower() };
            }
            else
            {
                urlParameters = new string[] { fromUserId.ToString(), "comments", sortBy.ToString().ToLower() };
            }

            MakeRequest<List<Comment>>("users", false, urlParameters, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, callback);
        }

        #endregion

        #region Stats Methods

        public void GetSiteStats(Action<SiteStats> callback)
        {
            MakeRequest<List<SiteStats>>("stats", false, null, new
            {
                key = Config.ApiKey
            }, results => callback(results.FirstOrDefault()));
        }

        #endregion

        #endregion
    }
}