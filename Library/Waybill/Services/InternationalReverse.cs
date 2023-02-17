using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    /// <summary>
    /// Nuovo servizio accessorio diverso da quello previsto per nazionale.
    /// Per la richiesta è necessario inserire i dati del Mittente estero e destinatario Italia.
    /// Compilare anche il campo packaging code con "rev".
    /// </summary>
    public class InternationalReverse : ServiceWithoutParameters<InternationalReverse>, IService
    {
        public string Code => "APT000971";
        public string Name => "Reverse Internazionale";
        public ServiceFlags Flags => ServiceFlags.OnlyForInternationalShipments;

        public InternationalReverse()
        {
        }

        public static InternationalReverse Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            CheckNoParameters(ref reader, options);
            return new();
        }
    }
}