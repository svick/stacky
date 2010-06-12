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
        public void GetTags(Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError = null, TagSort sortBy = TagSort.Popular, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null)
        {
            GetTags(onSuccess, onError, "tags", null, sortBy.ToString().ToLower(), GetSortDirection(sortDirection), page, pageSize);
        }

        private void GetTags(Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError, string method, string[] urlParameters, string sort, string order, int? page = null, int? pageSize = null)
        {
            MakeRequest<TagResponse>(method, urlParameters, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                sort = sort,
                order = order
            }, (items) => onSuccess(new PagedList<Tag>(items.Tags, items)), onError);
        }

        public void GetTagsByUser(int userId, Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError = null, int? page = null, int? pageSize = null)
        {
            GetTagsByUser(userId.ToArray(), onSuccess, onError, page, pageSize);
        }

        public void GetTagsByUser(IEnumerable<int> userIds, Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError = null, int? page = null, int? pageSize = null)
        {
            //TODO: does this method support sort and order?
            GetTags(onSuccess, onError, "users", new string[] { userIds.Vectorize(), "tags" }, null, null, page, pageSize);
        }
    }
}
