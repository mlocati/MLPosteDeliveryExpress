using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Deposit.Response
{
    internal class FilterContainer
    {
        [JsonPropertyName("result")]
        [JsonConverter(typeof(Json.Converter.BooleanOkKo))]
        public bool Result { get; set; } = false;

        [JsonPropertyName("errorCode")]
        [MaxLength(6)]
        public string ErrorCode { get; set; } = "";

        [JsonPropertyName("errorDescription")]
        [MaxLength(50)]
        public string ErrorDescription { get; set; } = "";

        [JsonPropertyName("deposits")]
        public DepositItem DepositItem { get; set; } = new();

        [JsonPropertyName("statusList")]
        public StatusListItem Statuses { get; set; } = new();

        [JsonPropertyName("reasons")]
        public ReasonListItem Reasons { get; set; } = new();
    }
}