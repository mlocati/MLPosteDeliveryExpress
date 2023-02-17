using System;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    /// <summary>
    /// Accessorio per Last Mile Delivery
    /// </summary>
    public class SameDay4 : DeliveryDateTimeInterval<SameDay4>, IService
    {
        public string Code => "APT000996";
        public string Name => "Same_Day_4";
        public ServiceFlags Flags => ServiceFlags.InwaybillOnlyTriplet;

        internal SameDay4()
            : this(new TimeOnly(8, 0, 0), new TimeOnly(18, 0, 0), DateOnly.FromDateTime(DateTime.Today.AddDays(2)))
        {
        }

        public SameDay4(TimeOnly rangeFrom, TimeOnly rangeTo, DateOnly date)
            : base(rangeFrom, rangeTo, date)
        {
        }

        public static SameDay4 Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var parameters = UnserializeValue(ref reader, options);
            return new(parameters.RangeFrom, parameters.RangeTo, parameters.Date);
        }

        public override bool Equals(SameDay4 other)
        {
            return other.RangeFrom.Equals(this.RangeFrom)
                && other.RangeTo.Equals(this.RangeTo)
                && other.Date.Equals(this.Date)
            ;
        }
    }
}