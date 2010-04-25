using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackOverflow
{
    public partial class StackOverflowClient
    {
        public ResponseError GetError(ErrorCode code)
        {
            return MakeRequest<ResponseError>("errors", false, new string[] { ((int)code).ToString() }, new
            {
                key = apiKey
            });
        }
    }
}