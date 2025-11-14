using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class AnnotatedEnumConverter<TEnum> : JsonConverter<TEnum> where TEnum : Enum
    {
        private static readonly Lazy<Mapper<TEnum>> Map = new(() => new Mapper<TEnum>());

        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetString() ?? throw new InvalidDataException();
            if (Map.Value.StringToEnum.TryGetValue(stringValue, out var enumValue))
            {
                return enumValue;
            }
            throw new System.Collections.Generic.KeyNotFoundException($"The key \"{stringValue}\" is not defined for the type {typeToConvert.FullName}");
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(Map.Value.EnumToString[value]);
        }
    }
}