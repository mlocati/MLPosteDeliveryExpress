using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class AtHome : ServiceWithoutParameters<AtHome>, IService
    {
        public string Code => "APT000946";
        public string Name => "A Domicilio";
        public ServiceFlags Flags => ServiceFlags.None;

        public AtHome()
        {
        }

        public static AtHome Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            CheckNoParameters(ref reader, options);
            return new();
        }
    }
}