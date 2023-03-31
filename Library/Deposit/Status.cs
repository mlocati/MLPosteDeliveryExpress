using System.Runtime.Serialization;

namespace MLPosteDeliveryExpress.Deposit
{
    public enum Status
    {
        /// <summary>
        /// Da svincolare.
        /// </summary>
        [EnumMember(Value = "INGIACENZA")]
        InDeposit,

        /// <summary>
        /// Svincolata.
        /// </summary>
        [EnumMember(Value = "SVINCOLATA")]
        Released,

        /// <summary>
        /// Non svincolabile.
        /// </summary>
        [EnumMember(Value = "SCADUTA")]
        Expired,

        /// <summary>
        /// Richiesta svincolo presa in carico.
        /// </summary>
        [EnumMember(Value = "RICHIESTO")]
        ReleaseRequested,
    }
}