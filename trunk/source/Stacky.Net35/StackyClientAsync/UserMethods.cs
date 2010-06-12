using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        private void GetUsers(Action<IPagedList<User>> onSuccess, Action<ApiException> onError, string[] urlParameters, UserOptions options)
        {
            MakeRequest<UserResponse>("users", urlParameters, new
            {
                key = apiKey,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter,
                sort = options.SortBy.ToString().ToLower(),
                order = GetSortDirection(options.SortDirection),
                fromdate = options.FromDate.HasValue ? (long?)options.FromDate.Value.ToUnixTime() : null,
                todate = options.ToDate.HasValue ? (long?)options.ToDate.Value.ToUnixTime() : null,
                min = options.Min ?? null,
                max = options.Max ?? null
            }, (items) => onSuccess(new PagedList<User>(items.Users, items)), onError);
        }

        public void GetUsers(Action<IPagedList<User>> onSuccess, Action<ApiException> onError)
        {
            GetUsers(onSuccess, onError, new UserOptions());
        }

        public void GetUsers(Action<IPagedList<User>> onSuccess, Action<ApiException> onError, UserOptions options)
        {
            GetUsers(onSuccess, onError, null, options);
        }

        public void GetUsers(IEnumerable<int> userIds, Action<IPagedList<User>> onSuccess, Action<ApiException> onError)
        {
            GetUsers(userIds, onSuccess, onError, new UserOptions());
        }

        public void GetUsers(IEnumerable<int> userIds, Action<IPagedList<User>> onSuccess, Action<ApiException> onError, UserOptions options)
        {
            GetUsers(onSuccess, onError, new string[] { userIds.Vectorize() }, options);
        }

        public void GetUser(int userId, Action<User> onSuccess, Action<ApiException> onError)
        {
            GetUsers(new int[] { userId }, results => onSuccess(results.FirstOrDefault()), onError, new UserOptions());
        }

        public void GetUserMentions(int userId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError)
        {
            GetUserMentions(userId, onSuccess, onError, new UserOptions());
        }

        public void GetUserMentions(int userId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, UserOptions options)
        {
            GetUserMentions(new int[] { userId }, onSuccess, onError, options);
        }

        public void GetUserMentions(IEnumerable<int> userIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError)
        {
            GetUserMentions(userIds, onSuccess, onError, new UserOptions());
        }

        public void GetUserMentions(IEnumerable<int> userIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, UserOptions options)
        {
            MakeRequest<CommentResponse>("users", new string[] { userIds.Vectorize(), "mentioned" }, new
            {
                key = apiKey,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                filter = options.Filter,
                sort = options.SortBy.ToString().ToLower(),
                order = GetSortDirection(options.SortDirection),
                fromdate = options.FromDate.HasValue ? (long?)options.FromDate.Value.ToUnixTime() : null,
                todate = options.ToDate.HasValue ? (long?)options.ToDate.Value.ToUnixTime() : null,
                min = options.Min ?? null,
                max = options.Max ?? null
            }, (items) => onSuccess(new PagedList<Comment>(items.Comments, items)), onError);
        }

        public void GetUserTimeline(int userId, Action<IPagedList<UserEvent>> onSuccess, Action<ApiException> onError)
        {
            GetUserTimeline(userId, onSuccess, onError, new UserTimelineOptions());
        }

        public void GetUserTimeline(int userId, Action<IPagedList<UserEvent>> onSuccess, Action<ApiException> onError, UserTimelineOptions options)
        {
            GetUserTimeline(new int[] { userId }, onSuccess, onError, options);
        }

        public void GetUserTimeline(IEnumerable<int> userIds, Action<IPagedList<UserEvent>> onSuccess, Action<ApiException> onError)
        {
            GetUserTimeline(userIds, onSuccess, onError, new UserTimelineOptions());
        }

        public void GetUserTimeline(IEnumerable<int> userIds, Action<IPagedList<UserEvent>> onSuccess, Action<ApiException> onError, UserTimelineOptions options)
        {
            MakeRequest<UserEventResponse>("users", new string[] { userIds.Vectorize(), "timeline" }, new
            {
                key = apiKey,
                fromdate = options.FromDate.HasValue ? (long?)options.FromDate.Value.ToUnixTime() : null,
                todate = options.ToDate.HasValue ? (long?)options.ToDate.Value.ToUnixTime() : null,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null
            }, (items) => onSuccess(new PagedList<UserEvent>(items.Events, items)), onError);
        }

        public void GetUserReputation(int userId, Action<IPagedList<Reputation>> onSuccess, Action<ApiException> onError)
        {
            GetUserReputation(userId, onSuccess, onError, new ReputationOptions());
        }

        public void GetUserReputation(int userId, Action<IPagedList<Reputation>> onSuccess, Action<ApiException> onError, ReputationOptions options)
        {
            GetUserReputation(new int[] { userId }, onSuccess, onError, options);
        }

        public void GetUserReputation(IEnumerable<int> userIds, Action<IPagedList<Reputation>> onSuccess, Action<ApiException> onError)
        {
            GetUserReputation(userIds, onSuccess, onError, new ReputationOptions());
        }

        public void GetUserReputation(IEnumerable<int> userIds, Action<IPagedList<Reputation>> onSuccess, Action<ApiException> onError, ReputationOptions options)
        {
            MakeRequest<ReputationResponse>("users", new string[] { userIds.Vectorize(), "reputation" }, new
            {
                key = apiKey,
                fromdate = options.FromDate.HasValue ? (long?)options.FromDate.Value.ToUnixTime() : null,
                todate = options.ToDate.HasValue ? (long?)options.ToDate.Value.ToUnixTime() : null,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null
            }, (items) => onSuccess(new PagedList<Reputation>(items.Reputation, items)), onError);
        }
    }
}