using System;
using System.Collections.Generic;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IPagedList<Comment> GetComments(IEnumerable<int> fromUserIds, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? toUserId = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
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

            var response = MakeRequest<CommentResponse>("users", urlParameters, new
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
            });
            return new PagedList<Comment>(response.Comments, response);
        }

        public virtual IPagedList<Comment> GetComments(int fromUserId, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? toUserId = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
        {
            return GetComments(fromUserId.ToArray(), sortBy, sortDirection, toUserId, page, pageSize, fromDate, toDate, min, max);
        }

        public virtual IPagedList<Comment> GetCommentsByPost(int postId, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
        {
            return GetCommentsByPost(postId.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max);
        }

        public virtual IPagedList<Comment> GetCommentsByPost(IEnumerable<int> postIds, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
        {
            var response = MakeRequest<CommentResponse>("posts", new string[] { postIds.Vectorize(), "comments" }, new
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
            });
            return new PagedList<Comment>(response.Comments, response);
        }

        public virtual IPagedList<Comment> GetAnswerComments(int answerId, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
        {
            return GetAnswerComments(answerId.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max);
        }

        public virtual IPagedList<Comment> GetAnswerComments(IEnumerable<int> answerIds, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null)
        {
            var response = MakeRequest<CommentResponse>("answers", new string[] { answerIds.Vectorize(), "comments" }, new
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
            });
            return new PagedList<Comment>(response.Comments, response);
        }
    }
}