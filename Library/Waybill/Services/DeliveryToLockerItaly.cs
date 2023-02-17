using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class DeliveryToLockerItaly : DeliveryToNode<DeliveryToLockerItaly>, IService
    {
        public string Code => "APT000948";
        public string Name => "Cosegna presso punto di prossimità / locker";
        public ServiceFlags Flags => ServiceFlags.InWaybill | ServiceFlags.OnlyOnePackage | ServiceFlags.OnlyForItalianShipments;

        internal DeliveryToLockerItaly() : this("00535", "Nome dell'accesso point UPS IT")
        {
        }

        public DeliveryToLockerItaly(string node) : this(node, "")
        { }

        public DeliveryToLockerItaly(string node, string nodeName)
            : base(node, nodeName)
        {
        }

        public static DeliveryToLockerItaly Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var parameters = UnserializeValue(ref reader, options);
            return new(parameters[0], parameters[1]);
        }

        public override bool Equals(DeliveryToLockerItaly other)
        {
            return other.Node == this.Node && other.NodeName == this.NodeName;
        }
    }
}