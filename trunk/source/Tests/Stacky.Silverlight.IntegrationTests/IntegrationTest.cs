using Microsoft.Silverlight.Testing;

namespace Stacky.Silverlight.IntegrationTests
{
    public abstract class IntegrationTest : SilverlightTest
    {
        public static string Version = "0.8";
        public static string ApiKey = "";
        public static string BaseUrl = "api.stackoverflow.com";
        protected static HostSite hostSite = HostSite.StackOverflow;
        protected static IUrlClient urlClient = new UrlClient();
        protected static IProtocol protocol = new JsonProtocol();

        protected StackyClient Client { get; private set; }

        public IntegrationTest()
        {
            Client = new StackyClient(Version, ApiKey, hostSite, urlClient, protocol);
        }
    }
}