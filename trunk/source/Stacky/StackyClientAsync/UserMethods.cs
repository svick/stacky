using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        public virtual void GetUsers(Action<IPagedList<User>> onSuccess, Action<ApiException> onError = null, UserSort sortBy = UserSort.Reputation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<UserResponse>("users", null, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection)
            }, (items) => onSuccess(new PagedList<User>(items.Users, items)), onError);
        }

        public virtual void GetUsers(IEnumerable<int> userIds, Action<IPagedList<User>> onSuccess, Action<ApiException> onError = null)
        {
            MakeRequest<UserResponse>("users", new string[] { userIds.Vectorize() }, new
            {
                key = apiKey
            }, (items) => onSuccess(new PagedList<User>(items.Users, items)), onError);
        }

        public virtual void GetUser(int userId, Action<User> onSuccess, Action<ApiException> onError = null)
        {
            GetUsers(new int[] { userId }, results => onSuccess(results.FirstOrDefault()), onError);
        }

        public virtual void GetUserMentions(int userId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null, UserMentionSort sortBy = UserMentionSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
        {
            GetUserMentions(new int[] { userId }, onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max);
        }

        public virtual void GetUserMentions(IEnumerable<int> userIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null, UserMentionSort sortBy = UserMentionSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
        {
            MakeRequest<CommentResponse>("users", new string[] { userIds.Vectorize(), "mentioned" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
                page = page ?? null,
                pagesize = pageSize ?? null,
                min = min ?? null,
                max = max ?? null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection)
            }, (items) => onSuccess(new PagedList<Comment>(items.Comments, items)), onError);
        }

        public virtual void GetUserTimeline(int userId, Action<IPagedList<UserEvent>> onSuccess, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetUserTimeline(new int[] { userId }, onSuccess, onError, fromDate, toDate);
        }

        public virtual void GetUserTimeline(IEnumerable<int> userIds, Action<IPagedList<UserEvent>> onSuccess, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<UserEventResponse>("users", new string[] { userIds.Vectorize(), "timeline" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, (items) => onSuccess(new PagedList<UserEvent>(items.Events, items)), onError);
        }

        public virtual void GetUserReputation(int userId, Action<IPagedList<Reputation>> onSuccess, Action<ApiException> onError = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetUserReputation(new int[] { userId }, onSuccess, onError, page, pageSize, fromDate, toDate);
        }

        public virtual void GetUserReputation(IEnumerable<int> userIds, Action<IPagedList<Reputation>> onSuccess, Action<ApiException> onError = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<ReputationResponse>("users", new string[] { userIds.Vectorize(), "reputation" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, (items) => onSuccess(new PagedList<Reputation>(items.Reputation, items)), onError);
        }

        public virtual void GetModerators(Action<IPagedList<User>> onSuccess, Action<ApiException> onError, int? page = null, int? pageSize = null, UserSort sortBy = UserSort.Reputation, SortDirection sortDirection = SortDirection.Descending, string filter = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<UserResponse>("users", new string[] { "moderators" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection),
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, (response) => onSuccess(new PagedList<User>(response.Users, response)), onError);
        }
    }
}