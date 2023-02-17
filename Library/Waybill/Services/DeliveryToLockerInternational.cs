using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class DeliveryToLockerInternational : DeliveryToNode<DeliveryToLockerInternational>, IService
    {
        public string Code => "APT000939";
        public string Name => "Consegna presso punto di prossimità / locker (internazionale)";
        public ServiceFlags Flags => ServiceFlags.None;

        internal DeliveryToLockerInternational() : this("00534", "Nome dell'accesso point UPS INT")
        {
        }

        public DeliveryToLockerInternational(string node) : this(node, "")
        { }

        public DeliveryToLockerInternational(string node, string nodeName)
            : base(node, nodeName)
        {
        }

        public static DeliveryToLockerInternational Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var parameters = UnserializeValue(ref reader, options);
            return new(parameters[0], parameters[1]);
        }

        public override bool Equals(DeliveryToLockerInternational other)
        {
            return other.Node == this.Node && other.NodeName == this.NodeName;
        }
    }
}