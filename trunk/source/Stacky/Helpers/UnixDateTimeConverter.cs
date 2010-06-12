using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Stacky
{
    public class UnixDateTimeConverter : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.Integer)
                throw new Exception("Wrong Token Type");

            long ticks = (long)reader.Value;
            return ticks.FromUnixTime();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            long val;
            if (value is DateTime)
            {
                DateTime dateTime = (DateTime)value;
                val = dateTime.ToUnixTime();
            }
            else
            {
                throw new Exception("Expected date object value.");
            }
            writer.WriteValue(val);
        }
    }
}