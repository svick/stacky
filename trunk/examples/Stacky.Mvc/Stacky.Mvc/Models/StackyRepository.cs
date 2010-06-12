using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Stacky.Mvc.Models
{
    public class StackyRepository
    {
        private string _apiVersion = string.Empty;
        private string _apiKey = string.Empty;
        IUrlClient _urlClient = null;
        IProtocol _protocol = null;
        StackyClient _client = null;

        private StackyRepository()
        {
            _apiVersion = ConfigurationManager.AppSettings["StackOverflow.Net.ApiVersion"];
            _apiKey = ConfigurationManager.AppSettings["StackOverflow.Net.ApiKey"];
            _urlClient = new UrlClient();
            _protocol = new JsonProtocol();
        }

        public StackyRepository(SiteState state) : this()
        {
            _client = new StackyClient(_apiVersion, _apiKey, state.HostSite, _urlClient, _protocol);
        }

        public IPagedList<Question> GetQuestions(QuestionSort sortBy = QuestionSort.Activity, SortDirection sortDirection = SortDirection.Descending, int? page = null, int? pageSize = null, bool includeBody = false, bool includeComments = false, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
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