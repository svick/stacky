using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace StackOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebClient webClient = new WebClient();
            IProtocol protocol = new JsonProtocol();

            var client = new StackOverflowClient(Config.ServiceVersion, webClient, protocol);
                        
            Console.ReadLine();
        }
    }
}