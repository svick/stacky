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
        public void GetTags(Action<List<Tag>> callback, Action<ApiException> onError = null, TagSort sortBy = TagSort.Popular, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null)
        {
            GetTags(callback, onError, "tags", null, sortBy.ToString().ToLower(), GetSortDirection(sortDirection), page, pageSize);
        }

        private void GetTags(Action<List<Tag>> callback, Action<ApiException> onError, string method, string[] urlParameters, string sort, string order, int? page = null, int? pageSize = null)
        {
            MakeRequest<List<Tag>>(method, false, urlParameters, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                sort = sort,
                order = order
            }, callback, onError);
        }

        public void GetTagsByUser(int userId, Action<List<Tag>> callback, Action<ApiException> onError = null, int? page = null, int? pageSize = null)
        {
            GetTagsByUser(userId.ToArray(), callback, onError, page, pageSize);
        }

        public void GetTagsByUser(IEnumerable<int> userIds, Action<List<Tag>> callback, Action<ApiException> onError = null, int? page = null, int? pageSize = null)
        {
            //TODO: does this method support sort and order?
            GetTags(callback, onError, "users", new string[] { userIds.Vectorize(), "tags" }, null, null, page, pageSize);
        }
    }
}
