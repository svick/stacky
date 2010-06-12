using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stacky;

namespace Stacky.Mvc
{
    public class QuestionsModel
    {
        public IPagedList<Question> Questions { get; private set; }
        public SiteState SiteState { get; private set; }

        public QuestionsModel(IPagedList<Question> questions, SiteState state)
        {
            SiteState = state;
            Questions = questions;
            state.Page = Convert.ToInt32(questions.CurrentPage);
            state.ItemCount = questions.TotalItems;
            state.MaxPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(questions.TotalItems) / Convert.ToDouble(questions.PageSize)));
        }
    }
}