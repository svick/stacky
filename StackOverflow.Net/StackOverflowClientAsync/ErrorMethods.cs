using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackOverflow
{
#if SILVERLIGHT
    public partial class StackOverflowClient
#else
    public partial class StackOverflowClientAsync
#endif
    {
        public void GetError(ErrorCode code, Action<ResponseError> callback, Action<ApiException> onError = null)
        {
            MakeRequest<ResponseError>("errors", false, new string[] { ((int)code).ToString() }, new
            {
                key = apiKey
            }, callback, onError);
        }
    }
}