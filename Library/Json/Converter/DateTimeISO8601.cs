using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class DateTimeISO8601 : JsonConverter<DateTime>
    {
        private const string FORMAT = @"yyyy-MM-ddTHH\:mm\:ss\.fffzzz";

        private static readonly Lazy<Regex> RxColonAdder = new(() => new Regex("([0-9])([0-9][0-9])$", RegexOptions.CultureInvariant | RegexOptions.Compiled));

        private static readonly Lazy<Regex> RxColonRemover = new(() => new Regex(":([0-9][0-9])$", RegexOptions.CultureInvariant | RegexOptions.Compiled));

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = DateTimeISO8601.RxColonAdder.Value.Replace(reader.GetString() ?? "", "$1:$2", 1);
            return DateTime.ParseExact(str, FORMAT, CultureInfo.InvariantCulture).ToLocalTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var str = value.ToUniversalTime().ToString(FORMAT, CultureInfo.InvariantCulture);
            str = DateTimeISO8601.RxColonRemover.Value.Replace(str, "$1");
            writer.WriteStringValue(str);
        }
    }
}