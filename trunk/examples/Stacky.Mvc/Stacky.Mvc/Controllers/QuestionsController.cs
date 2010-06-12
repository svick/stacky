using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stacky.Mvc.Models;


namespace Stacky.Mvc.Controllers
{
    public class QuestionsController : Controller
    {
        public ActionResult Active()
        {
            try
            {
                SiteState state = new SiteState(Url);
                StackyRepository repository = new StackyRepository(state);
                return View("Questions", new QuestionsModel(repository.GetQuestions(sortBy: QuestionSort.Activity, includeBody: true, page: state.Page, pageSize: state.PageSize), state));
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
                StackyRepository repository = new StackyRepository(state);

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
                        sort = QuestionSort.Activity;
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
                StackyRepository repository = new StackyRepository(state);

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
                StackyRepository repository = new StackyRepository(state);

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
                SiteState state = new SiteState(Url);
                StackyRepository repository = new StackyRepository(state);
                Question question = repository.GetQuestion(id, true, true);
                IPagedList<Answer> answers = null;
                if (state.Page != 1)
                {
                    answers = repository.GetQuestionAnswers(id, page: state.Page, includeBody: true, includeComments: true);
                }

                return View(new QuestionModel(question, answers, state));
            }
            catch (ApiException ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Question", "Active"));
            }
        }
    }
}

