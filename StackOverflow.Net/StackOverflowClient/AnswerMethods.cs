﻿using System.Collections.Generic;

namespace StackOverflow
{
    public partial class StackOverflowClient
    {
        public IEnumerable<Answer> GetUsersAnswers(int userId, QuestionsByUserSort sortBy = QuestionsByUserSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            return GetUsersAnswers(userId.ToArray(), sortBy, sortDirection, page, pageSize, includeBody, includeComments);
        }

        public IEnumerable<Answer> GetUsersAnswers(IEnumerable<int> userIds, QuestionsByUserSort sortBy = QuestionsByUserSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            return MakeRequest<List<Answer>>("users", false, new string[] { userIds.Vectorize(), "answers" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                comments = includeComments ? (bool?)true : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection)
            });
        }

        public IEnumerable<Answer> GetQuestionAnswers(IEnumerable<int> questionIds, QuestionsByUserSort sortBy = QuestionsByUserSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false)
        {
            return MakeRequest<List<Answer>>("questions", false, new string[] { questionIds.Vectorize(), "answers" }, new
            {
                key = apiKey,
                page = page ?? null,
                pagesize = pageSize ?? null,
                body = includeBody ? (bool?)true : null,
                sort = sortBy.ToString().ToLower(),
                order = GetSortDirection(sortDirection)
            });
        }

        public IEnumerable<Answer> GetQuestionAnswers(int questionId, QuestionsByUserSort sortBy = QuestionsByUserSort.Creation, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false)
        {
            return GetQuestionAnswers(questionId.ToArray(), sortBy, sortDirection, page, pageSize, includeBody);
        }
    }
}