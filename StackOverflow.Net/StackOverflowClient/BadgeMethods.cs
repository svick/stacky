using System.Collections.Generic;

namespace StackOverflow
{
    public partial class StackOverflowClient
    {
        public IEnumerable<Badge> GetBadges(BadgeSort sortBy = BadgeSort.Name)
        {
            return GetBadges("badges", new string[] { sortBy.ToString().ToLower() });
        }

        private IEnumerable<Badge> GetBadges(string method, string[] sort)
        {
            return MakeRequest<List<Badge>>(method, false, sort, new
            {
                key = apiKey
            });
        }

        public IEnumerable<Badge> GetBadgesByUser(int userId)
        {
            return GetBadgesByUser(userId.ToArray());
        }

        public IEnumerable<Badge> GetBadgesByUser(IEnumerable<int> userIds)
        {
            return GetBadges("users", new string[] { userIds.Vectorize(), "badges" });
        }
    }
}