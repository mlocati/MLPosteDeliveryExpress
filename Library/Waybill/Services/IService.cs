using System;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public interface IService : IEquatable<IService>
    {
        public abstract string Code { get; }
        public abstract string Name { get; }
        public abstract ServiceFlags Flags { get; }

        public abstract void Serialize(Utf8JsonWriter writer, JsonSerializerOptions options);
    }
}