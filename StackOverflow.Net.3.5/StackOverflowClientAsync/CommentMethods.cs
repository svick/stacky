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
        public void GetComments(IEnumerable<int> fromUserIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError)
        {
            GetComments(fromUserIds, onSuccess, onError, new CommentOptions());
        }

        public void GetComments(IEnumerable<int> fromUserIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, CommentOptions options)
        {
            string[] urlParameters = null;
            if (options.ToUserId.HasValue)
            {
                urlParameters = new string[] { fromUserIds.Vectorize(), "comments", options.ToUserId.ToString() };
            }
            else
            {
                urlParameters = new string[] { fromUserIds.Vectorize(), "comments" };
            }

            MakeRequest<CommentResponse>("users", urlParameters, new
            {
                key = apiKey,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = options.FromDate.HasValue ? (long?)options.FromDate.Value.ToUnixTime() : null,
                todate = options.ToDate.HasValue ? (long?)options.ToDate.Value.ToUnixTime() : null,
                sort = options.SortBy.ToString().ToLower(),
                order = GetSortDirection(options.SortDirection),
                min = options.Min ?? null,
                max = options.Max ?? null
            }, (items) => onSuccess(new PagedList<Comment>(items.Comments, items)), onError);
        }

        public void GetComments(int fromUserId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError)
        {
            GetComments(fromUserId, onSuccess, onError, new CommentOptions());
        }

        public void GetComments(int fromUserId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, CommentOptions options)
        {
            GetComments(fromUserId.ToArray(), onSuccess, onError, options);
        }
    }
}