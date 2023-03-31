using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class DateTimeYMDhms : JsonConverter<DateTime>
    {
        private static readonly Lazy<TimeZoneInfo> SerializedTimezone = new(() => DateTimeYMDhms.GetSourceTimezone());

        private const string FORMAT = @"yyyy-MM-dd HH\:mm\:ss";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonDateTime = reader.GetString() ?? "";
            var serializedDateTime = DateTime.ParseExact(jsonDateTime, FORMAT, CultureInfo.InvariantCulture);
            return TimeZoneInfo.ConvertTimeToUtc(serializedDateTime, DateTimeYMDhms.SerializedTimezone.Value).ToLocalTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var serializedDateTime = TimeZoneInfo.ConvertTimeFromUtc(value.ToUniversalTime(), DateTimeYMDhms.SerializedTimezone.Value);
            var str = serializedDateTime.ToString(FORMAT, CultureInfo.InvariantCulture);
            writer.WriteStringValue(str);
        }

        private static TimeZoneInfo GetSourceTimezone()
        {
            try
            {
                return TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            }
            catch { }
            try
            {
                return TimeZoneInfo.FindSystemTimeZoneById("Europe/Rome");
            }
            catch { }
            return TimeZoneInfo.Local;
        }
    }
}