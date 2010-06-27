using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stacky;

namespace GenerateSites
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new StackAuthClient(new UrlClient(), new JsonProtocol());
            var sites = client.GetSites();
            foreach (var site in sites)
            {
            }
        }
    }
}