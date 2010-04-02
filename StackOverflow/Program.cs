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
            IWebClient client = new WebClient();
            IProtocol protocol = new JsonProtocol();

            var c = new StackOverflowClient("0.5", client, protocol);
            var questions = c.GetUnansweredQuestions(null, null, false, false, null, null, null);

            foreach (Question q in questions)
            {
                Console.WriteLine(q.Title);
                foreach (var tag in q.Tags)
                    Console.WriteLine("\t{0}", tag);
            }

            //var l = GetQuestions();
            //var result = SerializationHelper.SerializeJson(l);
                        
            Console.ReadLine();
        }
    }
}