using System;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflow
{
    public partial class StackOverflowClient
    {
        public IList<User> GetUsers(UserSort sortBy = UserSort.Reputation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, string filter = null)
        {
            return MakeRequest<List<User>>("users", false, null, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection)
            });
        }

        public IList<User> GetUsers(IEnumerable<int> userIds)
        {
           return MakeRequest<List<User>>("users", false, new string[] { userIds.Vectorize() }, new
           {
               key = apiKey
           });
        }

        public User GetUser(int userId)
        {
            return GetUsers(userId.ToArray()).FirstOrDefault();
        }

        public IList<Comment> GetUserMentions(int userId, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetUserMentions(userId.ToArray(), fromDate, toDate);
        }

        public IList<Comment> GetUserMentions(IEnumerable<int> userIds, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return MakeRequest<List<Comment>>("users", false, new string[] { userIds.Vectorize(), "mentioned" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
        }

        public IList<UserEvent> GetUserTimeline(int userId, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetUserTimeline(userId.ToArray(), fromDate, toDate);
        }

        public IList<UserEvent> GetUserTimeline(IEnumerable<int> userIds, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return MakeRequest<List<UserEvent>>("users", false, new string[] { userIds.Vectorize(), "timeline" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
        }

        public IList<Reputation> GetUserReputation(int userId, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetUserReputation(userId.ToArray(), page, pageSize, fromDate, toDate);
        }

        public IList<Reputation> GetUserReputation(IEnumerable<int> userIds, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return MakeRequest<List<Reputation>>("users", false, new string[] { userIds.Vectorize(), "reputation" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
        }
    }
}