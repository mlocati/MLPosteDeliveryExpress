using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class DateTimeISO8601 : JsonConverter<DateTime>
    {
        private const string FORMAT = @"yyyy-MM-ddTHH\:mm\:ss\.fffzzz";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString() ?? "", FORMAT, CultureInfo.InvariantCulture).ToLocalTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToUniversalTime().ToString(FORMAT, CultureInfo.InvariantCulture));
        }
    }
}