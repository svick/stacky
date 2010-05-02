using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Ninject;

namespace StackOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            IUrlClient webClient = new UrlClient();
            IProtocol protocol = new JsonProtocol();
            string serviceVersion = "0.7";
            string apiKey = "0xDEADBEEF";

            IKernel kernel = new StandardKernel();
            kernel.Bind<IUrlClient>().To<UrlClient>();
            kernel.Bind<IProtocol>().To<JsonProtocol>();
            kernel.Bind<StackOverflowClient>().ToSelf()
                .WithConstructorArgument("version", serviceVersion)
                .WithConstructorArgument("apiKey", apiKey);

            kernel.Bind<IUrlClientAsync>().To<UrlClientAsync>();
            kernel.Bind<StackOverflowClientAsync>().ToSelf()
                .WithConstructorArgument("version", serviceVersion)
                .WithConstructorArgument("apiKey", apiKey);

            var client = kernel.Get<StackOverflowClient>();
            var questions = client.GetQuestions();
            foreach (var question in questions)
            {
                Console.WriteLine(question.Title);
            }

            Console.WriteLine();

            var async = kernel.Get<StackOverflowClientAsync>();
            async.GetQuestions(items =>
                {
                    foreach (var question in items)
                    {
                        Console.WriteLine(question.Title);
                    }
                });
                        
            Console.ReadLine();
        }
    }
}