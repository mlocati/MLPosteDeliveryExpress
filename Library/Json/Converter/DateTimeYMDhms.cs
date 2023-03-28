using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class DateTimeYMDhms : JsonConverter<DateTime>
    {
        private const string FORMAT = @"yyyy-MM-dd HH\:mm\:ss";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString() ?? "", FORMAT, CultureInfo.InvariantCulture).ToLocalTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var str = value.ToString(FORMAT, CultureInfo.InvariantCulture);
            writer.WriteStringValue(str);
        }
    }
}