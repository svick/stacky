namespace StackOverflow.IntegrationTests
{
    public abstract class IntegrationTest
    {
        private static string version = "0.8";
        private static string apiKey = "";
        private static string baseUrl = "api.stackoverflow.com";

        public IntegrationTest()
        {
            Client = new StackOverflowClient(version, apiKey, HostSite.StackOverflow, new UrlClient(), new JsonProtocol());
            ClientAsync = new StackOverflowClientAsync(version, apiKey, baseUrl, new UrlClientAsync(), new JsonProtocol());
        }

        public StackOverflowClient Client { get; set; }
        public StackOverflowClientAsync ClientAsync { get; set; }
    }
}