using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class DeliveryToPointInternational : DeliveryToNode<DeliveryToPointInternational>, IService
    {
        public string Code => "APT000961";
        public string Name => "Consegna Fermoposta/Casella Postale/Locker e Punto di Prossimità";
        public ServiceFlags Flags => ServiceFlags.OnlyForInternationalShipments;

        internal DeliveryToPointInternational() : this("22022", "Nome del punto di destinazione INT")
        {
        }

        public DeliveryToPointInternational(string node) : this(node, "")
        { }

        public DeliveryToPointInternational(string node, string nodeName)
            : base(node, nodeName)
        {
        }

        public static DeliveryToPointInternational Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var parameters = UnserializeValue(ref reader, options);
            return new(parameters[0], parameters[1]);
        }

        public override bool Equals(DeliveryToPointInternational other)
        {
            return other.Node == this.Node && other.NodeName == this.NodeName;
        }
    }
}