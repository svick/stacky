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
            return GetUsersByBadge(userId.ToArray());
        }

        public virtual IPagedList<User> GetUsersByBadge(IEnumerable<int> userIds)
        {
            var response = MakeRequest<UserResponse>("badges", new string[] { userIds.Vectorize() }, new
            {
                key = apiKey
            });
            return new PagedList<User>(response.Users, response);
        }

        public virtual IEnumerable<Badge> GetTagBasedBadges()
        {
            return GetBadges("badges", new string[] { "tags" });
        }
    }
}