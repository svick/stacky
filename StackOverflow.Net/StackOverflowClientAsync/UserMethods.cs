using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackOverflow
{
#if SILVERLIGHT
    public partial class StackOverflowClient
#else
    public partial class StackOverflowClientAsync
#endif
    {
        public void GetUsers(Action<IEnumerable<User>> callback, Action<ApiException> onError = null, UserSort sortBy = UserSort.Reputation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<UserResponse>("users", null, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection)
            }, (items) => callback(items.Users), onError);
        }

        public void GetUsers(IEnumerable<int> userIds, Action<IEnumerable<User>> callback, Action<ApiException> onError = null)
        {
            MakeRequest<List<User>>("users", new string[] { userIds.Vectorize() }, new
            {
                key = apiKey
            }, (items) => callback(items), onError);
        }

        public void GetUser(int userId, Action<User> callback, Action<ApiException> onError = null)
        {
            GetUsers(new int[] { userId }, results => callback(results.FirstOrDefault()), onError);
        }

        public void GetUserMentions(int userId, Action<IEnumerable<Comment>> callback, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetUserMentions(new int[] { userId }, callback, onError, fromDate, toDate);
        }

        public void GetUserMentions(IEnumerable<int> userIds, Action<IEnumerable<Comment>> callback, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<CommentResponse>("users", new string[] { userIds.Vectorize(), "mentioned" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, (items) => callback(items.Comments), onError);
        }

        public void GetUserTimeline(int userId, Action<IEnumerable<UserEvent>> callback, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetUserTimeline(new int[] { userId }, callback, onError, fromDate, toDate);
        }

        public void GetUserTimeline(IEnumerable<int> userIds, Action<IEnumerable<UserEvent>> callback, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<UserEventResponse>("users", new string[] { userIds.Vectorize(), "timeline" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, (items) => callback(items.Events), onError);
        }

        public void GetUserReputation(int userId, Action<IEnumerable<Reputation>> callback, Action<ApiException> onError = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetUserReputation(new int[] { userId }, callback, onError, page, pageSize, fromDate, toDate);
        }

        public void GetUserReputation(IEnumerable<int> userIds, Action<IEnumerable<Reputation>> callback, Action<ApiException> onError = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<ReputationResponse>("users", new string[] { userIds.Vectorize(), "reputation" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, (items) => callback(items.Reputation), onError);
        }
    }
}