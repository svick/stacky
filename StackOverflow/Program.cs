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
            //string key = "knockknock";
            IWebClient client = new WebClient();
            IProtocol protocol = new JsonProtocol();


            ////string message = client.MakeRequest(new Uri("http://api.stackoverflow.com/0.5/questions?key=knockknock"));
            ////var response = protocol.GetResponse<List<Question>>(message);

            var c = new StackOverflowClient("0.5", client, protocol);
            var questions = c.GetQuestions();
            var question = c.GetQuestion(questions[0].Id, true);
            Console.WriteLine(question.Body);

            //foreach (Question q in questions)
            //{
            //    Console.WriteLine(q.Title);
            //    foreach (var tag in q.Tags)
            //        Console.WriteLine("\t{0}", tag);
            //}

            //var l = GetQuestions();
            //var result = SerializationHelper.SerializeJson(l);
                        
            Console.ReadLine();
        }
    }
}