using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public abstract class ServiceWithStringParameters<T> where T : IService
    {
        protected void WriteDictionary(Utf8JsonWriter writer, params KeyValuePair<string, string>[] values)
        {
            foreach (var kv in values)
            {
                writer.WriteString(kv.Key, kv.Value);
            }
        }

        protected class UnserializedData
        {
            private readonly Dictionary<string, string> Dictionary = new();

            public UnserializedData()
            { }

            public void Add(string key, string value)
            {
                Dictionary.Add(key, value);
            }

            public string Pop(string key)
            {
                if (!this.Dictionary.ContainsKey(key))
                {
                    return "";
                }
                var result = this.Dictionary[key];
                this.Dictionary.Remove(key);
                return result;
            }

            /// <exception cref="InvalidDataException"></exception>
            public void CheckEmpty()
            {
                if (this.Dictionary.Count != 0)
                {
                    throw new InvalidDataException();
                }
            }
        }

        protected static UnserializedData ReadDictionary(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var result = new UnserializedData();
            if (reader.TokenType == JsonTokenType.Null)
            {
                return result;
            }
            if (reader.TokenType != JsonTokenType.StartObject || !reader.Read())
            {
                throw new InvalidDataException();
            }
            while (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString() ?? "";
                if (!reader.Read())
                {
                    throw new InvalidDataException();
                }
                if (reader.TokenType != JsonTokenType.String)
                {
                    throw new InvalidDataException();
                }
                var propertyValue = reader.GetString() ?? "";
                result.Add(propertyName, propertyValue);
                if (!reader.Read())
                {
                    throw new InvalidDataException();
                }
            }
            if (reader.TokenType != JsonTokenType.EndObject)
            {
                throw new InvalidDataException();
            }
            return result;
        }
    }
}