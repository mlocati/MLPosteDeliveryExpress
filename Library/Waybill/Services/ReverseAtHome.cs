using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class ReverseAtHome : ServiceWithoutParameters<ReverseAtHome>, IService
    {
        public string Code => "APT000928";
        public string Name => "Reverse A Domicilio";
        public ServiceFlags Flags => ServiceFlags.None;

        public ReverseAtHome()
        {
        }

        public static ReverseAtHome Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            CheckNoParameters(ref reader, options);
            return new();
        }
    }
}