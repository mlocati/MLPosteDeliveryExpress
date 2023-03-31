using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class DateISO8601NoSep : JsonConverter<DateOnly>
    {
        private const string FORMAT = @"yyyyMMdd";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateOnly.ParseExact(reader.GetString() ?? "", FORMAT, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(FORMAT, CultureInfo.InvariantCulture));
        }
    }
}