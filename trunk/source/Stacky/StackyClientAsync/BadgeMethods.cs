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
        public virtual void GetBadges(Action<IEnumerable<Badge>> onSuccess, Action<ApiException> onError = null)
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

        public virtual void GetUsersByBadge(int userId, Action<IPagedList<User>> onSuccess, Action<ApiException> onError = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetUsersByBadge(userId.ToArray(), onSuccess, onError, page, pageSize, fromDate, toDate);
        }

        public virtual void GetUsersByBadge(IEnumerable<int> userIds, Action<IPagedList<User>> onSuccess, Action<ApiException> onError = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<UserResponse>("badges", new string[] { userIds.Vectorize() }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, (items) => onSuccess(new PagedList<User>(items.Users, items)), onError);
        }

        public virtual void GetTagBasedBadges(Action<IEnumerable<Badge>> onSuccess, Action<ApiException> onError = null)
        {
            GetBadges(onSuccess, onError, "badges", new string[] { "tags" });
        }
    }
}