using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class DeliveryOnSaturnday : ServiceWithoutParameters<DeliveryOnSaturnday>, IService
    {
        public string Code => "APT000910";
        public string Name => "Consegna di Sabato";
        public ServiceFlags Flags => ServiceFlags.InWaybill;

        public DeliveryOnSaturnday()
        {
        }

        public static DeliveryOnSaturnday Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            CheckNoParameters(ref reader, options);
            return new();
        }
    }
}