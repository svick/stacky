using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        public void GetSiteStats(Action<SiteStats> onSuccess, Action<ApiException> onError = null)
        {
            MakeRequest<StatsResponse>("stats", null, new
            {
                key = apiKey
            }, results => onSuccess(results.Statistics.FirstOrDefault()), onError);
        }
    }
}