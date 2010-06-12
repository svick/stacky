using System.Collections.Generic;
using System;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IPagedList<Tag> GetTags()
        {
            return GetTags(new TagOptions());
        }

        public virtual IPagedList<Tag> GetTags(TagOptions options)
        {
            return GetTags("tags", null, options.Filter, options.SortBy.ToString(), GetSortDirection(options.SortDirection), options.Page, options.PageSize, options.FromDate, options.ToDate, options.Min, options.Max);
        }

        private IPagedList<Tag> GetTags(string method, string[] urlParameters, string filter, string sort, string order, int? page, int? pageSize, DateTime? fromDate, DateTime? toDate, int? min, int? max)
        {
            var response = MakeRequest<TagResponse>(method, urlParameters, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                sort = sort,
                order = order,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
                min = min ?? null,
                max = max ?? null
            });
            return new PagedList<Tag>(response.Tags, response);
        }

        public virtual IPagedList<Tag> GetTagsByUser(int userId)
        {
            return GetTagsByUser(userId, new TagOptions());
        }

        public virtual IPagedList<Tag> GetTagsByUser(int userId, TagOptions options)
        {
            return GetTagsByUser(userId.ToArray(), options);
        }

        public virtual IPagedList<Tag> GetTagsByUser(IEnumerable<int> userIds)
        {
            return GetTagsByUser(userIds, new TagOptions());
        }

        public virtual IPagedList<Tag> GetTagsByUser(IEnumerable<int> userIds, TagOptions options)
        {
            return GetTags("users", new string[] { userIds.Vectorize(), "tags" }, options.Filter, options.SortBy.ToString(), GetSortDirection(options.SortDirection), options.Page, options.PageSize, options.FromDate, options.ToDate, options.Min, options.Max);
        }
    }
}