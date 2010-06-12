using System;
using System.Collections.Generic;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        public void GetBadges(Action<IEnumerable<Badge>> onSuccess, Action<ApiException> onError = null)
        {
            GetBadges(onSuccess, onError, "badges", null);
        }

        private void GetBadges(Action<IEnumerable<Badge>> onSuccess, Action<ApiException> onError, string method, string[] urlArguments)
        {
            MakeRequest<BadgeResponse>(method, urlArguments, new
            {
                key = apiKey
            }, (items) => onSuccess(items.Badges), onError);
        }

        public void GetUsersByBadge(int userId, Action<IPagedList<User>> onSuccess, Action<ApiException> onError = null)
        {
            GetUsersByBadge(userId.ToArray(), onSuccess, onError);
        }

        public void GetUsersByBadge(IEnumerable<int> userIds, Action<IPagedList<User>> onSuccess, Action<ApiException> onError = null)
        {
            MakeRequest<UserResponse>("badges", new string[] { userIds.Vectorize() }, new
            {
                key = apiKey
            }, (items) => onSuccess(new PagedList<User>(items.Users, items)), onError);
        }

        public void GetTagBasedBadges(Action<IEnumerable<Badge>> onSuccess, Action<ApiException> onError = null)
        {
            GetBadges(onSuccess, onError, "badges", new string[] { "tags" });
        }
    }
}