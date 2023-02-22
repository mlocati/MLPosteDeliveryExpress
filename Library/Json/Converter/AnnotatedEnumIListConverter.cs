using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class AnnotatedEnumIListConverter<TEnum> : JsonConverter<IList<TEnum>> where TEnum : Enum
    {
        private static readonly Lazy<Mapper<TEnum>> Map = new(() => new Mapper<TEnum>());

        public override IList<TEnum>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Null:
                    return null;

                case JsonTokenType.StartArray:
                    break;

                default:
                    throw new InvalidDataException();
            }
            if (!reader.Read())
            {
                throw new InvalidDataException();
            }
            List<TEnum> result = new();
            var stringToEnum = Map.Value.StringToEnum;
            for (; ; )
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    return result;
                }
                var token = reader.GetString() ?? throw new InvalidDataException();
                result.Add(stringToEnum[token]);
                if (!reader.Read())
                {
                    throw new InvalidDataException();
                }
            }
        }

        public override void Write(Utf8JsonWriter writer, IList<TEnum> value, JsonSerializerOptions options)
        {
            var enumToString = Map.Value.EnumToString;
            writer.WriteStartArray();
            foreach (var entry in value)
            {
                writer.WriteStringValue(enumToString[entry]);
            }
            writer.WriteEndArray();
        }
    }
}