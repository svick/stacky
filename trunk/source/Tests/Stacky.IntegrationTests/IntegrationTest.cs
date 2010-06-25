namespace Stacky.IntegrationTests
{
    public abstract class IntegrationTest
    {
        public static string Version = "0.9";
        public static string ApiKey = "LU9IfwI8IEScM3yYAjHimA";

        public IntegrationTest()
        {
            Client = new StackyClient(Version, ApiKey, Sites.StackOverflow, new UrlClient(), new JsonProtocol());
            ClientAsync = new StackyClientAsync(Version, ApiKey, Sites.StackOverflow.ApiEndpoint, new UrlClientAsync(), new JsonProtocol());
            AuthClient = new StackAuthClient(new UrlClient(), new JsonProtocol());
        }

        public StackyClient Client { get; set; }
        public StackyClientAsync ClientAsync { get; set; }
        public StackAuthClient AuthClient { get; set; }
    }
}