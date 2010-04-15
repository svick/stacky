using System.Collections.Generic;

namespace StackOverflow
{
    public partial class StackOverflowClient
    {
        public IList<Tag> GetTags(TagSort sortBy = TagSort.Popular, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null)
        {
            return GetTags("tags", null, sortBy.ToString().ToLower(), GetSortDirection(sortDirection), page, pageSize);
        }

        private IList<Tag> GetTags(string method, string[] urlParameters, string sort, string order, int? page = null, int? pageSize = null)
        {
            return MakeRequest<List<Tag>>(method, false, urlParameters, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                sort = sort,
                order = order
            });
        }

        public IList<Tag> GetTagsByUser(int userId, int? page = null, int? pageSize = null)
        {
            //TODO: does this method support sort and order?
            return GetTags("users", new string[] { userId.ToString(), "tags" }, null, null, page, pageSize);
        }
    }
}