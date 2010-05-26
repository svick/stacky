using System;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflow
{
    public partial class StackOverflowClient
    {
        public virtual IPagedList<User> GetUsers(UserSort sortBy = UserSort.Reputation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, string filter = null)
        {
            var response = MakeRequest<UserResponse>("users", null, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection)
            });
            return new PagedList<User>(response.Users, response);
        }

        public virtual IPagedList<User> GetUsers(IEnumerable<int> userIds)
        {
           var response = MakeRequest<UserResponse>("users", new string[] { userIds.Vectorize() }, new
           {
               key = apiKey
           });
           return new PagedList<User>(response.Users, response);
        }

        public virtual User GetUser(int userId)
        {
            return GetUsers(userId.ToArray()).FirstOrDefault();
        }

        public virtual IPagedList<Comment> GetUserMentions(int userId, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetUserMentions(userId.ToArray(), fromDate, toDate);
        }

        public virtual IPagedList<Comment> GetUserMentions(IEnumerable<int> userIds, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var response = MakeRequest<CommentResponse>("users", new string[] { userIds.Vectorize(), "mentioned" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
            return new PagedList<Comment>(response.Comments, response);
        }

        public virtual IPagedList<UserEvent> GetUserTimeline(int userId, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetUserTimeline(userId.ToArray(), fromDate, toDate);
        }

        public virtual IPagedList<UserEvent> GetUserTimeline(IEnumerable<int> userIds, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var response = MakeRequest<UserEventResponse>("users", new string[] { userIds.Vectorize(), "timeline" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
            return new PagedList<UserEvent>(response.Events, response);
        }

        public virtual IPagedList<Reputation> GetUserReputation(int userId, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetUserReputation(userId.ToArray(), page, pageSize, fromDate, toDate);
        }

        public virtual IPagedList<Reputation> GetUserReputation(IEnumerable<int> userIds, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var response = MakeRequest<ReputationResponse>("users", new string[] { userIds.Vectorize(), "reputation" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
            return new PagedList<Reputation>(response.Reputation, response);
        }
    }
}