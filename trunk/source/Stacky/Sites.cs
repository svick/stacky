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
                    LogoUrl = "http://sstatic.net/stackoverflow/img/logo.png",
                    ApiEndpoint = "http://api.stackoverflow.com",
                    SiteUrl = "http://stackoverflow.com",
                    Description = "Q&A for professional and enthusiast programmers",
                    IconUrl = "http://sstatic.net/stackoverflow/img/apple-touch-icon.png",
                    State = SiteState.Normal
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
                    LogoUrl = "http://sstatic.net/serverfault/img/logo.png",
                    ApiEndpoint = "http://api.serverfault.com",
                    SiteUrl = "http://serverfault.com",
                    Description = "Q&A for system administrators and IT professionals",
                    IconUrl = "http://sstatic.net/serverfault/img/apple-touch-icon.png",
                    State = SiteState.Normal
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
                    LogoUrl = "http://sstatic.net/superuser/img/logo.png",
                    ApiEndpoint = "http://api.superuser.com",
                    SiteUrl = "http://superuser.com",
                    Description = "Q&A for computer enthusiasts and power users",
                    IconUrl = "http://sstatic.net/superuser/img/apple-touch-icon.png",
                    State = SiteState.Normal
                };
            }
        }

        public static Site MetaStackOverflow
        {
            get
            {
                return new Site
                {
                    Name = "Meta Stack Overflow",
                    LogoUrl = "http://sstatic.net/stackoverflowmeta/img/logo.png",
                    ApiEndpoint = "http://api.meta.stackoverflow.com",
                    SiteUrl = "http://meta.stackoverflow.com",
                    Description = "Q&A about the Stack Exchange engine powering these sites",
                    IconUrl = "http://sstatic.net/stackoverflowmeta/img/apple-touch-icon.png",
                    State = SiteState.Normal
                };
            }
        }

        public static Site WebApps
        {
            get
            {
                return new Site
                {
                    Name = "Web Apps",
                    LogoUrl = "http://sstatic.net/webapps/logo.png",
                    ApiEndpoint = "http://api.webapps.stackexchange.com",
                    SiteUrl = "http://webapps.stackexchange.com",
                    Description = "Q&A for power users of web applications",
                    IconUrl = "http://sstatic.net/skins/sketchy/img/apple-touch-icon.png",
                    State = SiteState.Open_Beta
                };
            }
        }

        public static Site WebAppsMeta
        {
            get
            {
                return new Site
                {
                    Name = "Web Apps Meta",
                    LogoUrl = "http://sstatic.net/webappsmeta/logo.png",
                    ApiEndpoint = "http://api.meta.webapps.stackexchange.com",
                    SiteUrl = "http://meta.webapps.stackexchange.com",
                    Description = "Q&A about the Web Apps site",
                    IconUrl = "http://sstatic.net/skins/sketchymeta/img/apple-touch-icon.png",
                    State = SiteState.Linked_Meta
                };
            }
        }

        public static Site Gaming
        {
            get
            {
                return new Site
                {
                    Name = "Gaming",
                    LogoUrl = "http://sstatic.net/gaming/logo.png",
                    ApiEndpoint = "http://api.gaming.stackexchange.com",
                    SiteUrl = "http://gaming.stackexchange.com",
                    Description = "Q&A for passionate videogamers on all platforms",
                    IconUrl = "http://sstatic.net/skins/sketchy/img/apple-touch-icon.png",
                    State = SiteState.Open_Beta
                };
            }
        }

        public static Site GamingMeta
        {
            get
            {
                return new Site
                {
                    Name = "Gaming Meta",
                    LogoUrl = "http://sstatic.net/gamingmeta/logo.png",
                    ApiEndpoint = "http://api.meta.gaming.stackexchange.com",
                    SiteUrl = "http://meta.gaming.stackexchange.com",
                    Description = "Q&A about the Gaming site",
                    IconUrl = "http://sstatic.net/skins/sketchymeta/img/apple-touch-icon.png",
                    State = SiteState.Linked_Meta
                };
            }
        }

        public static Site Webmasters
        {
            get
            {
                return new Site
                {
                    Name = "Webmasters",
                    LogoUrl = "http://sstatic.net/gaming/logo.png",
                    ApiEndpoint = "http://api.webmasters.stackexchange.com",
                    SiteUrl = "http://webmasters.stackexchange.com",
                    Description = "Q&A for pro webmasters",
                    IconUrl = "http://sstatic.net/skins/sketchy/img/apple-touch-icon.png",
                    State = SiteState.Open_Beta
                };
            }
        }

        public static Site WebmastersMeta
        {
            get
            {
                return new Site
                {
                    Name = "Webmasters Meta",
                    LogoUrl = "http://sstatic.net/webmastersmeta/logo.png",
                    ApiEndpoint = "http://api.meta.webmasters.stackexchange.com",
                    SiteUrl = "http://meta.webmasters.stackexchange.com",
                    Description = "Q&A about the pro webmasters site",
                    IconUrl = "http://sstatic.net/skins/sketchymeta/img/apple-touch-icon.png",
                    State = SiteState.Linked_Meta
                };
            }
        }

        public static Site Cooking
        {
            get
            {
                return new Site
                {
                    Name = "Cooking",
                    LogoUrl = "http://sstatic.net/cooking/logo.png",
                    ApiEndpoint = "http://api.cooking.stackexchange.com",
                    SiteUrl = "http://cooking.stackexchange.com",
                    Description = "Q&A for food and cooking",
                    IconUrl = "http://sstatic.net/skins/sketchy/img/apple-touch-icon.png",
                    State = SiteState.Open_Beta
                };
            }
        }

        public static Site CookingMeta
        {
            get
            {
                return new Site
                {
                    Name = "Cooking Meta",
                    LogoUrl = "http://sstatic.net/cookingmeta/logo.png",
                    ApiEndpoint = "http://api.meta.cooking.stackexchange.com",
                    SiteUrl = "http://meta.cooking.stackexchange.com",
                    Description = "Q&A about the cooking site",
                    IconUrl = "http://sstatic.net/skins/sketchymeta/img/apple-touch-icon.png",
                    State = SiteState.Linked_Meta
                };
            }
        }

        public static Site GameDevelopers
        {
            get
            {
                return new Site
                {
                    Name = "Game Developers",
                    LogoUrl = "http://sstatic.net/gamedev/logo.png",
                    ApiEndpoint = "http://api.gamedev.stackexchange.com",
                    SiteUrl = "http://gamedev.stackexchange.com",
                    Description = "Q&A for game developers",
                    IconUrl = "http://sstatic.net/skins/sketchy/img/apple-touch-icon.png",
                    State = SiteState.Open_Beta
                };
            }
        }

        public static Site GameDevelopersMeta
        {
            get
            {
                return new Site
                {
                    Name = "Game Developers Meta",
                    LogoUrl = "http://sstatic.net/gamedevmeta/logo.png",
                    ApiEndpoint = "http://api.meta.gamedev.stackexchange.com",
                    SiteUrl = "http://meta.gamedev.stackexchange.com",
                    Description = "Q&A about the game developers site",
                    IconUrl = "http://sstatic.net/skins/sketchymeta/img/apple-touch-icon.png",
                    State = SiteState.Linked_Meta
                };
            }
        }

        public static Site ElectronicGadgets
        {
            get
            {
                return new Site
                {
                    Name = "Electronic Gadgets",
                    LogoUrl = "http://sstatic.net/gadgets/logo.png",
                    ApiEndpoint = "http://api.gadgets.stackexchange.com",
                    SiteUrl = "http://gadgets.stackexchange.com",
                    Description = "Q&A for electronic gadgets",
                    IconUrl = "http://sstatic.net/skins/sketchy/img/apple-touch-icon.png",
                    State = SiteState.Open_Beta
                };
            }
        }

        public static Site ElectronicGadgetsMeta
        {
            get
            {
                return new Site
                {
                    Name = "Electronic Gadgets Meta",
                    LogoUrl = "http://sstatic.net/gadgetsmeta/logo.png",
                    ApiEndpoint = "http://api.meta.gadgets.stackexchange.com",
                    SiteUrl = "http://meta.gadgets.stackexchange.com",
                    Description = "Q&A about the electronic gadgets site",
                    IconUrl = "http://sstatic.net/skins/sketchymeta/img/apple-touch-icon.png",
                    State = SiteState.Linked_Meta
                };
            }
        }

        public static Site Photography
        {
            get
            {
                return new Site
                {
                    Name = "Photography",
                    LogoUrl = "http://sstatic.net/photo/img/logo.png",
                    ApiEndpoint = "http://api.photo.stackexchange.com",
                    SiteUrl = "http://photo.stackexchange.com",
                    Description = "Q&A for photography ",
                    IconUrl = "http://sstatic.net/skins/sketchy/img/apple-touch-icon.png",
                    State = SiteState.Open_Beta
                };
            }
        }

        public static Site PhotographyMeta
        {
            get
            {
                return new Site
                {
                    Name = "Photography Meta",
                    LogoUrl = "http://sstatic.net/photometa/img/logo.png",
                    ApiEndpoint = "http://api.meta.photo.stackexchange.com",
                    SiteUrl = "http://meta.photo.stackexchange.com",
                    Description = "Q&A about the photography site",
                    IconUrl = "http://sstatic.net/skins/sketchymeta/img/apple-touch-icon.png",
                    State = SiteState.Linked_Meta
                };
            }
        }

        public static Site StatisticalAnalysis
        {
            get
            {
                return new Site
                {
                    Name = "Statistical Analysis",
                    LogoUrl = "http://sstatic.net/stats/img/logo.png",
                    ApiEndpoint = "http://api.stats.stackexchange.com",
                    SiteUrl = "http://stats.stackexchange.com",
                    Description = "Q&A for statistical analysis",
                    IconUrl = "http://sstatic.net/skins/sketchy/img/apple-touch-icon.png",
                    State = SiteState.Open_Beta
                };
            }
        }

        public static Site StatisticalAnalysisMeta
        {
            get
            {
                return new Site
                {
                    Name = "Statistical Analysis Meta",
                    LogoUrl = "http://sstatic.net/statsmeta/img/logo.png",
                    ApiEndpoint = "http://api.meta.stats.stackexchange.com",
                    SiteUrl = "http://meta.stats.stackexchange.com",
                    Description = "Q&A about the statistical analysis site",
                    IconUrl = "http://sstatic.net/skins/sketchymeta/img/apple-touch-icon.png",
                    State = SiteState.Linked_Meta
                };
            }
        }

        public static Site Mathematics
        {
            get
            {
                return new Site
                {
                    Name = "Mathematics",
                    LogoUrl = "http://sstatic.net/math/img/logo.png",
                    ApiEndpoint = "http://api.math.stackexchange.com",
                    SiteUrl = "http://math.stackexchange.com",
                    Description = "Q&A for mathematics",
                    IconUrl = "http://sstatic.net/skins/sketchy/img/apple-touch-icon.png",
                    State = SiteState.Open_Beta
                };
            }
        }

        public static Site MathematicsMeta
        {
            get
            {
                return new Site
                {
                    Name = "Mathematics Meta",
                    LogoUrl = "http://sstatic.net/statsmeta/img/logo.png",
                    ApiEndpoint = "http://api.meta.math.stackexchange.com",
                    SiteUrl = "http://meta.math.stackexchange.com",
                    Description = "Q&A about the mathematics site",
                    IconUrl = "http://sstatic.net/skins/sketchymeta/img/apple-touch-icon.png",
                    State = SiteState.Linked_Meta
                };
            }
        }

        public static Site HomeImprovement
        {
            get
            {
                return new Site
                {
                    Name = "Home Improvement",
                    LogoUrl = "http://sstatic.net/diy/img/logo.png",
                    ApiEndpoint = "http://api.diy.stackexchange.com",
                    SiteUrl = "http://diy.stackexchange.com",
                    Description = "Q&A for home improvement",
                    IconUrl = "http://sstatic.net/skins/sketchy/img/apple-touch-icon.png",
                    State = SiteState.Open_Beta
                };
            }
        }

        public static Site HomeImprovementMeta
        {
            get
            {
                return new Site
                {
                    Name = "Home Improvement Meta",
                    LogoUrl = "http://sstatic.net/diymeta/img/logo.png",
                    ApiEndpoint = "http://api.meta.diy.stackexchange.com",
                    SiteUrl = "http://meta.diy.stackexchange.com",
                    Description = "Q&A about the home improvement site",
                    IconUrl = "http://sstatic.net/skins/sketchymeta/img/apple-touch-icon.png",
                    State = SiteState.Linked_Meta
                };
            }
        }

        public static Site MetaSuperUser
        {
            get
            {
                return new Site
                {
                    Name = "Meta Super User",
                    LogoUrl = "http://sstatic.net/superusermeta/img/logo.png",
                    ApiEndpoint = "http://api.meta.superuser.com",
                    SiteUrl = "http://meta.superuser.com",
                    Description = "Q&A about the computer enthusiasts and power users site",
                    IconUrl = "http://sstatic.net/superusermeta/img/apple-touch-icon.png",
                    State = SiteState.Linked_Meta
                };
            }
        }

        public static Site MetaServerFault
        {
            get
            {
                return new Site
                {
                    Name = "Meta Server Fault",
                    LogoUrl = "http://sstatic.net/serverfaultmeta/img/logo.png",
                    ApiEndpoint = "http://api.meta.serverfault.com",
                    SiteUrl = "http://meta.serverfault.com",
                    Description = "Q&A about the system administrators and IT professionals site",
                    IconUrl = "http://sstatic.net/serverfaultmeta/img/apple-touch-icon.png",
                    State = SiteState.Linked_Meta
                };
            }
        }

        public static Site GIS
        {
            get
            {
                return new Site
                {
                    Name = "GIS",
                    LogoUrl = "http://sstatic.net/gis/img/logo.png",
                    ApiEndpoint = "http://api.gis.stackexchange.com",
                    SiteUrl = "http://gis.stackexchange.com",
                    Description = "Q&A for geographic information systems",
                    IconUrl = "http://sstatic.net/skins/sketchy/img/apple-touch-icon.png",
                    State = SiteState.Open_Beta
                };
            }
        }

        public static Site GISMeta
        {
            get
            {
                return new Site
                {
                    Name = "GIS Meta",
                    LogoUrl = "http://sstatic.net/gismeta/img/logo.png",
                    ApiEndpoint = "http://api.meta.gis.stackexchange.com",
                    SiteUrl = "http://meta.gis.stackexchange.com",
                    Description = "Q&A about the geographic information systems site",
                    IconUrl = "http://sstatic.net/skins/sketchymeta/img/apple-touch-icon.png",
                    State = SiteState.Linked_Meta
                };
            }
        }

        public static Site TeXLaTeX
        {
            get
            {
                return new Site
                {
                    Name = "TeX - LaTeX",
                    LogoUrl = "http://sstatic.net/tex/img/logo.png",
                    ApiEndpoint = "http://api.tex.stackexchange.com",
                    SiteUrl = "http://tex.stackexchange.com",
                    Description = "Q&A site for expert users of TeX, LaTeX and other related typesetting systems",
                    IconUrl = "http://sstatic.net/skins/sketchy/img/apple-touch-icon.png",
                    State = SiteState.Closed_Beta
                };
            }
        }

        public static Site TeXLaTeXMeta
        {
            get
            {
                return new Site
                {
                    Name = "TeX - LaTeX Meta",
                    LogoUrl = "http://sstatic.net/texmeta/img/logo.png",
                    ApiEndpoint = "http://api.meta.tex.stackexchange.com",
                    SiteUrl = "http://meta.tex.stackexchange.com",
                    Description = "Q&A about the site for expert users of TeX, LaTeX and other related typesetting systems",
                    IconUrl = "http://sstatic.net/skins/sketchymeta/img/apple-touch-icon.png",
                    State = SiteState.Linked_Meta
                };
            }
        }

        public static Site Ubuntu
        {
            get
            {
                return new Site
                {
                    Name = "Ubuntu",
                    LogoUrl = "http://sstatic.net/ubuntu/img/logo.png",
                    ApiEndpoint = "http://api.ubuntu.stackexchange.com",
                    SiteUrl = "http://ubuntu.stackexchange.com",
                    Description = "Q&A site for Ubuntu users and developers",
                    IconUrl = "http://sstatic.net/skins/sketchy/img/apple-touch-icon.png",
                    State = SiteState.Closed_Beta
                };
            }
        }

        public static Site UbuntuMeta
        {
            get
            {
                return new Site
                {
                    Name = "Ubuntu Meta",
                    LogoUrl = "http://sstatic.net/ubuntumeta/img/logo.png",
                    ApiEndpoint = "http://api.meta.ubuntu.stackexchange.com",
                    SiteUrl = "http://meta.ubuntu.stackexchange.com",
                    Description = "Q&A about the site for Ubuntu users and developers",
                    IconUrl = "http://sstatic.net/skins/sketchymeta/img/apple-touch-icon.png",
                    State = SiteState.Linked_Meta
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
                    LogoUrl = "http://sstatic.net/stackapps/img/logo.png",
                    ApiEndpoint = "http://api.stackapps.com",
                    SiteUrl = "http://stackapps.com",
                    Description = "Q&A about apps for and development with the Stack Exchange API",
                    IconUrl = "http://sstatic.net/stackapps/img/apple-touch-icon.png",
                    State = SiteState.Normal
                };
            }
        }

    }
}