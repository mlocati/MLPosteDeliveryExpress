using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public interface IService
    {
        public abstract bool? DataInWaybill { get; }
        public abstract string Code { get; }
        public abstract string Name { get; }

        public abstract void Serialize(Utf8JsonWriter writer, JsonSerializerOptions options);
    }
}