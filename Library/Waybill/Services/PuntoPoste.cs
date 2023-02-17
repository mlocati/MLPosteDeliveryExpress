using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class PuntoPoste : DeliveryToNode<PuntoPoste>, IService
    {
        public string Code => "APT000947";
        public string Name => "Punto Poste";
        public ServiceFlags Flags => ServiceFlags.InWaybill;

        internal PuntoPoste() : this("00534", "Nome ufficio postale")
        {
        }

        public PuntoPoste(string node) : this(node, "")
        { }

        public PuntoPoste(string node, string nodeName)
            : base(node, nodeName)
        {
        }

        public static PuntoPoste Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var parameters = UnserializeValue(ref reader, options);
            return new(parameters[0], parameters[1]);
        }

        public override bool Equals(PuntoPoste other)
        {
            return other.Node == this.Node && other.NodeName == this.NodeName;
        }
    }
}