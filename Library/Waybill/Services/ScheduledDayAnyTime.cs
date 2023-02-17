using System;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    /// <summary>
    /// Accessorio per Last Mile Delivery
    /// </summary>
    public class ScheduledDayAnyTime : DeliveryDateTimeInterval<ScheduledDayAnyTime>, IService
    {
        public string Code => "APT000988";
        public string Name => "Scheduled_Day_AnyTime";
        public ServiceFlags Flags => ServiceFlags.InwaybillOnlyTriplet;

        internal ScheduledDayAnyTime()
            : this(new TimeOnly(8, 0, 0), new TimeOnly(18, 0, 0), DateOnly.FromDateTime(DateTime.Today.AddDays(2)))
        {
        }

        public ScheduledDayAnyTime(TimeOnly rangeFrom, TimeOnly rangeTo, DateOnly date)
            : base(rangeFrom, rangeTo, date)
        {
        }

        public static ScheduledDayAnyTime Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var parameters = UnserializeValue(ref reader, options);
            return new(parameters.RangeFrom, parameters.RangeTo, parameters.Date);
        }

        public override bool Equals(ScheduledDayAnyTime other)
        {
            return other.RangeFrom.Equals(this.RangeFrom)
                && other.RangeTo.Equals(this.RangeTo)
                && other.Date.Equals(this.Date)
            ;
        }
    }
}