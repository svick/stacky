using System;
using System.Collections.Generic;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IPagedList<Comment> GetComments(IEnumerable<int> fromUserIds)
        {
            return GetComments(fromUserIds, new CommentOptions());
        }

        public virtual IPagedList<Comment> GetComments(IEnumerable<int> fromUserIds, CommentOptions options)
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

            var response = MakeRequest<CommentResponse>("users", urlParameters, new
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
            });
            return new PagedList<Comment>(response.Comments, response);
        }

        public virtual IPagedList<Comment> GetComments(int fromUserId)
        {
            return GetComments(fromUserId.ToArray(), new CommentOptions());
        }

        public virtual IPagedList<Comment> GetComments(int fromUserId, CommentOptions options)
        {
            return GetComments(fromUserId.ToArray(), options);
        }

        public virtual IPagedList<Comment> GetCommentsByPost(int postId)
        {
            return GetCommentsByPost(postId, new CommentsByPostOptions());
        }

        public virtual IPagedList<Comment> GetCommentsByPost(int postId, CommentsByPostOptions options)
        {
            return GetCommentsByPost(postId.ToArray(), options);
        }

        public virtual IPagedList<Comment> GetCommentsByPost(IEnumerable<int> postIds)
        {
            return GetCommentsByPost(postIds, new CommentsByPostOptions());
        }

        public virtual IPagedList<Comment> GetCommentsByPost(IEnumerable<int> postIds, CommentsByPostOptions options)
        {
            var response = MakeRequest<CommentResponse>("posts", new string[] { postIds.Vectorize(), "comments" }, new
            {
                key = apiKey,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = options.FromDate.HasValue ? (long?)options.FromDate.Value.ToUnixTime() : null,
                todate = options.ToDate.HasValue ? (long?)options.ToDate.Value.ToUnixTime() : null,
                sort = options.SortBy.ToString().ToLower(),
                order = GetSortDirection(options.SortDirection),
            });
            return new PagedList<Comment>(response.Comments, response);
        } 
    }
}