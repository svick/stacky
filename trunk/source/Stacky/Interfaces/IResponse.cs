namespace Stacky
{
    public interface IResponse<T>
        where T : new()
    {
        string Body { get; }
        ResponseError Error { get; }
        string Method { get; }
        T Data { get; set; }
    }
}