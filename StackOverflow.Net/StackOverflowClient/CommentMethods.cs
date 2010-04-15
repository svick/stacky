using System;
using System.Collections.Generic;

namespace StackOverflow
{
    public partial class StackOverflowClient
    {
        public IList<Comment> GetComments(int fromUserId, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Ascending, int? toUserId = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            string[] urlParameters = null;
            if (toUserId.HasValue)
            {
                urlParameters = new string[] { fromUserId.ToString(), "comments", toUserId.ToString() };
            }
            else
            {
                urlParameters = new string[] { fromUserId.ToString(), "comments" };
            }

            return MakeRequest<List<Comment>>("users", false, urlParameters, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection)
            });
        }
    }
}