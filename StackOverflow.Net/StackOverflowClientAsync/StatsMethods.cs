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
        public void GetSiteStats(Action<SiteStats> callback, Action<ApiException> onError = null)
        {
            MakeRequest<List<SiteStats>>("stats", false, null, new
            {
                key = apiKey
            }, results => callback(results.FirstOrDefault()), onError);
        }
    }
}