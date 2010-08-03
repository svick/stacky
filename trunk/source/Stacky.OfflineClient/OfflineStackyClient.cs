using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky.OfflineClient
{
    public class OfflineStackyClient : StackyClient
    {
        public OfflineStackyClient(string version, string apiKey, Site site, IUrlClient urlClient, IProtocol protocol)
            : base(version, apiKey, site, urlClient, protocol)
        {
        }
    }
}