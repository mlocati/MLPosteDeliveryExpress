using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Request
{
    internal class ActionContainer
    {
        [JsonPropertyName("releaseAct")]
        public ReleaseAct ReleaseAct { get; set; } = new();

        [JsonPropertyName("shipmentId")]
        public ShipmentIDItem ShipmentID { get; set; } = new();

        [JsonPropertyName("address")]
        public AddressItem Address { get; set; } = new();
    }
}