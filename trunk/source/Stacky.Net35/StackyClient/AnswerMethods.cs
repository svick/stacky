using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IPagedList<Answer> GetUsersAnswers(int userId)
        {
            return GetUsersAnswers(userId.ToArray(), new AnswerOptions());
        }

        public virtual IPagedList<Answer> GetUsersAnswers(int userId, AnswerOptions options)
        {
            return GetUsersAnswers(userId.ToArray(), options);
        }

        public virtual IPagedList<Answer> GetUsersAnswers(IEnumerable<int> userIds)
        {
            return GetUsersAnswers(userIds, new AnswerOptions());
        }

        public virtual IPagedList<Answer> GetUsersAnswers(IEnumerable<int> userIds, AnswerOptions options)
        {
            var response = MakeRequest<AnswerResponse>("users", new string[] { userIds.Vectorize(), "answers" }, new
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
            });
            return new PagedList<Answer>(response.Answers, response);
        }

        public virtual IPagedList<Answer> GetQuestionAnswers(IEnumerable<int> questionIds)
        {
            return GetQuestionAnswers(questionIds, new AnswerOptions());
        }

        public virtual IPagedList<Answer> GetQuestionAnswers(IEnumerable<int> questionIds, AnswerOptions options)
        {
            var response = MakeRequest<AnswerResponse>("questions", new string[] { questionIds.Vectorize(), "answers" }, new
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
            });
            return new PagedList<Answer>(response.Answers, response);
        }

        public virtual IPagedList<Answer> GetQuestionAnswers(int questionId)
        {
            return GetQuestionAnswers(questionId.ToArray(), new AnswerOptions());
        }

        public virtual IPagedList<Answer> GetQuestionAnswers(int questionId, AnswerOptions options)
        {
            return GetQuestionAnswers(questionId.ToArray(), options);
        }

        public virtual Answer GetAnswer(int answerId)
        {
            return GetAnswer(answerId, new AnswerOptions());
        }

        public virtual Answer GetAnswer(int answerId, AnswerOptions options)
        {
            return GetAnswers(answerId.ToArray(), options).FirstOrDefault();
        }

        public virtual IPagedList<Answer> GetAnswers(IEnumerable<int> answerIds)
        {
            return GetAnswers(answerIds, new AnswerOptions());
        }

        public virtual IPagedList<Answer> GetAnswers(IEnumerable<int> answerIds, AnswerOptions options)
        {
            var response = MakeRequest<AnswerResponse>("answers", new string[] { answerIds.Vectorize() }, new
            {
                key = apiKey,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                body = options.IncludeBody ? (bool?)true : null,
                sort = options.SortBy.ToString().ToLower(),
                order = GetSortDirection(options.SortDirection),
                min = options.Min ?? null,
                max = options.Max ?? null,
                fromdate = options.FromDate.HasValue ? (long?)options.FromDate.Value.ToUnixTime() : null,
                todate = options.ToDate.HasValue ? (long?)options.ToDate.Value.ToUnixTime() : null
            });
            return new PagedList<Answer>(response.Answers, response);
        }
    }
}