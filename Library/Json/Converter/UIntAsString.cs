using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class UIntAsString : JsonConverter<uint>
    {
        public override uint Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return uint.Parse(reader.GetString() ?? "", CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, uint value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("N0", CultureInfo.InvariantCulture));
        }
    }
}