using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class TimeDefiniteH10 : ServiceWithoutParameters<TimeDefiniteH10>, IService
    {
        public string Code => "APT000906";
        public string Name => "Time Definite Ore 10";
        public ServiceFlags Flags => ServiceFlags.InWaybill;

        public TimeDefiniteH10()
        {
        }

        public static TimeDefiniteH10 Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            CheckNoParameters(ref reader, options);
            return new();
        }
    }
}