using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stacky.Mvc
{
    public class SiteState
    {
        public string SiteUrl { get; private set; }
        public HostSite HostSite { get; private set; }
        public string SiteAction { get; private set; }
        public string SiteController { get; private set; }
        public string Sort { get; private set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int ItemCount { get; set; }
        public int MaxPages { get; set; }
        public string QueryString { get; private set; }

        public SiteState(System.Web.Mvc.UrlHelper url)
        {
            SiteUrl = url.GetHostSiteBaseUrl();
            HostSite = url.GetHostSite();
            SiteAction = url.RequestContext.RouteData.Values["action"].ToString();
            SiteController = url.RequestContext.RouteData.Values["controller"].ToString();
            Sort = url.RequestContext.HttpContext.Request.QueryString["Sort"];

            int tempInt = 0;

            if (int.TryParse(url.RequestContext.HttpContext.Request.QueryString["Page"], out tempInt))
            {
                Page = tempInt;
                if (Page < 1)
                {
                    Page = 1;
                }
            }
            else
            {
                Page = 1;
            }


            if (int.TryParse(url.RequestContext.HttpContext.Request.QueryString["PageSize"], out tempInt))
            {
                PageSize = tempInt;
            }
            else
            {
                PageSize = 30;
            }

            QueryString = url.RequestContext.HttpContext.Request.QueryString.ToString();
        }
    }
}