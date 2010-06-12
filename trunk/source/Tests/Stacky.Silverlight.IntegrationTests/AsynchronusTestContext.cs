using System;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.Silverlight.IntegrationTests
{
    /// <summary>
    /// Helps Ensure Test complete is called
    /// </summary>
    public class AsynchronusTestContext : IDisposable
    {
        private SilverlightTest Test { get; set; }

        public AsynchronusTestContext(SilverlightTest test)
        {
            Test = test;
        }

        public void Dispose()
        {
            Test.EnqueueTestComplete();
        }
    }
}