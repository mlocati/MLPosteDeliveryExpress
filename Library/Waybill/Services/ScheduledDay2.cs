using System;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    /// <summary>
    /// Accessorio per Last Mile Delivery
    /// </summary>
    public class ScheduledDay2 : DeliveryDateTimeInterval<ScheduledDay2>, IService
    {
        public string Code => "APT000984";
        public string Name => "Scheduled_Day_2";
        public ServiceFlags Flags => ServiceFlags.InwaybillOnlyTriplet;

        internal ScheduledDay2()
            : this(new TimeOnly(8, 0, 0), new TimeOnly(18, 0, 0), DateOnly.FromDateTime(DateTime.Today.AddDays(2)))
        {
        }

        public ScheduledDay2(TimeOnly rangeFrom, TimeOnly rangeTo, DateOnly date)
            : base(rangeFrom, rangeTo, date)
        {
        }

        public static ScheduledDay2 Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var parameters = UnserializeValue(ref reader, options);
            return new(parameters.RangeFrom, parameters.RangeTo, parameters.Date);
        }

        public override bool Equals(ScheduledDay2 other)
        {
            return other.RangeFrom.Equals(this.RangeFrom)
                && other.RangeTo.Equals(this.RangeTo)
                && other.Date.Equals(this.Date)
            ;
        }
    }
}