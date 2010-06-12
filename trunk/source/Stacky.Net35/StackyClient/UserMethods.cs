using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IPagedList<User> GetUsers()
        {
            return GetUsers(new UserOptions());
        }

        public virtual IPagedList<User> GetUsers(UserOptions options)
        {
            return GetUsers(options, null);
        }

        public virtual IPagedList<User> GetUsers(IEnumerable<int> userIds)
        {
            return GetUsers(userIds, new UserOptions());
        }

        public virtual IPagedList<User> GetUsers(IEnumerable<int> userIds, UserOptions options)
        {
            return GetUsers(options, new string[] { userIds.Vectorize() });
        }

        private IPagedList<User> GetUsers(UserOptions options, string[] urlParameters)
        {
            var response = MakeRequest<UserResponse>("users", urlParameters, new
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
            });
            return new PagedList<User>(response.Users, response);
        }

        public virtual User GetUser(int userId)
        {
            return GetUsers(userId.ToArray()).FirstOrDefault();
        }

        public virtual IPagedList<Comment> GetUserMentions(int userId)
        {
            return GetUserMentions(userId, new UserMentionsOptions());
        }

        public virtual IPagedList<Comment> GetUserMentions(int userId, UserMentionsOptions options)
        {
            return GetUserMentions(userId.ToArray(), options);
        }

        public virtual IPagedList<Comment> GetUserMentions(IEnumerable<int> userIds)
        {
            return GetUserMentions(userIds, new UserMentionsOptions());
        }

        public virtual IPagedList<Comment> GetUserMentions(IEnumerable<int> userIds, UserMentionsOptions options)
        {
            var response = MakeRequest<CommentResponse>("users", new string[] { userIds.Vectorize(), "mentioned" }, new
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
            });
            return new PagedList<Comment>(response.Comments, response);
        }

        public virtual IPagedList<UserEvent> GetUserTimeline(int userId)
        {
            return GetUserTimeline(userId, new UserTimelineOptions());
        }

        public virtual IPagedList<UserEvent> GetUserTimeline(int userId, UserTimelineOptions options)
        {
            return GetUserTimeline(userId.ToArray(), options);
        }

        public virtual IPagedList<UserEvent> GetUserTimeline(IEnumerable<int> userIds)
        {
            return GetUserTimeline(userIds, new UserTimelineOptions());
        }

        public virtual IPagedList<UserEvent> GetUserTimeline(IEnumerable<int> userIds, UserTimelineOptions options)
        {
            var response = MakeRequest<UserEventResponse>("users", new string[] { userIds.Vectorize(), "timeline" }, new
            {
                key = apiKey,
                fromdate = options.FromDate.HasValue ? (long?)options.FromDate.Value.ToUnixTime() : null,
                todate = options.ToDate.HasValue ? (long?)options.ToDate.Value.ToUnixTime() : null,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null
            });
            return new PagedList<UserEvent>(response.Events, response);
        }

        public virtual IPagedList<Reputation> GetUserReputation(int userId)
        {
            return GetUserReputation(userId, new ReputationOptions());
        }

        public virtual IPagedList<Reputation> GetUserReputation(int userId, ReputationOptions options)
        {
            return GetUserReputation(userId.ToArray(), options);
        }

        public virtual IPagedList<Reputation> GetUserReputation(IEnumerable<int> userIds)
        {
            return GetUserReputation(userIds, new ReputationOptions());
        }

        public virtual IPagedList<Reputation> GetUserReputation(IEnumerable<int> userIds, ReputationOptions options)
        {
            var response = MakeRequest<ReputationResponse>("users", new string[] { userIds.Vectorize(), "reputation" }, new
            {
                key = apiKey,
                fromdate = options.FromDate.HasValue ? (long?)options.FromDate.Value.ToUnixTime() : null,
                todate = options.ToDate.HasValue ? (long?)options.ToDate.Value.ToUnixTime() : null,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null
            });
            return new PagedList<Reputation>(response.Reputation, response);
        }
    }
}