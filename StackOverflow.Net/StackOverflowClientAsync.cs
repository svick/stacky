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

        private void MakeRequest<T>(string method, bool secure, string[] urlArguments, object queryStringArguments, Action<T> callback, Action<ApiException> onError)
            where T : new()
        {
            MakeRequest<T>(method, secure, urlArguments, UrlHelper.ObjectToDictionary(queryStringArguments), callback, onError);
        }

        private void MakeRequest<T>(string method, bool secure, string[] urlArguments, Dictionary<string, string> queryStringArguments, Action<T> callback, Action<ApiException> onError)
             where T : new()
        {
            try
            {
                GetResponse(method, secure, urlArguments, queryStringArguments, response =>
                {
                    IResponse<T> r = protocol.GetResponse<T>(response.Body);
                    if (response.Error != null)
                    {
                        if(onError != null)
                            onError(new ApiException(r.Error.ErrorCode));
                        return;
                    }
                    else
                    {
                        callback(r.Data);
                    }
                }, onError);
            }
            catch (Exception e)
            {
                onError(new ApiException(Int32.MinValue, e));
            }
        }

        private void GetResponse(string method, bool secure, string[] urlArguments, Dictionary<string, string> queryStringArguments, Action<HttpResponse> callback, Action<ApiException> onError)
        {
            Uri url = UrlHelper.BuildUrl(method, secure, ServiceUrl, urlArguments, queryStringArguments);
            client.MakeRequest(url, callback, onError);
        }

        private string GetSortDirection(SortDirection direction)
        {
            return direction == SortDirection.Ascending ? "asc" : "desc";
        }

        #endregion

        #region API Methods

        #region Question Methods

        public void GetQuestions(Action<List<Question>> callback, Action<ApiException> onError = null, QuestionSort sortBy = QuestionSort.Active, SortDirection sortDirection = SortDirection.Ascending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            var sortArgs = sortBy.GetAttribute<SortArgsAttribute>();
            GetQuestions(callback, onError, "questions", sortArgs.UrlArgs, sortArgs.Sort, GetSortDirection(sortDirection), page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetQuestionsByUser(int userId, Action<List<Question>> callback, Action<ApiException> onError = null, QuestionsByUserSort sortBy = QuestionsByUserSort.Creation, SortDirection sortDirection = SortDirection.Ascending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, onError, "users", new string[] { userId.ToString(), "questions" }, sortBy.ToString().ToLower(), GetSortDirection(sortDirection), page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetFavoriteQuestions(int userId, Action<List<Question>> callback, Action<ApiException> onError = null, FavoriteQuestionsSort sortBy = FavoriteQuestionsSort.Recent, SortDirection sortDirection = SortDirection.Ascending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, onError, "users", new string[] { userId.ToString(), "favorites" }, sortBy.ToString().ToLower(), GetSortDirection(sortDirection), page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        private void GetQuestions(Action<List<Question>> callback, Action<ApiException> onError, string method, string[] urlArgs, string sort, string order, int? page, int? pageSize, bool includeBody, bool includeComments, DateTime? fromDate, DateTime? toDate, params string[] tags)
        {
            MakeRequest<List<Question>>(method, false, urlArgs, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
                tagged = tags == null ? (string)null : String.Join(" ", tags),
                sort = sort,
                order = order
            }, callback, onError);
        }

        public void GetQuestion(int id, Action<Question> callback, Action<ApiException> onError = null, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            MakeRequest<List<Question>>("questions", false, new string[] { id.ToString() }, new
            {
                key = Config.ApiKey,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                page = page ?? null,
                pagesize = pageSize ?? null
            }, returnedQuestions => callback(returnedQuestions.FirstOrDefault()), onError);
        }

        public void GetQuestionTimeline(int questionId, Action<List<PostEvent>> callback, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<List<PostEvent>>("questions", false, new string[] { questionId.ToString(), "timeline" }, new
            {
                key = Config.ApiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, callback, onError);
        }

        #endregion

        #region User Methods

        public void GetUsers(Action<List<User>> callback, Action<ApiException> onError = null, UserSort sortBy = UserSort.Reputation, SortDirection sortDirection = SortDirection.Ascending, int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<List<User>>("users", false, null, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection)
            }, callback, onError);
        }

        public void GetUser(int userId, Action<User> callback, Action<ApiException> onError = null)
        {
            MakeRequest<List<User>>("users", false, new string[] { userId.ToString() }, new
            {
                key = Config.ApiKey
            }, results => callback(results.FirstOrDefault()), onError);
        }

        public void GetUserMentions(int userId, Action<List<Comment>> callback, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<List<Comment>>("users", false, new string[] { userId.ToString(), "mentioned" }, new
            {
                key = Config.ApiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, callback, onError);
        }

        public void GetUserTimeline(int userId, Action<List<UserEvent>> callback, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<List<UserEvent>>("users", false, new string[] { userId.ToString(), "timeline" }, new
            {
                key = Config.ApiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, callback, onError);
        }

        public void GetUserReputation(int userId, Action<List<Reputation>> callback, Action<ApiException> onError = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<List<Reputation>>("users", false, new string[] { userId.ToString(), "reputation" }, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, callback, onError);
        }

        #endregion

        #region Badge Methods

        public void GetBadges(Action<List<Badge>> callback, Action<ApiException> onError = null, BadgeSort sortBy = BadgeSort.Name)
        {
            GetBadges(callback, onError, "badges", new string[] { sortBy.ToString().ToLower() });
        }

        private void GetBadges(Action<List<Badge>> callback, Action<ApiException> onError, string method, string[] sort)
        {
            MakeRequest<List<Badge>>(method, false, sort, new
            {
                key = Config.ApiKey
            }, callback, onError);
        }

        public void GetBadgesByUser(int userId, Action<List<Badge>> callback, Action<ApiException> onError = null)
        {
            GetBadges(callback, onError, "users", new string[] { userId.ToString(), "badges" });
        }

        #endregion

        #region Tag Methods

        public void GetTags(Action<List<Tag>> callback, Action<ApiException> onError = null, TagSort sortBy = TagSort.Popular, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null)
        {
            GetTags(callback, onError, "tags", null, sortBy.ToString().ToLower(), GetSortDirection(sortDirection), page, pageSize);
        }

        private void GetTags(Action<List<Tag>> callback, Action<ApiException> onError, string method, string[] urlParameters, string sort, string order, int? page = null, int? pageSize = null)
        {
            MakeRequest<List<Tag>>(method, false, urlParameters, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                sort = sort,
                order = order
            }, callback, onError);
        }

        public void GetTagsByUser(int userId, Action<List<Tag>> callback, Action<ApiException> onError = null, int? page = null, int? pageSize = null)
        {
            //TODO: does this method support sort and order?
            GetTags(callback, onError, "users", new string[] { userId.ToString(), "tags" }, null, null, page, pageSize);
        }

        #endregion

        #region Answer Methods

        public void GetUsersAnswers(int userId, Action<List<Answer>> callback, Action<ApiException> onError = null, QuestionsByUserSort sortBy = QuestionsByUserSort.Creation, SortDirection sortDirection = SortDirection.Ascending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            MakeRequest<List<Answer>>("users", false, new string[] { userId.ToString(), "answers" }, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection)
            }, callback, onError);
        }

        #endregion

        #region Comment Methods

        public void GetComments(int fromUserId, Action<List<Comment>> callback, Action<ApiException> onError = null, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Ascending, int? toUserId = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            string[] urlParameters = null;
            if (toUserId.HasValue)
            {
                urlParameters = new string[] { fromUserId.ToString(), "comments", toUserId.ToString() };
            }
            else
            {
                urlParameters = new string[] { fromUserId.ToString(), "comments" };
            }

            MakeRequest<List<Comment>>("users", false, urlParameters, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection)
            }, callback, onError);
        }

        #endregion

        #region Stats Methods

        public void GetSiteStats(Action<SiteStats> callback, Action<ApiException> onError = null)
        {
            MakeRequest<List<SiteStats>>("stats", false, null, new
            {
                key = Config.ApiKey
            }, results => callback(results.FirstOrDefault()), onError);
        }

        #endregion

        #endregion
    }
}