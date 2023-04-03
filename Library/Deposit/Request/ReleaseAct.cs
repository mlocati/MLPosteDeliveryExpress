using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Request
{
    internal class ReleaseAct
    {
        /// <summary>
        /// ID LdV.
        /// </summary>
        [MaxLength(50)]
        [JsonPropertyName("shipmentId")]
        public string ShipmentID { get; set; } = "";

        /// <summary>
        /// Azione di svincolo.
        /// </summary>
        [JsonPropertyName("releaseAction")]
        public Action Action { get; set; } = Action.None;
    }
}