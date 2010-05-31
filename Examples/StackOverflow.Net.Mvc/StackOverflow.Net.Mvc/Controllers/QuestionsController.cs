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
            StackOverflowNetRepository repository = new StackOverflowNetRepository(state);
            return View(repository.GetQuestions(sortBy: QuestionSort.Hot, includeBody: true));
        }

        public ActionResult Unanswered()
        {
            SiteState state = new SiteState(Url);
            StackOverflowNetRepository repository = new StackOverflowNetRepository(state);
            return View("Questions", repository.GetQuestions(sortBy: QuestionSort.Unanswered, includeBody: true));
        }

        public ActionResult Tagged(string id)
        {
            SiteState state = new SiteState(Url);
            StackOverflowNetRepository repository = new StackOverflowNetRepository(state);
            return View("Questions", repository.GetQuestions(tags: new string[] { id }, includeBody: true));
        }
    }
}

