using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class BooleanT : JsonConverter<bool>
    {
        private const string TRUE = "T";
        private const string FALSE = "";

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