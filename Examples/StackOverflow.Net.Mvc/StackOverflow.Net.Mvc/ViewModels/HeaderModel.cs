using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow.Net.Mvc.ViewModels
{
    public class HeaderModel
    {
        public HeaderModel(SiteState state)
        {
            CurrentSite = state.HostSite.ToString();
            SupportedSites = new Dictionary<string,string>();
            NavigationTabs = new Dictionary<string, string>();

            foreach(string supportedSite in Enum.GetNames(typeof(HostSite)))
            {
                SupportedSites.Add(supportedSite, string.Format("/Questions/Active/{0}", supportedSite));
            }

            NavigationTabs.Add("Questions", string.Format("/Questions/Questions/{0}", CurrentSite));
            NavigationTabs.Add("Tags", string.Format("/Tags/Tags/{0}", CurrentSite));
            NavigationTabs.Add("Users", string.Format("/Users/Users/{0}", CurrentSite));
            NavigationTabs.Add("Badges", string.Format("/Badges/Badges/{0}", CurrentSite));
            NavigationTabs.Add("Unanswered", string.Format("/Questions/Unanswered/{0}", CurrentSite));

            if (state.SiteController == "Questions" && state.SiteAction == "Questions")
            {
                CurrentNavigationTab = "Questions";
            }

            if (state.SiteController == "Tags" && state.SiteAction == "Tags")
            {
                CurrentNavigationTab = "Tags";
            }

            if (state.SiteController == "Users" && state.SiteAction == "Users")
            {
                CurrentNavigationTab = "Users";
            }

            if (state.SiteController == "Badges" && state.SiteAction == "Badges")
            {
                CurrentNavigationTab = "Badges";
            }

            if (state.SiteController == "Questions" && state.SiteAction == "Unanswered")
            {
                CurrentNavigationTab = "Unanswered";
            }

        }

        public Dictionary<string, string> SupportedSites { get; private set; }
        public Dictionary<string, string> NavigationTabs { get; private set; }
        public Dictionary<string, string> SubNavigationTabs { get; private set; }
        
        public string CurrentSite { get; set; }
        public string CurrentNavigationTab { get; set; }

    }
}