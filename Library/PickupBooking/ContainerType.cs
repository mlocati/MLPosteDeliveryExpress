using System.Runtime.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking
{
    public enum ContainerType
    {
        /// <summary>
        /// Pacco o pallet.
        /// </summary>
        [EnumMember(Value = "P")]
        PackageOrPallet,

        /// <summary>
        /// Busta.
        /// </summary>
        [EnumMember(Value = "B")]
        Envelope,
    }
}