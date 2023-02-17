using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class TimeDefiniteH9 : ServiceWithoutParameters<TimeDefiniteH9>, IService
    {
        public string Code => "APT000905";
        public string Name => "Time Definite Ore 9";
        public ServiceFlags Flags => ServiceFlags.InWaybill;

        public TimeDefiniteH9()
        {
        }

        public static TimeDefiniteH9 Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            CheckNoParameters(ref reader, options);
            return new();
        }
    }
}