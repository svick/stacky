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

        public virtual IEnumerable<User> GetUsersByBadge(int badgeId)
        {
            return GetUsersByBadge(badgeId, new BadgeByUserOptions());
        }

        public virtual IEnumerable<User> GetUsersByBadge(int badgeId, BadgeByUserOptions options)
        {
            return GetUsersByBadge(badgeId.ToArray(), options);
        }

        public virtual IPagedList<User> GetUsersByBadge(IEnumerable<int> badgeIds)
        {
            return GetUsersByBadge(badgeIds, new BadgeByUserOptions());
        }

        public virtual IPagedList<User> GetUsersByBadge(IEnumerable<int> badgeIds, BadgeByUserOptions options)
        {
            var response = MakeRequest<UserResponse>("badges", new string[] { badgeIds.Vectorize() }, new
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