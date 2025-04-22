using System.Runtime.Serialization;

namespace MLPosteDeliveryExpress.DeliveryPoint
{
    public enum ServiceType
    {
        /// <summary>
        /// PuntoPoste Locker.
        /// </summary>
        [EnumMember(Value = "APT")]
        PuntoPosteLocker,

        /// <summary>
        /// Casella postale.
        /// </summary>
        [EnumMember(Value = "CPT")]
        POBox,

        /// <summary>
        /// Fermoposta.
        /// </summary>
        [EnumMember(Value = "FMP")]
        Fermoposta,

        /// <summary>
        /// PuntoPoste.
        /// </summary>
        [EnumMember(Value = "RTZ")]
        PuntoPoste,
    }
}