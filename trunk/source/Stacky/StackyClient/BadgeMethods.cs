using System.Collections.Generic;
using System;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IEnumerable<Badge> GetBadges()
        {
            return GetBadges("badges", null);
        }

        private IEnumerable<Badge> GetBadges(string method, string[] urlArguments)
        {
            return MakeRequest<BadgeResponse>(method, urlArguments, new
            {
                key = apiKey
            }).Badges;
        }

        public virtual IEnumerable<User> GetUsersByBadge(int userId, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetUsersByBadge(userId.ToArray(), page, pageSize, fromDate, toDate);
        }

        public virtual IPagedList<User> GetUsersByBadge(IEnumerable<int> userIds, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var response = MakeRequest<UserResponse>("badges", new string[] { userIds.Vectorize() }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
            return new PagedList<User>(response.Users, response);
        }

        public virtual IEnumerable<Badge> GetTagBasedBadges()
        {
            return GetBadges("badges", new string[] { "tags" });
        }

        public virtual IEnumerable<Badge> GetUserBadges(int userId)
        {
            return GetUserBadges(userId.ToArray());
        }

        public virtual IEnumerable<Badge> GetUserBadges(IEnumerable<int> userIds)
        {
            return MakeRequest<BadgeResponse>("users", new string[] { userIds.Vectorize(), "badges" }, new
            {
                key = apiKey
            }).Badges;
        }
    }
}