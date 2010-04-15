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

        public User GetUser(int userId)
        {
            return MakeRequest<List<User>>("users", false, new string[] { userId.ToString() }, new
            {
                key = apiKey
            }).FirstOrDefault();
        }

        public IList<Comment> GetUserMentions(int userId, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return MakeRequest<List<Comment>>("users", false, new string[] { userId.ToString(), "mentioned" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
        }

        public IList<UserEvent> GetUserTimeline(int userId, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return MakeRequest<List<UserEvent>>("users", false, new string[] { userId.ToString(), "timeline" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
        }

        public IList<Reputation> GetUserReputation(int userId, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return MakeRequest<List<Reputation>>("users", false, new string[] { userId.ToString(), "reputation" }, new
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