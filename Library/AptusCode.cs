using System.Runtime.Serialization;

namespace MLPosteDeliveryExpress
{
    public enum AptusCode
    {
        [EnumMember(Value = "APT000902")]
        PosteDeliveryBusinessStandard,

        [EnumMember(Value = "APT000901")]
        PosteDeliveryBusinessExpress,

        [EnumMember(Value = "APT000902")]
        PosteDeliveryBusinessStandardReverse,

        [EnumMember(Value = "APT000901")]
        PosteDeliveryBusinessExpressReverse,

        [EnumMember(Value = "APT000904")]
        PosteDeliveryBusinessInternazionaleStandard,

        [EnumMember(Value = "APT000903")]
        PosteDeliveryBusinessInternazionaleExpress,

        [EnumMember(Value = "APT000962")]
        UnknownAPT000962,

        [EnumMember(Value = "APT000971")]
        UnknownAPT000971,

        [EnumMember(Value = "APT001013")]
        UnknownAPTAPT001013,
    }
}