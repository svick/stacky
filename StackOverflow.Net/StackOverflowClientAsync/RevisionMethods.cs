using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackOverflow
{
#if SILVERLIGHT
    public partial class StackOverflowClient
#else
    public partial class StackOverflowClientAsync
#endif
    {
        public void GetRevisions(IEnumerable<int> ids, Action<List<Revision>> callback, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<List<Revision>>("revisions", false, new string[] { ids.Vectorize() }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, callback, onError);
        }

        public void GetRevisions(int id, Action<List<Revision>> callback, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetRevisions(id.ToArray(), callback, onError, fromDate, toDate);
        }

        public void GetRevision(int id, Guid revision, Action<Revision> callback, Action<ApiException> onError = null)
        {
            MakeRequest<List<Revision>>("revisions", false, new string[] { id.ToString(), revision.ToString() }, new
            {
                key = apiKey
            }, returnedItems => callback(returnedItems.FirstOrDefault()), onError);
        }
    }
}