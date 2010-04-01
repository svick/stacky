namespace StackOverflow
{
    public interface IResponse
    {
        string Body { get; }
        ResponseError Error { get; }
        string Method { get; }
    }

    public interface IResponse<T> : IResponse
        where T : new()
    {
        T Data { get; set; }
    }
}