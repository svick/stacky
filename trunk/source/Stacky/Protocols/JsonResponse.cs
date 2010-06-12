#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

#endregion

namespace Stacky
{
    public class JsonResponse<T> : IResponse<T>
        where T : new()
    {
        public ResponseError Error { get; set; }
        public string Method { get; set; }
        public string Body { get; set; }

        public T Data { get; set; }

        public JsonResponse()
        {
        }

        public JsonResponse(string json)
        {
            Parse(json, this);
        }

        protected static void Parse<T>(string json, JsonResponse<T> response)
           where T : new()
        {
            response.Body = json;
            if (json.Contains("\"error\":"))
            {

                response.Error = SerializationHelper.DeserializeJson<ErrorResponse>(json).Error;
                return;
            }
            response.Data = SerializationHelper.DeserializeJson<T>(json);
        }
    }
}