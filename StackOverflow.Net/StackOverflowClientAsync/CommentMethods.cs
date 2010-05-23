﻿using System;
using System.Collections.Generic;

namespace StackOverflow
{
#if SILVERLIGHT
    public partial class StackOverflowClient
#else
    public partial class StackOverflowClientAsync
#endif
    {
        public void GetComments(IEnumerable<int> fromUserIds, Action<IEnumerable<Comment>> onSuccess, Action<ApiException> onError = null, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? toUserId = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
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
            }, (items) => onSuccess(items.Comments), onError);
        }

        public void GetComments(int fromUserId, Action<IEnumerable<Comment>> onSuccess, Action<ApiException> onError = null, CommentSort sortBy = CommentSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? toUserId = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetComments(fromUserId.ToArray(), onSuccess, onError, sortBy, sortDirection, toUserId, page, pageSize, fromDate, toDate);
        }
    }
}