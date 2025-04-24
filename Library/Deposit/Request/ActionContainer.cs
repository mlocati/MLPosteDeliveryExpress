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

        /// <summary>
        /// Da valorizzare con l’id dell’ufficio richiesto, per le releaseAction:
        /// - PostOffice ("AZ0004")
        /// - LockerPuntoPoste ("AZ0007")
        /// - PuntoPoste ("AZ0008")
        /// </summary>
        [JsonPropertyName("officeId")]
        public string OfficeID { get; set; } = "";
    }
}