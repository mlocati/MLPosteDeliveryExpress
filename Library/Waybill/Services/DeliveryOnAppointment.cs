using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class DeliveryOnAppointment : ServiceWithoutParameters<DeliveryOnAppointment>, IService
    {
        public string Code => "APT000908";
        public string Name => "Consegna su appuntamento";
        public ServiceFlags Flags => ServiceFlags.InWaybill;

        public DeliveryOnAppointment()
        {
        }

        public static DeliveryOnAppointment Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            CheckNoParameters(ref reader, options);
            return new();
        }
    }
}