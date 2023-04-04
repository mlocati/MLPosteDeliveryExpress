using System.ComponentModel;
using System.Runtime.Serialization;

namespace MLPosteDeliveryExpress.Deposit
{
    public enum Action
    {
        [EnumMember(Value = "")]
        [Description("")]
        None,

        /// <summary>
        /// Torna in consegna.
        /// </summary>
        [EnumMember(Value = "AZ0001")]
        [Description("Retry Delivery")]
        RetryDelivery,

        /// <summary>
        /// Riconsegna ad altro indirizzo.
        /// </summary>
        [EnumMember(Value = "AZ0002")]
        [Description("Deliver to Another Address")]
        DeliverToAnotherAddress,

        /// <summary>
        /// Abbandono della spedizione.
        /// </summary>
        [EnumMember(Value = "AZ0003")]
        [Description("Abandon Shipment")]
        Abandon,

        /// <summary>
        /// Ufficio postale.
        /// </summary>
        [EnumMember(Value = "AZ0004")]
        [Description("Post Office")]
        PostOffice,

        /// <summary>
        /// Ritorno al Mittente.
        /// </summary>
        [EnumMember(Value = "AZ0005")]
        [Description("Return to Sender")]
        ReturnToSender,

        /// <summary>
        /// Fermo deposito.
        /// </summary>
        [EnumMember(Value = "AZ0006")]
        [Description("Hold for Pickup")]
        HoldForPickup,

        /// <summary>
        /// Punto Poste - Locker.
        /// </summary>
        [EnumMember(Value = "AZ0007")]
        [Description("Punto Poste Locker")]
        LockerPuntoPoste,

        /// <summary>
        /// Punto Poste.
        /// </summary>
        [EnumMember(Value = "AZ0008")]
        [Description("Punto Poste")]
        PuntoPoste,
    }
}