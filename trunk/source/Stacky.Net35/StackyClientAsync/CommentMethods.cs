﻿using System;
using System.Collections.Generic;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        public virtual void GetComments(IEnumerable<int> fromUserIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError)
        {
            GetComments(fromUserIds, onSuccess, onError, new CommentOptions());
        }

        public virtual void GetComments(IEnumerable<int> fromUserIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, CommentOptions options)
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

        public virtual void GetComments(int fromUserId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError)
        {
            GetComments(fromUserId, onSuccess, onError, new CommentOptions());
        }

        public virtual void GetComments(int fromUserId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, CommentOptions options)
        {
            GetComments(fromUserId.ToArray(), onSuccess, onError, options);
        }

        public virtual void GetCommentsByPost(int postId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError)
        {
            GetCommentsByPost(postId, onSuccess, onError, new CommentsByPostOptions());
        }

        public virtual void GetCommentsByPost(int postId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, CommentsByPostOptions options)
        {
            GetCommentsByPost(postId.ToArray(), onSuccess, onError, options);
        }

        public virtual void GetCommentsByPost(IEnumerable<int> postIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError)
        {
            GetCommentsByPost(postIds, onSuccess, onError, new CommentsByPostOptions());
        }

        public virtual void GetCommentsByPost(IEnumerable<int> postIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, CommentsByPostOptions options)
        {
            MakeRequest<CommentResponse>("posts", new string[] { postIds.Vectorize(), "comments" }, new
            {
                key = apiKey,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = options.FromDate.HasValue ? (long?)options.FromDate.Value.ToUnixTime() : null,
                todate = options.ToDate.HasValue ? (long?)options.ToDate.Value.ToUnixTime() : null,
                sort = options.SortBy.ToString().ToLower(),
                order = GetSortDirection(options.SortDirection),
            }, (items) => onSuccess(new PagedList<Comment>(items.Comments, items)), onError);
        }

        public virtual void GetAnswerComments(int answerId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError)
        {
            GetAnswerComments(answerId, onSuccess, onError, new CommentsByPostOptions());
        }

        public virtual void GetAnswerComments(int answerId, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, CommentsByPostOptions options)
        {
            GetAnswerComments(answerId.ToArray(), onSuccess, onError, options);
        }

        public virtual void GetAnswerComments(IEnumerable<int> answerIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError)
        {
            GetAnswerComments(answerIds, onSuccess, onError, new CommentsByPostOptions());
        }

        public virtual void GetAnswerComments(IEnumerable<int> answerIds, Action<IPagedList<Comment>> onSuccess, Action<ApiException> onError, CommentsByPostOptions options)
        {
            MakeRequest<CommentResponse>("answers", new string[] { answerIds.Vectorize(), "comments" }, new
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
            }, response => onSuccess(new PagedList<Comment>(response.Comments, response)), onError);
        }
    }
}