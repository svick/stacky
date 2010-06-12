namespace Stacky
{
    public enum ErrorCode
    {
        NotFound = 404,
        InternalServerError = 500,
        InvalidApplicationPublicKey = 4000,
        InvalidPageSize = 4001,
        InvalidSort = 4002,
        InvalidOrder = 4003,
        RequestLimitExceeded = 4004,
        InvalidVectorFormat = 4005,
        TooManyIds = 4006
    }
}