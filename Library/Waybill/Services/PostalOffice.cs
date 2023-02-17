using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class PostalOffice : DeliveryToNode<PostalOffice>, IService
    {
        public string Code => "APT000949";
        public string Name => "Consegna Ufficio Postale";
        public ServiceFlags Flags => ServiceFlags.InWaybill;

        internal PostalOffice() : this("20534", "Nome ufficio postale 2")
        {
        }

        public PostalOffice(string node) : this(node, "")
        { }

        public PostalOffice(string node, string nodeName)
            : base(node, nodeName)
        {
        }

        public static PostalOffice Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var parameters = UnserializeValue(ref reader, options);
            return new(parameters[0], parameters[1]);
        }

        public override bool Equals(PostalOffice other)
        {
            return other.Node == this.Node && other.NodeName == this.NodeName;
        }
    }
}