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
        public void GetBadges(Action<IEnumerable<Badge>> onSuccess, Action<ApiException> onError)
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

        public void GetUsersByBadge(int userId, Action<IPagedList<User>> onSuccess, Action<ApiException> onError)
        {
            GetUsersByBadge(userId, onSuccess, onError, new BadgeByUserOptions());
        }

        public void GetUsersByBadge(int userId, Action<IPagedList<User>> onSuccess, Action<ApiException> onError, BadgeByUserOptions options)
        {
            GetUsersByBadge(userId.ToArray(), onSuccess, onError, options);
        }

        public void GetUsersByBadge(IEnumerable<int> userIds, Action<IPagedList<User>> onSuccess, Action<ApiException> onError)
        {
            GetUsersByBadge(userIds, onSuccess, onError, new BadgeByUserOptions());
        }

        public void GetUsersByBadge(IEnumerable<int> userIds, Action<IPagedList<User>> onSuccess, Action<ApiException> onError, BadgeByUserOptions options)
        {
            MakeRequest<UserResponse>("badges", new string[] { userIds.Vectorize(), "badges" }, new
            {
                key = apiKey,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = options.FromDate.HasValue ? (long?)options.FromDate.Value.ToUnixTime() : null,
                todate = options.ToDate.HasValue ? (long?)options.ToDate.Value.ToUnixTime() : null
            }, (items) => onSuccess(new PagedList<User>(items.Users, items)), onError);
        }

        public void GetTagBasedBadges(Action<IEnumerable<Badge>> onSuccess, Action<ApiException> onError)
        {
            GetBadges(onSuccess, onError, "badges", new string[] { "tags" });
        }
    }
}