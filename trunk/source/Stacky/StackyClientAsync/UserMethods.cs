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
        public void GetUsers(Action<IPagedList<User>> onSuccess, Action<ApiException> onError = null, UserSort sortBy = UserSort.Reputation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, string filter = null)
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

        public void GetUsers(IEnumerable<int> userIds, Action<IPagedList<User>> onSuccess, Action<ApiException> onError = null)
        {
            MakeRequest<UserResponse>("users", new string[] { userIds.Vectorize() }, new
            {
                key = apiKey
            }, (items) => onSuccess(new PagedList<User>(items.Users, items)), onError);
        }

        public void GetUser(int userId, Action<User> onSuccess, Action<ApiException> onError = null)
        {
            GetUsers(new int[] { userId }, results => onSuccess(results.FirstOrDefault()), onError);
        }

        public void GetUserMentions(int userId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null, UserMentionSort sortBy = UserMentionSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
        {
            GetUserMentions(new int[] { userId }, onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max);
        }

        public void GetUserMentions(IEnumerable<int> userIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null, UserMentionSort sortBy = UserMentionSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
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

        public void GetUserTimeline(int userId, Action<IPagedList<UserEvent>> onSuccess, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetUserTimeline(new int[] { userId }, onSuccess, onError, fromDate, toDate);
        }

        public void GetUserTimeline(IEnumerable<int> userIds, Action<IPagedList<UserEvent>> onSuccess, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<UserEventResponse>("users", new string[] { userIds.Vectorize(), "timeline" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, (items) => onSuccess(new PagedList<UserEvent>(items.Events, items)), onError);
        }

        public void GetUserReputation(int userId, Action<IPagedList<Reputation>> onSuccess, Action<ApiException> onError = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetUserReputation(new int[] { userId }, onSuccess, onError, page, pageSize, fromDate, toDate);
        }

        public void GetUserReputation(IEnumerable<int> userIds, Action<IPagedList<Reputation>> onSuccess, Action<ApiException> onError = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
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
    }
}