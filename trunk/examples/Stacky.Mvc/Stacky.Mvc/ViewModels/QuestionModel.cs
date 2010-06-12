using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stacky;

namespace Stacky.Mvc
{
    public class QuestionModel
    {
        public Question Question { get; private set; }
        public IPagedList<Answer> Answers { get; private set; }
        public SiteState State { get; private set; }
     
        public QuestionModel(Question question, IPagedList<Answer> answers, SiteState state)
        {
            Question = question;
            Answers = answers;

            state.PageSize = 30; //Will always be 30 for quesions.

            if (answers != null)
            {
                state.Page = Convert.ToInt32(answers.CurrentPage);
                state.ItemCount = answers.TotalItems;
                state.MaxPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(answers.TotalItems) / Convert.ToDouble(state.PageSize)));
            }
            else
            {
                state.Page = 1;
                state.ItemCount = question.AnswerCount;
                state.MaxPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(question.AnswerCount) / Convert.ToDouble(state.PageSize)));
            }

            State = state;
        }
    }
}