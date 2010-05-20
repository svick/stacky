namespace StackOverflow.IntegrationTests
{
    public abstract class IntegrationTest
    {
        private static string version = "0.8";
        private static string apiKey = "";

        public IntegrationTest()
        {
            Client = new StackOverflowClient(version, apiKey, new UrlClient(), new JsonProtocol());
            ClientAsync = new StackOverflowClientAsync(version, apiKey, new UrlClientAsync(), new JsonProtocol());
        }

        public StackOverflowClient Client { get; set; }
        public StackOverflowClientAsync ClientAsync { get; set; }
    }
}