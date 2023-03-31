using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class UIntNullableAsString : JsonConverter<uint?>
    {
        public override uint? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            return uint.Parse(str, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, uint? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value == null ? "" : value.Value.ToString(CultureInfo.InvariantCulture));
        }
    }
}