namespace Stacky
{
    /// <summary>
    /// Specifies response error codes.
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Not found.
        /// </summary>
        NotFound = 404,
        /// <summary>
        /// Internal server error.
        /// </summary>
        InternalServerError = 500,
        /// <summary>
        /// Invalid application public key.
        /// </summary>
        InvalidApplicationPublicKey = 4000,
        /// <summary>
        /// Invalid page size.
        /// </summary>
        InvalidPageSize = 4001,
        /// <summary>
        /// Invalid sort type.
        /// </summary>
        InvalidSort = 4002,
        /// <summary>
        /// Invalid ordering.
        /// </summary>
        InvalidOrder = 4003,
        /// <summary>
        /// Request limit exceeded.
        /// </summary>
        RequestLimitExceeded = 4004,
        /// <summary>
        /// Invalid vector format.
        /// </summary>
        InvalidVectorFormat = 4005,
        /// <summary>
        /// Too many ids.
        /// </summary>
        TooManyIds = 4006
    }
}