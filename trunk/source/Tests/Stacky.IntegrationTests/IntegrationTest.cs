namespace Stacky.IntegrationTests
{
    public abstract class IntegrationTest
    {
        public static string Version = "0.8";
        public static string ApiKey = "";
        public static string BaseUrl = "api.stackoverflow.com";

        public IntegrationTest()
        {
            Client = new StackyClient(Version, ApiKey, HostSite.StackOverflow, new UrlClient(), new JsonProtocol());
            ClientAsync = new StackyClientAsync(Version, ApiKey, BaseUrl, new UrlClientAsync(), new JsonProtocol());
        }

        public StackyClient Client { get; set; }
        public StackyClientAsync ClientAsync { get; set; }
    }
}