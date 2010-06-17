using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    public static class Sites
    {
        public static Site StackOverflow
        {
            get
            {
                return new Site
                {
                    Name = "Stack Overflow",
                    LogoUrl = "http://sstatic.net/so/img/logo.png",
                    ApiEndpoint = "http://api.stackoverflow.com/",
                    SiteUrl = "http://stackoverflow.com",
                    Description = "Member of the StackExchange Network",
                    IconUrl = "http://sstatic.net/so/apple-touch-icon.png"
                };
            }
        }

        public static Site ServerFault
        {
            get
            {
                return new Site
                {
                    Name = "Server Fault",
                    LogoUrl = "http://sstatic.net/sf/img/logo.png",
                    ApiEndpoint = "http://api.serverfault.com/",
                    SiteUrl = "http://serverfault.com",
                    Description = "Member of the StackExchange Network",
                    IconUrl = "http://sstatic.net/sf/apple-touch-icon.png"
                };
            }
        }

        public static Site SuperUser
        {
            get
            {
                return new Site
                {
                    Name = "Super User",
                    LogoUrl = "http://sstatic.net/su/img/logo.png",
                    ApiEndpoint = "http://api.superuser.com/",
                    SiteUrl = "http://superuser.com",
                    Description = "Member of the StackExchange Network",
                    IconUrl = "http://sstatic.net/su/apple-touch-icon.png"
                };
            }
        }

        public static Site StackOverflowMeta
        {
            get
            {
                return new Site
                {
                    Name = "Stack Overflow Meta",
                    LogoUrl = "http://sstatic.net/mso/img/logo.png",
                    ApiEndpoint = "http://api.meta.stackoverflow.com/",
                    SiteUrl = "http://meta.stackoverflow.com",
                    Description = "Member of the StackExchange Network",
                    IconUrl = "http://sstatic.net/mso/apple-touch-icon.png"
                };
            }
        }

        public static Site StackApps
        {
            get
            {
                return new Site
                {
                    Name = "Stack Apps",
                    LogoUrl = "http://sstatic.net/sa/img/logo.png",
                    ApiEndpoint = "http://api.stackapps.com/",
                    SiteUrl = "http://stackapps.com",
                    Description = "Member of the StackExchange Network",
                    IconUrl = "http://sstatic.net/sa/apple-touch-icon.png"
                };
            }
        }
    }
}