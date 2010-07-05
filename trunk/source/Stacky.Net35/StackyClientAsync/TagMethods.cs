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
        private void GetTags(Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError, string method, string[] urlParameters, string filter, string sort, string order, int? page, int? pageSize, DateTime? fromDate, DateTime? toDate, int? min, int? max)
        {
            MakeRequest<TagResponse>(method, urlParameters, new
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
            }, (items) => onSuccess(new PagedList<Tag>(items.Tags, items)), onError);
        }

        public virtual void GetTags(Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError)
        {
            GetTags(onSuccess, onError, new TagOptions());
        }

        public virtual void GetTags(Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError, TagOptions options)
        {
            GetTags(onSuccess, onError, "tags", null, options.Filter, options.SortBy.ToString().ToLower(), GetSortDirection(options.SortDirection), options.Page, options.PageSize, options.FromDate, options.ToDate, options.Min, options.Max);
        }

        public virtual void GetTagsByUser(int userId, Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError)
        {
            GetTagsByUser(userId, onSuccess, onError, new TagOptions());
        }

        public virtual void GetTagsByUser(int userId, Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError, TagOptions options)
        {
            GetTagsByUser(userId.ToArray(), onSuccess, onError, options);
        }

        public virtual void GetTagsByUser(IEnumerable<int> userIds, Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError)
        {
            GetTagsByUser(userIds, onSuccess, onError, new TagOptions());
        }

        public virtual void GetTagsByUser(IEnumerable<int> userIds, Action<IPagedList<Tag>> onSuccess, Action<ApiException> onError, TagOptions options)
        {
            GetTags(onSuccess, onError, "users", new string[] { userIds.Vectorize(), "tags" }, options.Filter, options.SortBy.ToString(), GetSortDirection(options.SortDirection), options.Page, options.PageSize, options.FromDate, options.ToDate, options.Min, options.Max);
        }
    }
}