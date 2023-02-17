using System.IO;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public abstract class ServiceWithoutParameters<T> where T : IService
    {
        public void Serialize(Utf8JsonWriter writer, JsonSerializerOptions options)
        {
        }

        protected static void CheckNoParameters(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return;
            }
            if (reader.TokenType != JsonTokenType.StartObject || !reader.Read() || reader.TokenType != JsonTokenType.EndObject)
            {
                throw new InvalidDataException();
            }
        }
    }
}