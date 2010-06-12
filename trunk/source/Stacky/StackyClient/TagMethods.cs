using System.Collections.Generic;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IPagedList<Tag> GetTags(TagSort sortBy = TagSort.Popular, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null)
        {
            return GetTags("tags", null, sortBy.ToString().ToLower(), GetSortDirection(sortDirection), page, pageSize);
        }

        private IPagedList<Tag> GetTags(string method, string[] urlParameters, string sort, string order, int? page = null, int? pageSize = null)
        {
            var response = MakeRequest<TagResponse>(method, urlParameters, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                sort = sort,
                order = order
            });
            return new PagedList<Tag>(response.Tags, response);
        }

        public virtual IPagedList<Tag> GetTagsByUser(int userId, int? page = null, int? pageSize = null)
        {
            return GetTagsByUser(userId.ToArray(), page, pageSize);
        }

        public virtual IPagedList<Tag> GetTagsByUser(IEnumerable<int> userIds, int? page = null, int? pageSize = null)
        {
            //TODO: does this method support sort and order?
            return GetTags("users", new string[] { userIds.Vectorize(), "tags" }, null, null, page, pageSize);
        }
    }
}