using System.Collections.Generic;
using System.Linq;

namespace StackOverflow
{
    public partial class StackOverflowClient
    {
        public virtual SiteStats GetSiteStats()
        {
            return MakeRequest<StatsResponse>("stats", null, new
            {
                key = apiKey
            }).Statistics.FirstOrDefault();
        }
    }
}