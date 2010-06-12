using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    public partial class StackyClient
    {
        public virtual IPagedList<Question> GetQuestions(QuestionSort sortBy = QuestionSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null, string[] tags = null)
        {
            var sortArgs = sortBy.GetAttribute<SortArgsAttribute>();
            return GetQuestions("questions", sortArgs.UrlArgs, sortArgs.Sort, GetSortDirection(sortDirection), page, pageSize, includeBody, includeComments, fromDate, toDate, min, max, tags);
        }

        public virtual IPagedList<Question> GetQuestionsByUser(int userId, QuestionsByUserSort sortBy = QuestionsByUserSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null, string[] tags = null)
        {
            return GetQuestions("users", new string[] { userId.ToString(), "questions" }, sortBy.ToString().ToLower(), GetSortDirection(sortDirection), page, pageSize, includeBody, includeComments, fromDate, toDate, min, max, tags);
        }

        public virtual IPagedList<Question> GetFavoriteQuestions(int userId, FavoriteQuestionsSort sortBy = FavoriteQuestionsSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null, string[] tags = null)
        {
            return GetQuestions("users", new string[] { userId.ToString(), "favorites" }, sortBy.ToString().ToLower(), GetSortDirection(sortDirection), page, pageSize, includeBody, includeComments, fromDate, toDate, min, max, tags);
        }

        private IPagedList<Question> GetQuestions(string method, string[] urlArguments, string sort, string sortDirection, int? page, int? pageSize, bool includeBody, bool includeComments, DateTime? fromDate, DateTime? toDate, int? min = null, int? max = null, params string[] tags)
        {
            var response = MakeRequest<QuestionResponse>(method, urlArguments, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
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

        public virtual IPagedList<Question> GetQuestions(IEnumerable<int> questionIds, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, int? min = null, int? max = null, string[] tags = null)
        {
            var response = MakeRequest<QuestionResponse>("questions", new string[] { questionIds.Vectorize() }, new
            {
                key = apiKey,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                page = page ?? null,
                pagesize = pageSize ?? null,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null,
                min = min ?? null,
                max = max ?? null
            });
            return new PagedList<Question>(response.Questions, response);
        }

        public virtual Question GetQuestion(int questionId, bool includeBody = false, bool includeComments = false)
        {
            return GetQuestions(questionId.ToArray(), includeBody: includeBody, includeComments: includeComments).FirstOrDefault();
        }

        public virtual IEnumerable<PostEvent> GetQuestionTimeline(IEnumerable<int> questionIds, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return MakeRequest<QuestionTimelineResponse>("questions", new string[] { questionIds.Vectorize(), "timeline" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }).Events;
        }

        public virtual IEnumerable<PostEvent> GetQuestionTimeline(int questionId, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetQuestionTimeline(questionId.ToArray(), fromDate, toDate);
        }

        public virtual IPagedList<Question> Search(string inTitle = null, IEnumerable<string> tagged = null, IEnumerable<string> notTagged = null, SearchSort sortBy = SearchSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null)
        {
            string taggedString = null;
            if (tagged != null)
                taggedString = String.Join(" ", tagged);

            string notTaggedString = null;
            if (notTagged != null)
                notTaggedString = String.Join(" ", notTagged);

            var response = MakeRequest<QuestionResponse>("search", null, new
            {
                key = apiKey,
                intitle = inTitle,
                tagged = taggedString,
                nottagged = notTaggedString,
                sort = sortBy,
                order = GetSortDirection(sortDirection),
                page = page ?? null,
                pagesize = pageSize ?? null
            });
            return new PagedList<Question>(response.Questions, response);
        }
    }
}