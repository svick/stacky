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
        public virtual void GetRevisions(IEnumerable<int> ids, Action<IEnumerable<Revision>> onSuccess, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            MakeRequest<RevisionResponse>("revisions", new string[] { ids.Vectorize() }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            }, (items) => onSuccess(items.Revisions), onError);
        }

        public virtual void GetRevisions(int id, Action<IEnumerable<Revision>> onSuccess, Action<ApiException> onError = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            GetRevisions(id.ToArray(), onSuccess, onError, fromDate, toDate);
        }

        public virtual void GetRevision(int id, Guid revision, Action<Revision> onSuccess, Action<ApiException> onError = null)
        {
            MakeRequest<RevisionResponse>("revisions", new string[] { id.ToString(), revision.ToString() }, new
            {
                key = apiKey
            }, returnedItems => onSuccess(returnedItems.Revisions.FirstOrDefault()), onError);
        }
    }
}