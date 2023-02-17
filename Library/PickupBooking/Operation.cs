using System.Runtime.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking
{
    public enum Operation
    {
        /// <summary>
        /// Inserimento.
        /// </summary>
        [EnumMember(Value = "I")]
        Insert,

        /// <summary>
        /// Annullamento.
        /// </summary>
        [EnumMember(Value = "A")]
        Cancel,

        /// <summary>
        /// Modifica.
        /// </summary>
        [EnumMember(Value = "M")]
        Edit,
    }
}