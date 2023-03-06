using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class TimeHHMMSSNullable : JsonConverter<TimeOnly?>
    {
        private const string FORMAT = @"HH\:mm\:ss";

        public override TimeOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString() ?? "";
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            return TimeOnly.ParseExact(str, FORMAT, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly? value, JsonSerializerOptions options)
        {
            string str;
            if (value == null)
            {
                str = "";
            }
            else
            {
                str = value.Value.ToString(FORMAT, CultureInfo.InvariantCulture);
            }
            writer.WriteStringValue(str);
        }
    }
}