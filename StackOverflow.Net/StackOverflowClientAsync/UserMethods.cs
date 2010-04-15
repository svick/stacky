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
        public void GetUsers(Action<List<User>> callback, Action<ApiException> onError = null, UserSort sortBy = UserSort.Reputation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, string filter = null)
        {
            MakeRequest<List<User>>("users", false, null, new
            {
                key = apiKey,
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
                key = apiKey
            }, results => callback(results.FirstOrDefault()), onError);
        }

        public void GetUserMentions(int userId, Action<List<Comment>> callback, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<List<Comment>>("users", false, new string[] { userId.ToString(), "mentioned" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, callback, onError);
        }

        public void GetUserTimeline(int userId, Action<List<UserEvent>> callback, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<List<UserEvent>>("users", false, new string[] { userId.ToString(), "timeline" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, callback, onError);
        }

        public void GetUserReputation(int userId, Action<List<Reputation>> callback, Action<ApiException> onError = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<List<Reputation>>("users", false, new string[] { userId.ToString(), "reputation" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, callback, onError);
        }
    }
}