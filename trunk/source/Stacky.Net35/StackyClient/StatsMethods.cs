using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
    public partial class StackyClient
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