using System.Collections.Generic;

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

        public virtual IEnumerable<User> GetUsersByBadge(int userId)
        {
            return GetUsersByBadge(userId, new BadgeByUserOptions());
        }

        public virtual IEnumerable<User> GetUsersByBadge(int userId, BadgeByUserOptions options)
        {
            return GetUsersByBadge(userId.ToArray(), options);
        }

        public virtual IPagedList<User> GetUsersByBadge(IEnumerable<int> userIds)
        {
            return GetUsersByBadge(userIds, new BadgeByUserOptions());
        }

        public virtual IPagedList<User> GetUsersByBadge(IEnumerable<int> userIds, BadgeByUserOptions options)
        {
            var response = MakeRequest<UserResponse>("badges", new string[] { userIds.Vectorize() }, new
            {
                key = apiKey,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = options.FromDate.HasValue ? (long?)options.FromDate.Value.ToUnixTime() : null,
                todate = options.ToDate.HasValue ? (long?)options.ToDate.Value.ToUnixTime() : null
            });
            return new PagedList<User>(response.Users, response);
        }

        public virtual IEnumerable<Badge> GetTagBasedBadges()
        {
            return GetBadges("badges", new string[] { "tags" });
        }
    }
}