using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IPagedList<Question> GetQuestions()
        {
            return GetQuestions(new QuestionOptions());
        }

        public virtual IPagedList<Question> GetQuestions(QuestionOptions options)
        {
            var sortArgs = options.SortBy.GetAttribute<SortArgsAttribute>();
            return GetQuestions("questions", sortArgs.UrlArgs, sortArgs.Sort, GetSortDirection(options.SortDirection), options.Page, options.PageSize, options.IncludeBody, options.IncludeComments, options.IncludeAnswers, options.FromDate, options.ToDate, options.Min, options.Max, options.Tags);
        }

        public virtual IPagedList<Question> GetQuestions(IEnumerable<int> questionIds)
        {
            return GetQuestions(questionIds, new QuestionOptions());
        }

        public virtual IPagedList<Question> GetQuestions(IEnumerable<int> questionIds, QuestionOptions options)
        {
            var sortArgs = options.SortBy.GetAttribute<SortArgsAttribute>();
            string[] urlArgs = sortArgs.UrlArgs.Concat(new string[] { questionIds.Vectorize() }).ToArray();
            return GetQuestions("questions", urlArgs, sortArgs.Sort, GetSortDirection(options.SortDirection), options.Page, options.PageSize, options.IncludeBody, options.IncludeComments, options.IncludeAnswers, options.FromDate, options.ToDate, options.Min, options.Max, options.Tags);
        }

        public virtual IPagedList<Question> GetQuestionsByUser(int userId)
        {
            return GetQuestionsByUser(userId, new QuestionByUserOptions());
        }

        public virtual IPagedList<Question> GetQuestionsByUser(int userId, QuestionByUserOptions options)
        {
            return GetQuestions("users", new string[] { userId.ToString(), "questions" }, options.SortBy.ToString().ToLower(), GetSortDirection(options.SortDirection), options.Page, options.PageSize, options.IncludeBody, options.IncludeComments, options.IncludeAnswers, options.FromDate, options.ToDate, options.Min, options.Max, options.Tags);
        }

        public virtual IPagedList<Question> GetFavoriteQuestions(int userId)
        {
            return GetFavoriteQuestions(userId, new FavoriteQuestionOptions());
        }

        public virtual IPagedList<Question> GetFavoriteQuestions(int userId, FavoriteQuestionOptions options)
        {
            return GetQuestions("users", new string[] { userId.ToString(), "favorites" }, options.SortBy.ToString().ToLower(), GetSortDirection(options.SortDirection), options.Page, options.PageSize, options.IncludeBody, options.IncludeComments, options.IncludeAnswers, options.FromDate, options.ToDate, options.Min, options.Max, options.Tags);
        }

        private IPagedList<Question> GetQuestions(string method, string[] urlArguments, string sort, string sortDirection, int? page, int? pageSize, bool includeBody, bool includeComments, bool includeAnswers, DateTime? fromDate, DateTime? toDate, int? min, int? max, params string[] tags)
        {
            var response = MakeRequest<QuestionResponse>(method, urlArguments, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                answers = includeAnswers ? (bool?)true : null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
                tagged = tags == null ? (string)null : String.Join(" ", tags),
                sort = sort,
                order = sortDirection,
                min = min ?? null,
                max = max ?? null
            });
            return new PagedList<Question>(response.Questions, response);
        }

        public virtual Question GetQuestion(int questionId)
        {
            return GetQuestion(questionId, null, null, null);
        }

        public virtual Question GetQuestion(int questionId, bool? includeBody, bool? includeComments, bool? includeAnswers)
        {
            return GetQuestions("questions", new string[] { questionId.ToString() }, null, null, null, null, includeBody ?? false, includeComments ?? false, includeAnswers ?? false, null, null, null, null, null).FirstOrDefault();
        }

        public virtual IPagedList<PostEvent> GetQuestionTimeline(IEnumerable<int> questionIds)
        {
            return GetQuestionTimeline(questionIds, new QuestionTimelineOptions());
        }

        public virtual IPagedList<PostEvent> GetQuestionTimeline(IEnumerable<int> questionIds, QuestionTimelineOptions options)
        {
            var response = MakeRequest<QuestionTimelineResponse>("questions", new string[] { questionIds.Vectorize(), "timeline" }, new
            {
                key = apiKey,
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                fromdate = options.FromDate.HasValue ? (long?)options.FromDate.Value.ToUnixTime() : null,
                todate = options.ToDate.HasValue ? (long?)options.ToDate.Value.ToUnixTime() : null
            });
            return new PagedList<PostEvent>(response.Events, response);
        }

        public virtual IEnumerable<PostEvent> GetQuestionTimeline(int questionId)
        {
            return GetQuestionTimeline(questionId.ToArray());
        }

        public virtual IEnumerable<PostEvent> GetQuestionTimeline(int questionId, QuestionTimelineOptions options)
        {
            return GetQuestionTimeline(questionId.ToArray(), options);
        }

        public virtual IPagedList<Question> Search(QuestionSearchOptions options)
        {
            string taggedString = null;
            if (options.Tagged != null)
                taggedString = String.Join(" ", options.Tagged.ToArray());

            string notTaggedString = null;
            if (options.NotTagged != null)
                notTaggedString = String.Join(" ", options.NotTagged.ToArray());

            var response = MakeRequest<QuestionResponse>("search", null, new
            {
                key = apiKey,
                intitle = options.InTitle,
                tagged = taggedString,
                nottagged = notTaggedString,
                sort = options.SortBy.ToString(),
                order = GetSortDirection(options.SortDirection),
                page = options.Page ?? null,
                pagesize = options.PageSize ?? null,
                min = options.Min ?? null,
                max = options.Max ?? null
            });
            return new PagedList<Question>(response.Questions, response);
        }
    }
}