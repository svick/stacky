using System;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflow
{
#if SILVERLIGHT
    public partial class StackOverflowClient
#else
    public partial class StackOverflowClientAsync
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