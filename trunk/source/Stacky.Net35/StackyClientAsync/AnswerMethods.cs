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
        public void GetUsersAnswers(int userId, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError)
        {
            GetUsersAnswers(userId, onSuccess, onError, new AnswerOptions());
        }

        public void GetUsersAnswers(int userId, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError, AnswerOptions options)
        {
            GetUsersAnswers(userId.ToArray(), onSuccess, onError, options);
        }

        public void GetUsersAnswers(IEnumerable<int> userIds, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError)
        {
            GetUsersAnswers(userIds, onSuccess, onError, new AnswerOptions());
        }

        public void GetUsersAnswers(IEnumerable<int> userIds, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError, AnswerOptions options)
        {
            GetAnswers("users", new string[] { userIds.Vectorize(), "answers" }, onSuccess, onError, options);
        }

        public void GetQuestionAnswers(int questionId, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError)
        {
            GetQuestionAnswers(questionId, onSuccess, onError, new AnswerOptions());
        }

        public void GetQuestionAnswers(int questionId, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError, AnswerOptions options)
        {
            GetUsersAnswers(questionId.ToArray(), onSuccess, onError, options);
        }

        public void GetQuestionAnswers(IEnumerable<int> questionIds, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError)
        {
            GetQuestionAnswers(questionIds, onSuccess, onError, new AnswerOptions());
        }

        public void GetQuestionAnswers(IEnumerable<int> questionIds, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError, AnswerOptions options)
        {
            GetAnswers("questions", new string[] { questionIds.Vectorize(), "answers" }, onSuccess, onError, options);
        }

        private void GetAnswers(string method, string[] urlParameters, Action<IPagedList<Answer>> onSuccess, Action<ApiException> onError, AnswerOptions options)
        {
            MakeRequest<AnswerResponse>(method, urlParameters, new
            {
                key = apiKey,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                body = options.IncludeBody ? (bool?)true : null,
                comments = options.IncludeComments ? (bool?)true : null,
                sort = options.SortBy.ToString().ToLower(),
                order = GetSortDirection(options.SortDirection),
                min = options.Min ?? null,
                max = options.Max ?? null,
                fromdate = options.FromDate.HasValue ? (long?)options.FromDate.Value.ToUnixTime() : null,
                todate = options.ToDate.HasValue ? (long?)options.ToDate.Value.ToUnixTime() : null
            }, (items) => onSuccess(new PagedList<Answer>(items.Answers, items)), onError);
        }
    }
}