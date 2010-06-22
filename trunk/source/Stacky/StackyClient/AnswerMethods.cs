using System.Collections.Generic;
using System;

namespace Stacky
{
    /// <summary>
    /// 
    /// </summary>
    public partial class StackyClient
    {

        /// <summary>
        /// Gets the users answers.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="includeBody">if set to <c>true</c> [include body].</param>
        /// <param name="includeComments">if set to <c>true</c> [include comments].</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public virtual IPagedList<Answer> GetUsersAnswers(int userId, QuestionsByUserSort sortBy = QuestionsByUserSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, int? min = null, int? max = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetUsersAnswers(userId.ToArray(), sortBy, sortDirection, page, pageSize, includeBody, includeComments, min, max, fromDate, toDate);
        }

        /// <summary>
        /// Gets the users answers.
        /// </summary>
        /// <param name="userIds">The user ids.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="includeBody">if set to <c>true</c> [include body].</param>
        /// <param name="includeComments">if set to <c>true</c> [include comments].</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public virtual IPagedList<Answer> GetUsersAnswers(IEnumerable<int> userIds, QuestionsByUserSort sortBy = QuestionsByUserSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, int? min = null, int? max = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var response = MakeRequest<AnswerResponse>("users", new string[] { userIds.Vectorize(), "answers" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection),
                min = min ?? null,
                max = max ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
            return new PagedList<Answer>(response.Answers, response);
        }

        /// <summary>
        /// Gets the question answers.
        /// </summary>
        /// <param name="questionIds">The question ids.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="includeBody">if set to <c>true</c> [include body].</param>
        /// <param name="includeComments">if set to <c>true</c> [include comments].</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public virtual IPagedList<Answer> GetQuestionAnswers(IEnumerable<int> questionIds, QuestionsByUserSort sortBy = QuestionsByUserSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, int? min = null, int? max = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var response = MakeRequest<AnswerResponse>("questions", new string[] { questionIds.Vectorize(), "answers" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection),
                min = min ?? null,
                max = max ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
            return new PagedList<Answer>(response.Answers, response);
        }

        /// <summary>
        /// Gets the question answers.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="includeBody">if set to <c>true</c> [include body].</param>
        /// <param name="includeComments">if set to <c>true</c> [include comments].</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public virtual IPagedList<Answer> GetQuestionAnswers(int questionId, QuestionsByUserSort sortBy = QuestionsByUserSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, int? min = null, int? max = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetQuestionAnswers(questionId.ToArray(), sortBy, sortDirection, page, pageSize, includeBody, includeComments, min, max, fromDate, toDate);
        }
    }
}