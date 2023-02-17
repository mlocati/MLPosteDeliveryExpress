using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class MultiPack : ServiceWithoutParameters<MultiPack>, IService
    {
        public string Code => "APT000945";
        public string Name => "Multicollo";
        public ServiceFlags Flags => ServiceFlags.None;

        public MultiPack()
        {
        }

        public static MultiPack Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            CheckNoParameters(ref reader, options);
            return new();
        }
    }
}