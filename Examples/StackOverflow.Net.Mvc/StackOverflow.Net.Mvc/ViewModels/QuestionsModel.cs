﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackOverflow;

namespace StackOverflow.Net.Mvc
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
            state.MaxPages = Convert.ToInt32(Math.Truncate(Convert.ToDouble(questions.TotalItems / questions.PageSize)));
        }
    }
}