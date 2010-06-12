using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stacky.Mvc
{
    public class PagerModel
    {
        public List<KeyValuePair<string, string>> PageSelectors { get; private set; }
        public Dictionary<string, string> PageSizes { get; private set; }
        public string CurrentPage { get; private set; }
        public string CurrentPageSize { get; private set; }

        public PagerModel(SiteState state)
        {
            PageSelectors = new List<KeyValuePair<string, string>>();
            PageSizes = new Dictionary<string, string>();

            string url = string.Format("/{0}/{1}/{2}", state.SiteController, state.SiteAction, state.HostSite);
            string queryString = "?";

            if (!string.IsNullOrEmpty(state.Sort))
            {
                queryString = queryString + "Sort=" + state.Sort;
            }

            //before we finish building the URL add the page sizes

            string pageSize = "PageSize=";
            if (queryString.Length != 1) // qs initialized with "?"
            {
                pageSize = "&" + pageSize;
            }

            if (state.SiteController == "Questions" && state.SiteAction != "Question")
            {
                PageSizes.Add("15", url + queryString + pageSize + "15&Page=" + state.Page);
                PageSizes.Add("30", url + queryString + pageSize + "30&Page=" + state.Page);
                PageSizes.Add("50", url + queryString + pageSize + "50&Page=" + state.Page);
            }

            if (state.PageSize != 30)
            {
                queryString = queryString + pageSize + state.PageSize;
            }

            url = url + queryString;

            if (queryString.Length != 1) // qs initialized with "?"
            {
                url = url + "&";
            }

            //TODO A grossly negligent way to make a pager IMO, optimize later - CJ
            //prev selector
            if (state.Page != 1)
            {
                PageSelectors.Add(new KeyValuePair<string, string>("prev", url + "Page=" + (state.Page - 1)));
            }
            
            //page one selector
            PageSelectors.Add(new KeyValuePair<string, string>("1", url + "Page=1"));

            int startPage = 0;
            int endPage = 0;

            //the middle 5
            if (state.Page > 5)
            {
                PageSelectors.Add(new KeyValuePair<string, string>("...", string.Empty));
                if (state.Page >= state.MaxPages - 5)
                {
                    startPage = state.MaxPages - 5;
                    endPage = state.MaxPages - 1;
                }
                else
                {
                    startPage = state.Page - 2;
                    endPage = state.Page + 2;
                }
            }
            else
            {
                startPage = 2;
                endPage = 5;
            }

            if (endPage > state.MaxPages)
            {
                endPage = state.MaxPages;
            }

            for (int idx = 0; idx <= endPage-startPage; idx++)
            {
                PageSelectors.Add(new KeyValuePair<string, string>((startPage + idx).ToString(), url + string.Format("Page={0}", startPage + idx))); 
            }

            if (endPage + 1 < state.MaxPages)
            {
                PageSelectors.Add(new KeyValuePair<string, string>("...", string.Empty));
            }

            //last page selector
            PageSelectors.Add(new KeyValuePair<string, string>(state.MaxPages.ToString(), url + string.Format("Page={0}", state.MaxPages)));
            
            //next selector
            if (state.Page != state.MaxPages)
            {
                PageSelectors.Add(new KeyValuePair<string, string>("next", url + "Page=" + (state.Page + 1)));
            }

            CurrentPage = state.Page.ToString();
            CurrentPageSize = state.PageSize.ToString();
        }
    }
}