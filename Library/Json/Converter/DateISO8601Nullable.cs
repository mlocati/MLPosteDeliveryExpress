using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class DateISO8601Nullable : JsonConverter<DateOnly?>
    {
        private const string FORMAT = @"yyyy-MM-dd";

        public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();
            if (string.IsNullOrEmpty(str) || str == "0000-00-00")
            {
                return null;
            }
            return DateOnly.ParseExact(str, FORMAT, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.ToString(FORMAT, CultureInfo.InvariantCulture) ?? "");
        }
    }
}