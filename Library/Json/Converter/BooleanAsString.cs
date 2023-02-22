using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class BooleanAsString : JsonConverter<bool>
    {
        private const string TRUE = "true";
        private const string FALSE = "false";

        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() switch
            {
                TRUE => true,
                FALSE => false,
                _ => throw new InvalidDataException(),
            };
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value ? TRUE : FALSE);
        }
    }
}