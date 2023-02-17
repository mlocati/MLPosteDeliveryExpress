using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class PuntoPosteLockerReverse : ServiceWithoutParameters<PuntoPosteLockerReverse>, IService
    {
        public string Code => "APT000980";
        public string Name => "Reverse PuntoPoste Locker";
        public ServiceFlags Flags => ServiceFlags.InWaybill;

        public PuntoPosteLockerReverse()
        {
        }

        public static PuntoPosteLockerReverse Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            CheckNoParameters(ref reader, options);
            return new();
        }
    }
}