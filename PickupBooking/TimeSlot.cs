using System.Runtime.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking
{
    public enum TimeSlot
    {
        /// <summary>
        /// Mattino.
        /// </summary>
        [EnumMember(Value = "AM")]
        Morning,

        /// <summary>
        /// Pomeriggio.
        /// </summary>
        [EnumMember(Value = "PM")]
        Afternoon,

        /// <summary>
        /// Mattina o pomeriggio.
        /// </summary>
        [EnumMember(Value = "AMPM")]
        MorningOrAfternoon,
    }
}