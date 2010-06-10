using Microsoft.Silverlight.Testing;

namespace StackOverflow.Net.Silverlight.IntegrationTests
{
    public abstract class IntegrationTest : SilverlightTest
    {
        public static string Version = "0.8";
        public static string ApiKey = "";
        public static string BaseUrl = "api.stackoverflow.com";
        protected static HostSite hostSite = HostSite.StackOverflow;
        protected static IUrlClient urlClient = new UrlClient();
        protected static IProtocol protocol = new JsonProtocol();

        protected StackOverflowClient Client { get; private set; }

        public IntegrationTest()
        {
            Client = new StackOverflowClient(Version, ApiKey, hostSite, urlClient, protocol);
        }
    }
}