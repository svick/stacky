namespace Stacky
{
    public interface IProtocol
    {
        IResponse<T> GetResponse<T>(string message) where T : new();
    }
}