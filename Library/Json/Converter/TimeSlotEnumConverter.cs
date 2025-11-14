using MLPosteDeliveryExpress.PickupBooking;

namespace MLPosteDeliveryExpress.Json.Converter
{
    internal class TimeSlotEnumConverter : AnnotatedEnumConverter<TimeSlot>
    {
        override protected string FixStringValue(string str)
        {
            if (str == "AM/P")
            {
                return "AMPM";
            }
            return str;
        }
    }
}