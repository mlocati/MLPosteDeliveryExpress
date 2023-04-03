using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Request
{
    internal class ShipmentID
    {
        /// <summary>
        /// ID LdV.
        /// </summary>
        [MaxLength(50)]
        [JsonPropertyName("barcode")]
        public string BarCode { get; set; } = "";
    }
}