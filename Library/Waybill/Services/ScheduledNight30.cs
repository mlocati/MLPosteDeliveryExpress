using System;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    /// <summary>
    /// Accessorio per Last Mile Delivery
    /// </summary>
    public class ScheduledNight30 : DeliveryDateTimeInterval<ScheduledNight30>, IService
    {
        public string Code => "APT000994";
        public string Name => "Scheduled_Night_30";
        public ServiceFlags Flags => ServiceFlags.InwaybillOnlyTriplet;

        internal ScheduledNight30()
            : this(new TimeOnly(8, 0, 0), new TimeOnly(18, 0, 0), DateOnly.FromDateTime(DateTime.Today.AddDays(2)))
        {
        }

        public ScheduledNight30(TimeOnly rangeFrom, TimeOnly rangeTo, DateOnly date)
            : base(rangeFrom, rangeTo, date)
        {
        }

        public static ScheduledNight30 Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var parameters = UnserializeValue(ref reader, options);
            return new(parameters.RangeFrom, parameters.RangeTo, parameters.Date);
        }

        public override bool Equals(ScheduledNight30 other)
        {
            return other.RangeFrom.Equals(this.RangeFrom)
                && other.RangeTo.Equals(this.RangeTo)
                && other.Date.Equals(this.Date)
            ;
        }
    }
}