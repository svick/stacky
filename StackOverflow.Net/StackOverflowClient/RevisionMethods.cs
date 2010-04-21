using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackOverflow
{
    public partial class StackOverflowClient
    {
        public IList<Revision> GetRevisions(IEnumerable<int> ids, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return MakeRequest<List<Revision>>("revisions", false, new string[] { ids.Vectorize() }, new
            {
                key = apiKey,
                fromdate = fromDate.HasValue ? (long?)fromDate.Value.ToUnixTime() : null,
                todate = toDate.HasValue ? (long?)toDate.Value.ToUnixTime() : null
            });
        }

        public IList<Revision> GetRevisions(int id, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return GetRevisions(id.ToArray(), fromDate, toDate);
        }

        public Revision GetRevision(int id, Guid revision)
        {
            return MakeRequest<List<Revision>>("revisions", false, new string[] { id.ToString(), revision.ToString() }, new
            {
                key = apiKey
            }).FirstOrDefault();
        }
    }
}