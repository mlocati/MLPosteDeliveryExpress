using System.Runtime.Serialization;

namespace MLPosteDeliveryExpress.Waybill
{
    public enum ReceiverType
    {
        [EnumMember(Value = "retailDelivery")]
        RetailDelivery,

        [EnumMember(Value = "businessDelivery")]
        BusinessDelivery
    }
}