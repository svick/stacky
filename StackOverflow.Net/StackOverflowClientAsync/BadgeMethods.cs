using System;
using System.Collections.Generic;

namespace StackOverflow
{
#if SILVERLIGHT
    public partial class StackOverflowClient
#else
    public partial class StackOverflowClientAsync
#endif
    {
        public void GetBadges(Action<IEnumerable<Badge>> callback, Action<ApiException> onError = null, BadgeSort sortBy = BadgeSort.Name)
        {
            GetBadges(callback, onError, "badges", new string[] { sortBy.ToString().ToLower() });
        }

        private void GetBadges(Action<IEnumerable<Badge>> callback, Action<ApiException> onError, string method, string[] sort)
        {
            MakeRequest<List<Badge>>(method, false, sort, new
            {
                key = apiKey
            }, callback, onError);
        }

        public void GetBadgesByUser(int userId, Action<IEnumerable<Badge>> callback, Action<ApiException> onError = null)
        {
            GetBadgesByUser(userId.ToArray(), callback, onError);
        }

        public void GetBadgesByUser(IEnumerable<int> userIds, Action<IEnumerable<Badge>> callback, Action<ApiException> onError = null)
        {
            GetBadges(callback, onError, "users", new string[] { userIds.Vectorize(), "badges" });
        }
    }
}