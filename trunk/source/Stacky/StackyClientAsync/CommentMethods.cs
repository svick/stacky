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
        public virtual void GetComments(IEnumerable<int> fromUserIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? toUserId = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            string[] urlParameters = null;
            if (toUserId.HasValue)
            {
                urlParameters = new string[] { fromUserIds.Vectorize(), "comments", toUserId.ToString() };
            }
            else
            {
                urlParameters = new string[] { fromUserIds.Vectorize(), "comments" };
            }

            MakeRequest<CommentResponse>("users", urlParameters, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection)
            }, (items) => onSuccess(new PagedList<Comment>(items.Comments, items)), onError);
        }

        public virtual void GetComments(int fromUserId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? toUserId = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetComments(fromUserId.ToArray(), onSuccess, onError, sortBy, sortDirection, toUserId, page, pageSize, fromDate, toDate);
        }

        public virtual void GetCommentsByPost(int postId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetCommentsByPost(postId.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate);
        }

        public virtual void GetCommentsByPost(IEnumerable<int> postIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<CommentResponse>("posts", new string[] { postIds.Vectorize(), "comments" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection),
            }, (items) => onSuccess(new PagedList<Comment>(items.Comments, items)), onError);
        }

        public virtual void GetAnswerComments(int answerId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
        {
            GetAnswerComments(answerId.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max);
        }

        public virtual void GetAnswerComments(IEnumerable<int> answerIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError = null, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
        {
            MakeRequest<CommentResponse>("answers", new string[] { answerIds.Vectorize(), "comments" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection),
                min = min ?? null,
                max = max ?? null
            }, response => onSuccess(new PagedList<Comment>(response.Comments, response)), onError);
        }
    }
}