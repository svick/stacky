using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stacky.Mvc
{
    public static class UrlHelperExtensions
    {
        public static HostSite GetHostSite(this System.Web.Mvc.UrlHelper url)
        {
            try
            {
                return (HostSite)Enum.Parse(typeof(HostSite), url.RequestContext.RouteData.Values["api"].ToString());
            }
            catch
            {
                return HostSite.StackOverflow;
            }
        }

        public static string GetHostSiteBaseUrl(this System.Web.Mvc.UrlHelper url)
        {
            HostSite site = url.GetHostSite();
            string address = site.GetAddress();
            if (!string.IsNullOrEmpty(address))
            {
                return "http://" + address.Replace("api.", string.Empty);
            }
            return string.Empty;
        }
    }
}