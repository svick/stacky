namespace StackOverflow.IntegrationTests
{
    public abstract class IntegrationTest
    {
        public static string Version = "0.8";
        public static string ApiKey = "";
        public static string BaseUrl = "api.stackoverflow.com";

        public IntegrationTest()
        {
            Client = new StackOverflowClient(Version, ApiKey, HostSite.StackOverflow, new UrlClient(), new JsonProtocol());
            ClientAsync = new StackOverflowClientAsync(Version, ApiKey, BaseUrl, new UrlClientAsync(), new JsonProtocol());
        }

        public StackOverflowClient Client { get; set; }
        public StackOverflowClientAsync ClientAsync { get; set; }
    }
}