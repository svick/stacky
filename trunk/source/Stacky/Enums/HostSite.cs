using System;
using System.Linq;

namespace Stacky
{
    public enum HostSite
    {
        [SiteAddress("api.stackoverflow.com")]
        StackOverflow,
        [SiteAddress("api.superuser.com")]
        SuperUser,
        [SiteAddress("api.serverfault.com")]
        ServerFault,
        [SiteAddress("api.meta.stackoverflow.com")]
        Meta,
        [SiteAddress("api.stackapps.com")]
        StackApps
    }

    public class SiteAddressAttribute : Attribute
    {
        public string Address { get; set; }
        public SiteAddressAttribute(string address)
        {
            Address = address;
        }
    }

    public static class HostSiteExtensions
    {
        public static string GetAddress(this HostSite site)
        {
            var attribute = site.GetAttribute<SiteAddressAttribute>();
            if (attribute != null)
            {
                return attribute.Address;
            }
            return "";
        }
    }
}