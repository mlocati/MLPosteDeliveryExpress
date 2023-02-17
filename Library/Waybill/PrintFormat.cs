using System.Runtime.Serialization;

namespace MLPosteDeliveryExpress.Waybill
{
    public enum PrintFormat
    {
        [EnumMember(Value = "A4")]
        PDF_A4,

        [EnumMember(Value = "1011")]
        PDF_10x11,

        [EnumMember(Value = "ZPL")]
        PRN_10x11,
    }
}