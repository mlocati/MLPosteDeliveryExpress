using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.DeliveryPoint.Response
{
    public class SearchReturn
    {
        [JsonPropertyName("outcome")]
        [JsonConverter(typeof(Json.Converter.BooleanOkKo))]
        public bool Outcome { get; set; } = false;

        [JsonPropertyName("code")]
        public uint Code { get; set; } = 0;

        [JsonPropertyName("deliveryPoint")]
        public List<DeliveryPoint> DeliveryPoints { get; set; } = new();
    }
}