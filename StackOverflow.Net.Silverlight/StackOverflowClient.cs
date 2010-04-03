using System;
using System.Collections.Generic;
using System.Globalization;

namespace StackOverflow.Net
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

        public void GetActiveQuestions(Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "questions", new string[] { "active" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetNewestQuestions(Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "questions", new string[] { "newest" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetFeaturedQuestions(Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "questions", new string[] { "featured" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetHotQuestions(Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "questions", new string[] { "hot" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetHotQuestionsForWeek(Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "questions", new string[] { "week" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetHotQuestionsForMonth(Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "questions", new string[] { "month" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetQuestionsByVotes(Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "questions", new string[] { "votes" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetUnansweredQuestions(Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "questions", new string[] { "unanswered" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetNewestQuestionsByVotes(Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "questions", new string[] { "unanswered", "votes" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetRecentQuestionsByUser(int userId, Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "users", new string[] { userId.ToString(), "questions", "recent" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetQuestionsByUserByViews(int userId, Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "users", new string[] { userId.ToString(), "questions", "views" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetNewestQuestionsByUser(int userId, Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "users", new string[] { userId.ToString(), "questions", "newest" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetQuestionsByUserByVotes(int userId, Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "users", new string[] { userId.ToString(), "questions", "votes" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }


        public void GetRecentFavoriteQuestionsByUser(int userId, Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "users", new string[] { userId.ToString(), "favorites", "recent" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetFavoriteQuestionsByUserByViews(int userId, Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "users", new string[] { userId.ToString(), "favorites", "views" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetFavoriteNewestQuestionsByUser(int userId, Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "users", new string[] { userId.ToString(), "favorites", "newest" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetFavoriteQuestionsByUserByVotes(int userId, Action<List<Question>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(callback, "users", new string[] { userId.ToString(), "favorites", "added" }, page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetQuestion(int id, Action<Question> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            MakeRequest<Question>("questions", false, new string[] { id.ToString() }, new
            {
                key = Config.ApiKey,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                page = page ?? null,
                pagesize = pageSize ?? null
            }, callback);
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

        private void GetUsers(Action<List<User>> callback, string sort, int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<List<User>>("users", false, new string[] { sort }, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter
            }, callback);
        }

        public void GetUsersByReputation(Action<List<User>> callback, int? page = null, int? pageSize = null, string filter = null)
        {
            GetUsers(callback, "reputation", page, pageSize, filter);
        }

        public void GetNewestUsers(Action<List<User>> callback, int? page = null, int? pageSize = null, string filter = null)
        {
            GetUsers(callback, "newest", page, pageSize, filter);
        }

        public void GetOldestUsers(Action<List<User>> callback, int? page = null, int? pageSize = null, string filter = null)
        {
            GetUsers(callback, "oldest", page, pageSize, filter);
        }

        public void GetUsersByName(Action<List<User>> callback, int? page = null, int? pageSize = null, string filter = null)
        {
            GetUsers(callback, "name", page, pageSize, filter);
        }

        public void GetUser(int userId, Action<User> callback)
        {
            MakeRequest<User>("users", false, new string[] { userId.ToString() }, new
            {
                key = Config.ApiKey
            }, callback);
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

        private void GetBadges(Action<List<Badge>> callback, string method, string[] sort)
        {
            MakeRequest<List<Badge>>(method, false, sort, new
            {
                key = Config.ApiKey
            }, callback);
        }

        public void GetBadgesByName(Action<List<Badge>> callback)
        {
            GetBadges(callback, "badges", new string[] { "name" });
        }

        public void GetBadgesByTag(Action<List<Badge>> callback)
        {
            GetBadges(callback, "badges", new string[] { "tags" });
        }

        public void GetBadgesByUser(int userId, Action<List<Badge>> callback)
        {
            GetBadges(callback, "users", new string[] { userId.ToString(), "badges" });
        }

        #endregion

        #region Tag Methods

        private void GetTags(Action<List<Tag>> callback, string method, string[] urlParameters, int? page = null, int? pageSize = null)
        {
            MakeRequest<List<Tag>>(method, false, urlParameters, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null
            }, callback);
        }

        public void GetPopularTags(Action<List<Tag>> callback, int? page = null, int? pageSize = null)
        {
            GetTags(callback, "tags", new string[] { "popular" }, page, pageSize);
        }

        public void GetTagsByName(Action<List<Tag>> callback, int? page = null, int? pageSize = null)
        {
            GetTags(callback, "tags", new string[] { "name" }, page, pageSize);
        }

        public void GetRecentTags(Action<List<Tag>> callback, int? page = null, int? pageSize = null)
        {
            GetTags(callback, "tags", new string[] { "recent" }, page, pageSize);
        }

        public void GetTagsByUser(int userId, Action<List<Tag>> callback, int? page = null, int? pageSize = null)
        {
            GetTags(callback, "users", new string[] { userId.ToString(), "tags" }, page, pageSize);
        }

        #endregion

        #region Answer Methods

        private void GetAnswers(Action<List<Answer>> callback, string method, string[] urlParameters, int? page, int? pageSize, bool includeBody, bool includeComments)
        {
            MakeRequest<List<Answer>>(method, false, urlParameters, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null
            }, callback);
        }

        public void GetUsersRecentAnswers(int userId, Action<List<Answer>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            GetAnswers(callback, "users", new string[] { userId.ToString(), "answers", "recent" }, page, pageSize, includeBody, includeComments);
        }

        public void GetUsersAnswersByViews(int userId, Action<List<Answer>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            GetAnswers(callback, "users", new string[] { userId.ToString(), "answers", "views" }, page, pageSize, includeBody, includeComments);
        }

        public void GetUsersNewestAnswers(int userId, Action<List<Answer>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            GetAnswers(callback, "users", new string[] { userId.ToString(), "answers", "newest" }, page, pageSize, includeBody, includeComments);
        }

        public void GetUsersAnswersByVotes(int userId, Action<List<Answer>> callback, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            GetAnswers(callback, "users", new string[] { userId.ToString(), "answers", "votes" }, page, pageSize, includeBody, includeComments);
        }

        #endregion

        #region Comment Methods

        private void GetComments(Action<List<Comment>> callback, string method, string[] urlParameters, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<List<Comment>>(method, false, urlParameters, new
            {
                key = Config.ApiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, callback);
        }

        public void GetUsersRecentComments(int userId, Action<List<Comment>> callback, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetComments(callback, "users", new string[] { userId.ToString(), "comments", "recent" }, page, pageSize, fromDate, toDate);
        }

        public void GetUsersCommentsByScore(int userId, Action<List<Comment>> callback, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetComments(callback, "users", new string[] { userId.ToString(), "comments", "score" }, page, pageSize, fromDate, toDate);
        }

        public void GetUsersRecentsCommentsTo(int fromUserId, int toUserId, Action<List<Comment>> callback, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetComments(callback, "users", new string[] { fromUserId.ToString(), "comments", toUserId.ToString(), "recent" }, page, pageSize, fromDate, toDate);
        }

        public void GetUsersCommentsToByScore(int fromUserId, int toUserId, Action<List<Comment>> callback, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetComments(callback, "users", new string[] { fromUserId.ToString(), "comments", toUserId.ToString(), "score" }, page, pageSize, fromDate, toDate);
        }

        #endregion

        #region Stats Methods

        public void GetSiteStats(Action<SiteStats> callback)
        {
            MakeRequest<SiteStats>("stats", false, null, new
            {
                key = Config.ApiKey
            }, callback);
        }

        #endregion

        #endregion
    }
}