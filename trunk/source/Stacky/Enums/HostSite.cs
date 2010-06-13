using System;
using System.Linq;

namespace Stacky
{
    /// <summary>
    /// Specifies the Stack Overflow API endpoints.
    /// </summary>
    public enum HostSite
    {
        /// <summary>
        /// Stack Overflow.
        /// </summary>
        [SiteAddress("api.stackoverflow.com")]
        StackOverflow,
        /// <summary>
        /// Super User.
        /// </summary>
        [SiteAddress("api.superuser.com")]
        SuperUser,
        /// <summary>
        /// Server Fault.
        /// </summary>
        [SiteAddress("api.serverfault.com")]
        ServerFault,
        /// <summary>
        /// Meta Stack Overflow.
        /// </summary>
        [SiteAddress("api.meta.stackoverflow.com")]
        Meta,
        /// <summary>
        /// Stack Apps.
        /// </summary>
        [SiteAddress("api.stackapps.com")]
        StackApps
    }

    /// <summary>
    /// Specifies a site address.
    /// </summary>
    public class SiteAddressAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteAddressAttribute"/> class.
        /// </summary>
        /// <param name="address">The address.</param>
        public SiteAddressAttribute(string address)
        {
            Address = address;
        }
    }

    /// <summary>
    /// <see cref="HostSite"/> extensions.
    /// </summary>
    public static class HostSiteExtensions
    {
        /// <summary>
        /// Gets the address of the specified <see cref="HostSite"/>.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <returns></returns>
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