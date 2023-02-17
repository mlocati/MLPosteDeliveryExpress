using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class PostalOfficeReverse : ServiceWithoutParameters<PostalOfficeReverse>, IService
    {
        public string Code => "APT000981";
        public string Name => "Reverse Ufficio Postale";
        public ServiceFlags Flags => ServiceFlags.InWaybill;

        public PostalOfficeReverse()
        {
        }

        public static PostalOfficeReverse Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            CheckNoParameters(ref reader, options);
            return new();
        }
    }
}