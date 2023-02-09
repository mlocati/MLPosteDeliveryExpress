using System.Runtime.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking
{
    public enum BookingType
    {
        /// <summary>
        /// Ritiro singolo.
        /// </summary>
        [EnumMember(Value = "RIT0001")]
        Single,

        /// <summary>
        /// Ritiro paperless.
        /// </summary>
        [EnumMember(Value = "RIT0002")]
        Paperless,

        /// <summary>
        /// Ritiro multiplo.
        /// </summary>
        [EnumMember(Value = "RIT0003")]
        Multiple,
    }
}