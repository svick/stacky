using System;
using System.Linq;
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

        public void GetUsersAnswers(IEnumerable<int> userIds, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null, QuestionsByUserSort sortBy = QuestionsByUserSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, int? min = null, int? max = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<AnswerResponse>("users", new string[] { userIds.Vectorize(), "answers" }, new
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
            }, (items) => onSuccess(new PagedList<Answer>(items.Answers, items)), onError);
        }

        public void GetQuestionAnswers(int questionId, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null, QuestionsByUserSort sortBy = QuestionsByUserSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false)
        {
            GetUsersAnswers(questionId.ToArray(), onSuccess, onError, sortBy, sortDirection, page, pageSize, includeBody);
        }

        public void GetQuestionAnswers(IEnumerable<int> questionIds, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null, QuestionsByUserSort sortBy = QuestionsByUserSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, int? min = null, int? max = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<AnswerResponse>("questions", new string[] { questionIds.Vectorize(), "answers" }, new
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
            }, (items) => onSuccess(new PagedList<Answer>(items.Answers, items)), onError);
        }

        public void GetAnswer(int answerId, Action<Answer> onSuccess, Action<ApiException> onError = null, bool includeBody = true, bool includeComments = true)
        {
            GetAnswers(answerId.ToArray(), answers => onSuccess(answers.FirstOrDefault()), onError, includeBody: includeBody, includeComments: includeComments);
        }

        public void GetAnswers(IEnumerable<int> answerIds, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError = null, AnswerSort sortBy = AnswerSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, int? min = null, int? max = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<AnswerResponse>("answers", new string[] { answerIds.Vectorize() }, new
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
            }, (items) => onSuccess(new PagedList<Answer>(items.Answers, items)), onError);
        }
    }
}