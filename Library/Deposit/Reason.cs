using System.Runtime.Serialization;

namespace MLPosteDeliveryExpress.Deposit
{
    public enum Reason
    {
        /// <summary>
        /// Rifiuto del destinatario.
        /// </summary>
        [EnumMember(Value = "RIFDEST")]
        RejectedByRecipient,

        /// <summary>
        /// Destinatario non individuabile.
        /// </summary>
        [EnumMember(Value = "DESTNOTIND")]
        RecipientNotIdentifiable,

        /// <summary>
        /// Indirizzo errato.
        /// </summary>
        [EnumMember(Value = "INDERR")]
        WrongAddress,

        /// <summary>
        /// Destinatario assente.
        /// </summary>
        [EnumMember(Value = "DESTASS")]
        RecipientAbsent,
    }
}