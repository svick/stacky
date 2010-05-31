using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOverflow.Net.Mvc
{
    public class SiteState
    {
        public string SiteUrl { get; private set; }
        public HostSite HostSite { get; private set; }
        public string SiteAction { get; private set; }
        public string SiteController { get; private set; }
        public string Sort { get; private set; }
        public string PageSize { get; private set; }
        public string Page { get; private set; }
        public string TotalPages { get; private set; }
        public string ItemCount { get; private set; }
        public string MaxPages { get; private set; }
        public string QueryString { get; private set; }

        public SiteState(System.Web.Mvc.UrlHelper url)
        {
            SiteUrl = url.GetHostSiteBaseUrl();
            HostSite = url.GetHostSite();
            SiteAction = url.RequestContext.RouteData.Values["action"].ToString();
            SiteController = url.RequestContext.RouteData.Values["controller"].ToString();
            Sort = url.RequestContext.HttpContext.Request.QueryString["Sort"];
            PageSize = url.RequestContext.HttpContext.Request.QueryString["PageSize"];
            Page = url.RequestContext.HttpContext.Request.QueryString["Page"];
            TotalPages = url.RequestContext.HttpContext.Request.QueryString["TotalPages"];
            QueryString = url.RequestContext.HttpContext.Request.QueryString.ToString();
        }

        public SiteState(System.Web.Mvc.UrlHelper url, Response response)
            : this(url)
        {
            MaxPages = Math.Truncate(Convert.ToDouble(response.PageSize / Convert.ToInt32(PageSize))).ToString();
        }
    }
}