#if !SILVERLIGHT
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

        #region Question Methods

        public IList<Question> GetQuestions(QuestionSort sortBy = QuestionSort.Active, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            var sortArgs = sortBy.GetAttribute<SortArgsAttribute>();
            return GetQuestions("questions", sortArgs.Args, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetQuestionsByUser(int userId, QuestionsByUserSort sortBy = QuestionsByUserSort.Recent, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("users", new string[] { userId.ToString(), "questions", sortBy.ToString().ToLower() }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetFavoriteQuestions(int userId, FavoriteQuestionsSort sortBy = FavoriteQuestionsSort.Recent, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("users", new string[] { userId.ToString(), "favorites", sortBy.ToString().ToLower() }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        private IList<Question> GetQuestions(string method, string[] sort, int? page, int? pageSize, bool includeBody, bool includeComments, DateTime? fromDate, DateTime? toDate, params string[] tags)
        {
            return MakeRequest<List<Question>>(method, false, sort, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
                tagged = tags == null ? (string)null : String.Join(" ", tags)
            });
        }

        public Question GetQuestion(int id, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            return MakeRequest<List<Question>>("questions", false, new string[] { id.ToString() }, new
            {
                key = Config.ApiKey,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                page = page ?? null,
                pagesize = pageSize ?? null
            }).FirstOrDefault();
        }

        public IList<PostEvent> GetQuestionTimeline(int questionId, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return MakeRequest<List<PostEvent>>("questions", false, new string[] { questionId.ToString(), "timeline" }, new
            {
                key = Config.ApiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
        }

        #endregion

        #region User Methods

        public IList<User> GetUsers(UserSort sortBy = UserSort.Reputation, int? page = null, int? pageSize = null, string filter = null)
        {
            return MakeRequest<List<User>>("users", false, new string[] { sortBy.ToString().ToLower() }, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter
            });
        }

        public User GetUser(int userId)
        {
            return MakeRequest<List<User>>("users", false, new string[] { userId.ToString() }, new
            {
                key = Config.ApiKey
            }).FirstOrDefault();
        }

        public IList<Comment> GetUserMentions(int userId, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return MakeRequest<List<Comment>>("users", false, new string[] { userId.ToString(), "mentioned" }, new
            {
                key = Config.ApiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
        }

        public IList<UserEvent> GetUserTimeline(int userId, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return MakeRequest<List<UserEvent>>("users", false, new string[] { userId.ToString(), "timeline" }, new
            {
                key = Config.ApiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
        }

        public IList<Reputation> GetUserReputation(int userId, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return MakeRequest<List<Reputation>>("users", false, new string[] { userId.ToString(), "reputation" }, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
        }

        #endregion

        #region Badge Methods

        public IList<Badge> GetBadges(BadgeSort sortBy = BadgeSort.Name)
        {
            return GetBadges("badges", new string[] { sortBy.ToString().ToLower() });
        }

        private IList<Badge> GetBadges(string method, string[] sort)
        {
            return MakeRequest<List<Badge>>(method, false, sort, new
            {
                key = Config.ApiKey
            });
        }

        public IList<Badge> GetBadgesByUser(int userId)
        {
            return GetBadges("users", new string[] { userId.ToString(), "badges" });
        }

        #endregion

        #region Tag Methods

        public IList<Tag> GetTags(TagSort sortBy = TagSort.Popular, int? page = null, int? pageSize = null)
        {
            return GetTags("tags", new string[] { sortBy.ToString().ToLower() }, page, pageSize);
        }

        private IList<Tag> GetTags(string method, string[] urlParameters, int? page = null, int? pageSize = null)
        {
            return MakeRequest<List<Tag>>(method, false, urlParameters, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null
            });
        }

        public IList<Tag> GetTagsByUser(int userId, int? page = null, int? pageSize = null)
        {
            return GetTags("users", new string[] { userId.ToString(), "tags" }, page, pageSize);
        }

        #endregion

        #region Answer Methods

        public IList<Answer> GetUsersAnswers(int userId, QuestionsByUserSort sortBy = QuestionsByUserSort.Recent, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            return MakeRequest<List<Answer>>("users", false, new string[] { userId.ToString(), "answers", sortBy.ToString().ToLower() }, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null
            });
        }

        #endregion

        #region Comment Methods

        public IList<Comment> GetComments(int fromUserId, CommentSort sortBy = CommentSort.Recent, int? toUserId = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
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

            return MakeRequest<List<Comment>>("users", false, urlParameters, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
        }

        #endregion

        #region Stats Methods

        public SiteStats GetSiteStats()
        {
            return MakeRequest<List<SiteStats>>("stats", false, null, new
            {
                key = Config.ApiKey
            }).FirstOrDefault();
        }

        #endregion

        #endregion
    }
}
#endif