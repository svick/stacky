﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackOverflow
{
#if SILVERLIGHT
    public partial class StackOverflowClient
#else
    public partial class StackOverflowClientAsync
#endif
    {
        public void GetQuestions(Action<IEnumerable<Question>> onSuccess, Action<ApiException> onError = null, QuestionSort sortBy = QuestionSort.Active, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            var sortArgs = sortBy.GetAttribute<SortArgsAttribute>();
            GetQuestions(onSuccess, onError, "questions", sortArgs.UrlArgs, sortArgs.Sort, GetSortDirection(sortDirection), page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetQuestionsByUser(int userId, Action<IEnumerable<Question>> onSuccess, Action<ApiException> onError = null, QuestionsByUserSort sortBy = QuestionsByUserSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(onSuccess, onError, "users", new string[] { userId.ToString(), "questions" }, sortBy.ToString().ToLower(), GetSortDirection(sortDirection), page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        public void GetFavoriteQuestions(int userId, Action<IEnumerable<Question>> onSuccess, Action<ApiException> onError = null, FavoriteQuestionsSort sortBy = FavoriteQuestionsSort.Recent, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            GetQuestions(onSuccess, onError, "users", new string[] { userId.ToString(), "favorites" }, sortBy.ToString().ToLower(), GetSortDirection(sortDirection), page, pageSize, includeBody, includeComments, fromDate, toDate, tags);
        }

        private void GetQuestions(Action<IEnumerable<Question>> onSuccess, Action<ApiException> onError, string method, string[] urlArgs, string sort, string order, int? page, int? pageSize, bool includeBody, bool includeComments, DateTime? fromDate, DateTime? toDate, params string[] tags)
        {
            MakeRequest<QuestionResponse>(method, urlArgs, new
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
                order = order
            }, (items) => onSuccess(items.Questions), onError);
        }

        public void GetQuestions(IEnumerable<int> questionIds, Action<IEnumerable<Question>> onSuccess, Action<ApiException> onError = null, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            MakeRequest<QuestionResponse>("questions", new string[] { questionIds.Vectorize() }, new
            {
                key = apiKey,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                page = page ?? null,
                pagesize = pageSize ?? null
            }, (items) => onSuccess(items.Questions), onError);
        }

        public void GetQuestion(int questionId, Action<Question> onSuccess, Action<ApiException> onError = null, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            GetQuestions(questionId.ToArray(), returnedQuestions => onSuccess(returnedQuestions.FirstOrDefault()), onError, page, pageSize, includeBody, includeComments);
        }

        public void GetQuestionTimeline(IEnumerable<int> questionIds, Action<IEnumerable<PostEvent>> onSuccess, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<QuestionTimelineResponse>("questions", new string[] { questionIds.Vectorize(), "timeline" }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, (items) => onSuccess(items.Events), onError);
        }

        public void GetQuestionTimeline(int questionId, Action<IEnumerable<PostEvent>> onSuccess, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetQuestionTimeline(questionId.ToArray(), onSuccess, onError, fromDate, toDate);
        }

        public void Search(Action<IEnumerable<Question>> onSuccess, Action<ApiException> onError = null, string inTitle = null, IEnumerable<string> tagged = null, IEnumerable<string> notTagged = null, SearchSort sortBy = SearchSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null)
        {
            string taggedString = null;
            if (tagged != null)
                taggedString = String.Join(" ", tagged.ToArray());

            string notTaggedString = null;
            if (notTagged != null)
                notTaggedString = String.Join(" ", notTagged.ToArray());

            MakeRequest<List<Question>>("search", null, new
            {
                key = apiKey,
                intitle = inTitle,
                tagged = taggedString,
                nottagged = notTaggedString,
                sort = sortBy,
                order = GetSortDirection(sortDirection),
                page = page ?? null,
                pagesize = pageSize ?? null
            }, (items) => onSuccess(items), onError);
        }
    }
}