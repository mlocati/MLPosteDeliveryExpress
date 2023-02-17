using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class CollectByAppointment : ServiceWithoutParameters<CollectByAppointment>, IService
    {
        public bool? DataInWaybill => null;
        public string Code => "APT000915";
        public string Name => "Ritiro su appuntamento";

        public CollectByAppointment()
        {
        }

        public static CollectByAppointment Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            CheckNoParameters(ref reader, options);
            return new();
        }
    }
}