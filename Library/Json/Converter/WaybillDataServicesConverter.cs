using MLPosteDeliveryExpress.Waybill.Request;
using MLPosteDeliveryExpress.Waybill.Services;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class WaybillDataServicesConverter : JsonConverter<WaybillDataServices>
    {
        private delegate IService UnserializerDelegate(ref Utf8JsonReader reader, JsonSerializerOptions options);

        public override WaybillDataServices Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var result = new WaybillDataServices();
            switch (reader.TokenType)
            {
                case JsonTokenType.Null:
                    return result;

                case JsonTokenType.StartObject:
                    break;

                default:
                    throw new InvalidDataException();
            }
            for (; ; )
            {
                if (!reader.Read())
                {
                    throw new InvalidDataException();
                }
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }
                var code = reader.TokenType == JsonTokenType.PropertyName ? reader.GetString() : null;
                if (code == null)
                {
                    throw new InvalidDataException();
                }
                if (!reader.Read())
                {
                    throw new InvalidDataException();
                }
                var service = Waybill.Services.Service.GetByCode(code);
                if (service == null)
                {
                    throw new InvalidDataException($"Unrecognized service code: {code}");
                }
                var method = service.Type.GetMethod("Unserialize", BindingFlags.Static | BindingFlags.Public);
                if (method == null)
                {
                    throw new InvalidDataException($"The IService {service.Type.Name} doesn't implement the Unserialize static method");
                }
                var iservice = method.CreateDelegate<UnserializerDelegate>(null)(ref reader, options);
                result.Add(iservice);
            }
            return result;
        }

        public override void Write(Utf8JsonWriter writer, WaybillDataServices value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            foreach (var service in value.GetAll())
            {
                writer.WritePropertyName(service.Code);
                writer.WriteStartObject();
                service.Serialize(writer, options);
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }
    }
}