using System.Collections.Generic;

namespace StackOverflow
{
    public partial class StackOverflowClient
    {
        public virtual IEnumerable<Tag> GetTags(TagSort sortBy = TagSort.Popular, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null)
        {
            return GetTags("tags", null, sortBy.ToString().ToLower(), GetSortDirection(sortDirection), page, pageSize);
        }

        private IEnumerable<Tag> GetTags(string method, string[] urlParameters, string sort, string order, int? page = null, int? pageSize = null)
        {
            return MakeRequest<TagResponse>(method, urlParameters, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                sort = sort,
                order = order
            }).Tags;
        }

        public virtual IEnumerable<Tag> GetTagsByUser(int userId, int? page = null, int? pageSize = null)
        {
            return GetTagsByUser(userId.ToArray(), page, pageSize);
        }

        public virtual IEnumerable<Tag> GetTagsByUser(IEnumerable<int> userIds, int? page = null, int? pageSize = null)
        {
            //TODO: does this method support sort and order?
            return GetTags("users", new string[] { userIds.Vectorize(), "tags" }, null, null, page, pageSize);
        }
    }
}