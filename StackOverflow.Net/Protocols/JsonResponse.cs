#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

#endregion

namespace StackOverflow
{
    public class JsonResponse : IResponse
    {
        #region IResponse Members

        public ResponseError Error { get; set; }
        public string Method { get; set; }
        public string Body { get; set; }

        #endregion

        public JsonResponse()
        {
        }

        public JsonResponse(string json)
        {
            Parse(json, this);
        }

        protected static void Parse(string json, JsonResponse response)
        {
            using (TextReader tr = new StringReader(json))
            {
                Regex regex = new Regex("{\"([^\"]+)\":(.*)[}\\]]", RegexOptions.Singleline);
                Match match = regex.Match(json);
                string method = match.Groups[1].Value;
                string body = match.Groups[2].Value;

                //if (!String.IsNullOrEmpty(body))
                //{
                //    body = body.Substring(0, body.Length - 1);
                //}

                response.Method = method;
                response.Body = body;
                 
                if (method == "error")
                {
                    response.Error = SerializationHelper.DeserializeJson<ResponseError>(body);
                    return;
                }
            }
        }
    }

    public class JsonResponse<T> : JsonResponse, IResponse<T>
        where T : new()
    {
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
            Parse(json, (JsonResponse)response);
            if (response.Error != null)
                return;

            response.Data = SerializationHelper.DeserializeJson<T>(response.Body);
        }
    }
}
