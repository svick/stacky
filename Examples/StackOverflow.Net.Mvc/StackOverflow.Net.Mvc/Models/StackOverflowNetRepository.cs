using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

using StackOverflow.Net;

namespace StackOverflow.Net.Mvc.Models
{
    public class StackOverflowNetRepository
    {
        private string _apiVersion = string.Empty;
        private string _apiKey = string.Empty;
        IUrlClient _urlClient = null;
        IProtocol _protocol = null;
        StackOverflowClient _client = null;

        private StackOverflowNetRepository()
        {
            _apiVersion = ConfigurationManager.AppSettings["StackOverflow.Net.ApiVersion"];
            _apiKey = ConfigurationManager.AppSettings["StackOverflow.Net.ApiKey"];
            _urlClient = new UrlClient();
            _protocol = new JsonProtocol();
        }

        public StackOverflowNetRepository(SiteState state) : this()
        {
            _client = new StackOverflowClient(_apiVersion, _apiKey, state.HostSite, _urlClient, _protocol);
        }

        public IPagedList<Question> GetQuestions(QuestionSort sortBy = QuestionSort.Active, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            return _client.GetQuestions(sortBy: sortBy, sortDirection: sortDirection, page: page, pageSize: pageSize, includeBody: includeBody, includeComments: includeComments, fromDate: fromDate, toDate: toDate, tags: tags);
        }

        public Question GetQuestion(int questionId, bool includeBody, bool includeComments)
        {
            return _client.GetQuestion(questionId, includeBody, includeComments);
        }

        public IPagedList<Answer> GetQuestionAnswers(int questionId, QuestionsByUserSort sortBy = QuestionsByUserSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, int? min = null, int? max = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return _client.GetQuestionAnswers(questionId, sortBy,  sortDirection, page, pageSize, includeBody, includeComments, min, max, fromDate, toDate);
        }
    }
}