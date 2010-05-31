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
            SiteState state = new SiteState(Url);
            StackOverflowNetRepository repository = new StackOverflowNetRepository(state);
            return View("Questions", repository.GetQuestions(sortBy: QuestionSort.Active, includeBody: true));
        }

        public ActionResult Questions()
        {
            SiteState state = new SiteState(Url);
            QuestionSort sort = QuestionSort.Hot;
            StackOverflowNetRepository repository = new StackOverflowNetRepository(state);

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

            return View(repository.GetQuestions(sortBy: sort, includeBody: true));
        }

        public ActionResult Unanswered()
        {
            SiteState state = new SiteState(Url);
            QuestionSort sort = QuestionSort.Unanswered;
            StackOverflowNetRepository repository = new StackOverflowNetRepository(state);
            
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
            
            return View("Questions", repository.GetQuestions(sortBy: sort, includeBody: true));
        }

        public ActionResult Tagged(string id)
        {
            SiteState state = new SiteState(Url);
            StackOverflowNetRepository repository = new StackOverflowNetRepository(state);
            return View("Questions", repository.GetQuestions(tags: new string[] { id }, includeBody: true));
        }

        public ActionResult Question(int id)
        {
            return View();
        }
    }
}

