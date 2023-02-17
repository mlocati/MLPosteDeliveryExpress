using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class PuntoPosteReverse : ServiceWithoutParameters<PuntoPosteReverse>, IService
    {
        public string Code => "APT000979";
        public string Name => "Reverse PuntoPoste";
        public ServiceFlags Flags => ServiceFlags.InWaybill;

        public PuntoPosteReverse()
        {
        }

        public static PuntoPosteReverse Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            CheckNoParameters(ref reader, options);
            return new();
        }
    }
}