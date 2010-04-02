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

        public IList<Question> GetActiveQuestions(int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("questions", new string[] { "active" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetNewestQuestions(int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("questions", new string[] { "newest" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetFeaturedQuestions(int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("questions", new string[] { "featured" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetHotQuestions(int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("questions", new string[] { "hot" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetHotQuestionsForWeek(int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("questions", new string[] { "week" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetHotQuestionsForMonth(int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("questions", new string[] { "month" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetQuestionsByVotes(int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("questions", new string[] { "votes" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetUnansweredQuestions(int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("questions", new string[] { "unanswered" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetNewestQuestionsByVotes(int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("questions", new string[] { "unanswered", "votes" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetRecentQuestionsByUser(int userId, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("users", new string[] { userId.ToString(), "questions", "recent" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetQuestionsByUserByViews(int userId, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("users", new string[] { userId.ToString(), "questions", "views" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetNewestQuestionsByUser(int userId, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("users", new string[] { userId.ToString(), "questions", "newest" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetQuestionsByUserByVotes(int userId, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("users", new string[] { userId.ToString(), "questions", "votes" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }


        public IList<Question> GetRecentFavoriteQuestionsByUser(int userId, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("users", new string[] { userId.ToString(), "favorites", "recent" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetFavoriteQuestionsByUserByViews(int userId, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("users", new string[] { userId.ToString(), "favorites", "views" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetFavoriteNewestQuestionsByUser(int userId, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("users", new string[] { userId.ToString(), "favorites", "newest" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public IList<Question> GetFavoriteQuestionsByUserByVotes(int userId, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return GetQuestions("users", new string[] { userId.ToString(), "favorites", "added" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public Question GetQuestion(int id, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            return MakeRequest<Question>("questions", false, new string[] { id.ToString() }, new
            {
                key = Config.ApiKey,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                page = page ?? null,
                pagesize = pageSize ?? null
            });
        }

        #endregion

        #region User Methods

        private IList<User> GetUsers(string sort, int? page = null, int? pageSize = null, string filter = null)
        {
            return MakeRequest<List<User>>("users", false, new string[] { sort }, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter
            });
        }

        public IList<User> GetUsersByReputation(int? page = null, int? pageSize = null, string filter = null)
        {
            return GetUsers("reputation", page, pageSize, filter);
        }

        public IList<User> GetNewestUsers(int? page = null, int? pageSize = null, string filter = null)
        {
            return GetUsers("newest", page, pageSize, filter);
        }

        public IList<User> GetOldestUsers(int? page = null, int? pageSize = null, string filter = null)
        {
            return GetUsers("oldest", page, pageSize, filter);
        }

        public IList<User> GetUsersByName(int? page = null, int? pageSize = null, string filter = null)
        {
            return GetUsers("name", page, pageSize, filter);
        }

        public User GetUser(int userId)
        {
            return MakeRequest<User>("users", false, new string[] { userId.ToString() }, new
            {
                key = Config.ApiKey
            });
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

        #endregion

        #region Badge Methods

        private IList<Badge> GetBadges(string method, string[] sort)
        {
            return MakeRequest<List<Badge>>(method, false, sort, new
            {
                key = Config.ApiKey
            });
        }

        public IList<Badge> GetBadgesByName()
        {
            return GetBadges("badges", new string[] { "name" });
        }

        public IList<Badge> GetBadgesByTag()
        {
            return GetBadges("badges", new string[] { "tags" });
        }

        public IList<Badge> GetBadgesByUser(int userId)
        {
            return GetBadges("users", new string[] { userId.ToString(), "badges" });
        }

        #endregion

        #region Tag Methods

        private IList<Tag> GetTags(string method, string[] urlParameters, int? page = null, int? pageSize = null)
        {
            return MakeRequest<List<Tag>>(method, false, urlParameters, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null
            });
        }

        public IList<Tag> GetPopularTags(int? page = null, int? pageSize = null)
        {
            return GetTags("tags", new string[] { "popular" }, page, pageSize);
        }

        public IList<Tag> GetTagsByName(int? page = null, int? pageSize = null)
        {
            return GetTags("tags", new string[] { "name" }, page, pageSize);
        }

        public IList<Tag> GetRecentTags(int? page = null, int? pageSize = null)
        {
            return GetTags("tags", new string[] { "recent" }, page, pageSize);
        }

        public IList<Tag> GetTagsByUser(int userId, int? page = null, int? pageSize = null)
        {
            return GetTags("users", new string[] { userId.ToString(), "tags" }, page, pageSize);
        }

        #endregion

        #region Answer Methods

        private IList<Answer> GetAnswers(string method, string[] urlParameters, int? page, int? pageSize, bool includeBody, bool includeComments)
        {
            return MakeRequest<List<Answer>>(method, false, urlParameters, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null
            });
        }

        public IList<Answer> GetUsersRecentAnswers(int userId, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            return GetAnswers("users", new string[] { userId.ToString(), "answers", "recent" }, page, pageSize, includeBody, includeComments);
        }

        public IList<Answer> GetUsersAnswersByViews(int userId, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            return GetAnswers("users", new string[] { userId.ToString(), "answers", "views" }, page, pageSize, includeBody, includeComments);
        }

        public IList<Answer> GetUsersNewestAnswers(int userId, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            return GetAnswers("users", new string[] { userId.ToString(), "answers", "newest" }, page, pageSize, includeBody, includeComments);
        }

        public IList<Answer> GetUsersAnswersByVotes(int userId, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            return GetAnswers("users", new string[] { userId.ToString(), "answers", "votes" }, page, pageSize, includeBody, includeComments);
        }

        #endregion

        #region Comment Methods

        private IList<Comment> GetComments(string method, string[] urlParameters, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return MakeRequest<List<Comment>>(method, false, urlParameters, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
        }

        public IList<Comment> GetUsersRecentComments(int userId, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetComments("users", new string[] { userId.ToString(), "comments", "recent" }, page, pageSize, fromDate, toDate);
        }

        public IList<Comment> GetUsersCommentsByScore(int userId, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetComments("users", new string[] { userId.ToString(), "comments", "score" }, page, pageSize, fromDate, toDate);
        }

        public IList<Comment> GetUsersRecentsCommentsTo(int fromUserId, int toUserId, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetComments("users", new string[] { fromUserId.ToString(), "comments", toUserId.ToString(), "recent" }, page, pageSize, fromDate, toDate);
        }

        public IList<Comment> GetUsersCommentsToByScore(int fromUserId, int toUserId, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetComments("users", new string[] { fromUserId.ToString(), "comments", toUserId.ToString(), "score" }, page, pageSize, fromDate, toDate);
        }

        #endregion

        #region Stats Methods

        public SiteStats GetSiteStats()
        {
            return MakeRequest<SiteStats>("stats", false, null, new
            {
                key = Config.ApiKey
            });
        }

        #endregion

        #endregion
    }
}