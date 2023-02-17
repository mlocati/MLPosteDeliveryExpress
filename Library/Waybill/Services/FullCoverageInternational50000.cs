using System;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class FullCoverageInternational50000 : FullCoverage<FullCoverageInternational50000>, IService
    {
        public string Code => "APT000956";

        public string Name => "Copertura Full (da zero fino a 50.000 euro)";

        public ServiceFlags Flags => ServiceFlags.InWaybill | ServiceFlags.OnlyForInternationalShipments;

        internal FullCoverageInternational50000() : this(123.45M)
        { }

        public FullCoverageInternational50000(decimal amount)
            : base(amount)
        {
            if (this.Amount > 50000)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
        }

        public static FullCoverageInternational50000 Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            return new(UnserializeValue(ref reader, options));
        }

        public override bool Equals(FullCoverageInternational50000 other)
        {
            return other.Amount == this.Amount;
        }
    }
}