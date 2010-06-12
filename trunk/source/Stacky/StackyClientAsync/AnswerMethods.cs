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
        public void GetUsersAnswers(int userId, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null, QuestionsByUserSort sortBy = QuestionsByUserSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            GetUsersAnswers(userId.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, includeBody, includeComments);
        }

        public void GetUsersAnswers(IEnumerable<int> userIds, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null, QuestionsByUserSort sortBy = QuestionsByUserSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            MakeRequest<AnswerResponse>("users", new string[] { userIds.Vectorize(), "answers" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection)
            }, (items) => onSuccess(new PagedList<Answer>(items.Answers, items)), onError);
        }

        public void GetQuestionAnswers(int questionId, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null, QuestionsByUserSort sortBy = QuestionsByUserSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false)
        {
            GetUsersAnswers(questionId.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, includeBody);
        }

        public void GetQuestionAnswers(IEnumerable<int> questionIds, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null, QuestionsByUserSort sortBy = QuestionsByUserSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false)
        {
            MakeRequest<AnswerResponse>("questions", new string[] { questionIds.Vectorize(), "answers" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection)
            }, (items) => onSuccess(new PagedList<Answer>(items.Answers, items)), onError);
        }
    }
}