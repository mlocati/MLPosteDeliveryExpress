using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class FullCoverageItaly : FullCoverage<FullCoverageItaly>, IService
    {
        public string Code => "APT000919";

        public string Name => "Copertura full";

        public ServiceFlags Flags => ServiceFlags.NotInWaybill | ServiceFlags.OnlyForItalianShipments;

        internal FullCoverageItaly() : this(123.45M)
        { }

        public FullCoverageItaly(decimal amount)
            : base(amount)
        {
        }

        public static FullCoverageItaly Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            return new(UnserializeValue(ref reader, options));
        }

        public override bool Equals(FullCoverageItaly other)
        {
            return other.Amount == this.Amount;
        }
    }
}