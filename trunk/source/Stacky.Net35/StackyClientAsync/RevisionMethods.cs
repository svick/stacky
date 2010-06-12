using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
#if SILVERLIGHT
    public partial class StackyClient
#else
    public partial class StackyClientAsync
#endif
    {
        public void GetRevisions(IEnumerable<int> ids, Action<IEnumerable<Revision>> onSuccess, Action<ApiException> onError)
        {
            GetRevisions(ids, onSuccess, onError, null, null);
        }

        public void GetRevisions(IEnumerable<int> ids, Action<IEnumerable<Revision>> onSuccess, Action<ApiException> onError, DateTime? fromDate, DateTime? toDate)
        {
            MakeRequest<RevisionResponse>("revisions", new string[] { ids.Vectorize() }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, (items) => onSuccess(items.Revisions), onError);
        }

        public void GetRevisions(int id, Action<IEnumerable<Revision>> onSuccess, Action<ApiException> onError)
        {
            GetRevisions(id, onSuccess, onError, null, null);
        }

        public void GetRevisions(int id, Action<IEnumerable<Revision>> onSuccess, Action<ApiException> onError, DateTime? fromDate, DateTime? toDate)
        {
            GetRevisions(id.ToArray(), onSuccess, onError, fromDate, toDate);
        }

        public void GetRevision(int id, Guid revision, Action<Revision> onSuccess, Action<ApiException> onError)
        {
            MakeRequest<RevisionResponse>("revisions", new string[] { id.ToString(), revision.ToString() }, new
            {
                key = apiKey
            }, returnedItems => onSuccess(returnedItems.Revisions.FirstOrDefault()), onError);
        }
    }
}