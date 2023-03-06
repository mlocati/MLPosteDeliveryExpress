using System.IO;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public abstract class ServiceWithoutParameters<T> where T : IService
    {
#pragma warning disable IDE0060 // Remove unused parameter

        public void Serialize(Utf8JsonWriter writer, JsonSerializerOptions options)
#pragma warning restore IDE0060 // Remove unused parameter
        {
        }

#pragma warning disable IDE0060 // Remove unused parameter

        protected static void CheckNoParameters(ref Utf8JsonReader reader, JsonSerializerOptions options)
#pragma warning restore IDE0060 // Remove unused parameter
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

        public bool Equals(IService? other)
        {
            return other is T;
        }
    }
}