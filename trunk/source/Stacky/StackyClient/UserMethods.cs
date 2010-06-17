using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IPagedList<User> GetUsers(UserSort sortBy = UserSort.Reputation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, string filter = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
        {
            var response = MakeRequest<UserResponse>("users", null, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection),
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
                min = min ?? null,
                max = max ?? null
            });
            return new PagedList<User>(response.Users, response);
        }

        public virtual IPagedList<User> GetUsers(IEnumerable<int> userIds, UserSort sortBy = UserSort.Reputation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, string filter = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
        {
           var response = MakeRequest<UserResponse>("users", new string[] { userIds.Vectorize() }, new
           {
               key = apiKey,
               page = page ?? null,
               pagesize = pageSize ?? null,
               filter = filter,
               sort = sortBy.ToString().ToLower(),
               order = GetSortDirection(sortDirection),
               fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
               todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
               min = min ?? null,
               max = max ?? null
           });
           return new PagedList<User>(response.Users, response);
        }

        public virtual User GetUser(int userId)
        {
            return GetUsers(userId.ToArray()).FirstOrDefault();
        }

        public virtual IPagedList<Comment> GetUserMentions(int userId, UserMentionSort sortBy = UserMentionSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
        {
            return GetUserMentions(userId.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max);
        }

        public virtual IPagedList<Comment> GetUserMentions(IEnumerable<int> userIds, UserMentionSort sortBy = UserMentionSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
        {
            var response = MakeRequest<CommentResponse>("users", new string[] { userIds.Vectorize(), "mentioned" }, new
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
            });
            return new PagedList<Comment>(response.Comments, response);
        }

        public virtual IPagedList<UserEvent> GetUserTimeline(int userId, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetUserTimeline(userId.ToArray(), page, pageSize, fromDate, toDate);
        }

        public virtual IPagedList<UserEvent> GetUserTimeline(IEnumerable<int> userIds, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var response = MakeRequest<UserEventResponse>("users", new string[] { userIds.Vectorize(), "timeline" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
                page = page ?? null,
                pagesize = pageSize ?? null
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

        public virtual IEnumerable<Badge> GetUserBadges(int userId)
        {
            return GetUserBadges(userId.ToArray());
        }

        public virtual IEnumerable<Badge> GetUserBadges(IEnumerable<int> userIds)
        {
            return MakeRequest<BadgeResponse>("users", new string[] { userIds.Vectorize() }, new
            {
                key = apiKey
            }).Badges;
        }

        public virtual IPagedList<User> GetModerators(int? page = null, int? pageSize = null, UserSort sortBy = UserSort.Reputation, SortDirection sortDirection = SortDirection.Descending, string filter = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var response = MakeRequest<UserResponse>("users", new string[] { "moderators" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                filter = filter,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection),
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
            return new PagedList<User>(response.Users, response);
        }
    }
}