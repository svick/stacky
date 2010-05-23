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
        public void GetBadges(Action<IEnumerable<Badge>> onSuccess, Action<ApiException> onError = null, BadgeSort sortBy = BadgeSort.Name)
        {
            GetBadges(onSuccess, onError, "badges", new string[] { sortBy.ToString().ToLower() });
        }

        private void GetBadges(Action<IEnumerable<Badge>> onSuccess, Action<ApiException> onError, string method, string[] sort)
        {
            MakeRequest<BadgeResponse>(method, sort, new
            {
                key = apiKey
            }, (items) => onSuccess(items.Badges), onError);
        }

        public void GetBadgesByUser(int userId, Action<IEnumerable<Badge>> onSuccess, Action<ApiException> onError = null)
        {
            GetBadgesByUser(userId.ToArray(), onSuccess, onError);
        }

        public void GetBadgesByUser(IEnumerable<int> userIds, Action<IEnumerable<Badge>> onSuccess, Action<ApiException> onError = null)
        {
            GetBadges(onSuccess, onError, "users", new string[] { userIds.Vectorize(), "badges" });
        }
    }
}