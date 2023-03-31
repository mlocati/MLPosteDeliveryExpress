using System.Runtime.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Response
{
    public enum Action
    {
        [EnumMember(Value = "")]
        None,

        /// <summary>
        /// Torna in consegna.
        /// </summary>
        [EnumMember(Value = "AZ0001")]
        RetryDelivery,

        /// <summary>
        /// Riconsegna ad altro indirizzo.
        /// </summary>
        [EnumMember(Value = "AZ0002")]
        DeliverToAnotherAddress,

        /// <summary>
        /// Abbandono della spedizione.
        /// </summary>
        [EnumMember(Value = "AZ0003")]
        Abandon,

        /// <summary>
        /// Ufficio postale.
        /// </summary>
        [EnumMember(Value = "AZ0004")]
        PostOffice,

        /// <summary>
        /// Ritorno al Mittente.
        /// </summary>
        [EnumMember(Value = "AZ0005")]
        ReturnToSender,

        /// <summary>
        /// Fermo deposito.
        /// </summary>
        [EnumMember(Value = "AZ0006")]
        HoldForPickup,

        /// <summary>
        /// Punto Poste - Locker.
        /// </summary>
        [EnumMember(Value = "AZ0007")]
        LockerPuntoPoste,

        /// <summary>
        /// Punto Poste.
        /// </summary>
        [EnumMember(Value = "AZ0008")]
        PuntoPoste,
    }
}