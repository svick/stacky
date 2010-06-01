using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverflow.Net.Mvc.Models;


namespace StackOverflow.Net.Mvc.Controllers
{
    public class QuestionsController : Controller
    {
        public ActionResult Active()
        {
            try
            {
                SiteState state = new SiteState(Url);
                StackOverflowNetRepository repository = new StackOverflowNetRepository(state);
                return View("Questions", new QuestionsModel(repository.GetQuestions(sortBy: QuestionSort.Active, includeBody: true, page: state.Page, pageSize: state.PageSize), state));
            }
            catch (ApiException ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Question", "Active"));
            }
        }

        public ActionResult Questions()
        {
            try
            {
                SiteState state = new SiteState(Url);
                StackOverflowNetRepository repository = new StackOverflowNetRepository(state);

                QuestionSort sort = QuestionSort.Hot;

                switch (state.Sort)
                {
                    case "Newest":
                        sort = QuestionSort.Newest;
                        break;
                    case "Featured":
                        sort = QuestionSort.Featured;
                        break;
                    case "Hot":
                        sort = QuestionSort.Hot;
                        break;
                    case "Votes":
                        sort = QuestionSort.Votes;
                        break;
                    case "Active":
                        sort = QuestionSort.Active;
                        break;
                    default:
                        break;
                }

                return View(new QuestionsModel(repository.GetQuestions(sortBy: sort, includeBody: true, page: state.Page, pageSize: state.PageSize), state));
            }
            catch (ApiException ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Question", "Active"));
            }
        }

        public ActionResult Unanswered()
        {
            try
            {
                SiteState state = new SiteState(Url);
                StackOverflowNetRepository repository = new StackOverflowNetRepository(state);

                QuestionSort sort = QuestionSort.Unanswered;

                switch (state.Sort)
                {
                    case "Newest":
                        sort = QuestionSort.UnansweredNewest;
                        break;
                    case "Votes":
                        sort = QuestionSort.UnansweredVotes;
                        break;
                    default:
                        break;
                }

                return View("Questions", new QuestionsModel(repository.GetQuestions(sortBy: sort, includeBody: true, page: state.Page, pageSize: state.PageSize), state));
            }
            catch (ApiException ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Question", "Active"));
            }
        }

        public ActionResult Tagged(string id)
        {
            try
            {
                SiteState state = new SiteState(Url);
                StackOverflowNetRepository repository = new StackOverflowNetRepository(state);

                return View("Questions", new QuestionsModel(repository.GetQuestions(tags: new string[] { id }, includeBody: true, page: state.Page, pageSize: state.PageSize), state));
            }
            catch (ApiException ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Question", "Active"));
            }
        }

        public ActionResult Question(int id)
        {
            try
            {
                return View();
            }
            catch (ApiException ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Question", "Active"));
            }
        }
    }
}

