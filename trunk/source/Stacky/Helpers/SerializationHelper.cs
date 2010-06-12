#region Using Directives

using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

#endregion

namespace Stacky
{
    public static class SerializationHelper
    {
        public static T DeserializeXml<T>(string xml)
               where T : new()
        {
            XmlSerializer s = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(xml))
            {
                return (T)s.Deserialize(sr);
            }
        }

        public static string SerializeXml<T>(T item)
            where T : new()
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb, CultureInfo.CurrentCulture))
            {
                ser.Serialize(sw, item);
            }
            return sb.ToString();
        }

        public static T DeserializeJson<T>(string json)
              where T : new()
        {
            JsonSerializer ser = new JsonSerializer();

            ser.NullValueHandling = NullValueHandling.Ignore;
            ser.ObjectCreationHandling = ObjectCreationHandling.Replace;
            ser.MissingMemberHandling = MissingMemberHandling.Ignore;
            ser.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            using (StringReader sr = new StringReader(json))
            {
                JsonTextReader reader = new JsonTextReader(sr);
                return (T)ser.Deserialize(reader, typeof(T));
            }
        }

        public static string SerializeJson<T>(T item)
            where T : new()
        {
            JsonSerializer ser = new JsonSerializer();

            ser.NullValueHandling = NullValueHandling.Ignore;
            ser.ObjectCreationHandling = ObjectCreationHandling.Replace;
            ser.MissingMemberHandling = MissingMemberHandling.Ignore;
            ser.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb, CultureInfo.CurrentCulture))
            {
                JsonTextWriter writer = new JsonTextWriter(sw);
                ser.Serialize(sw, item);
            }
            return sb.ToString();
        }
    }
}