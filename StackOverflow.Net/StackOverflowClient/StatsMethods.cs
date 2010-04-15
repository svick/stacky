using System.Collections.Generic;
using System.Linq;

namespace StackOverflow
{
    public partial class StackOverflowClient
    {
        public SiteStats GetSiteStats()
        {
            return MakeRequest<List<SiteStats>>("stats", false, null, new
            {
                key = apiKey
            }).FirstOrDefault();
        }
    }
}