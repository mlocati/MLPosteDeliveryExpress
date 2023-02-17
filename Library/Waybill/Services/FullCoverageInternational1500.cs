using System;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class FullCoverageInternational1500 : FullCoverage<FullCoverageInternational1500>, IService
    {
        public string Code => "APT000955";

        public string Name => "Copertura Full (da zero fino a 1.500 euro)";

        public ServiceFlags Flags => ServiceFlags.InWaybill | ServiceFlags.OnlyForInternationalShipments;

        internal FullCoverageInternational1500() : this(123.45M)
        { }

        public FullCoverageInternational1500(decimal amount)
            : base(amount)
        {
            if (this.Amount > 1500)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
        }

        public static FullCoverageInternational1500 Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            return new(UnserializeValue(ref reader, options));
        }

        public override bool Equals(FullCoverageInternational1500 other)
        {
            return other.Amount == this.Amount;
        }
    }
}