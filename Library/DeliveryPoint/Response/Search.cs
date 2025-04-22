using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.DeliveryPoint.Response
{
    public class Search
    {
        [JsonPropertyName("return")]
        public SearchReturn Return { get; set; } = new();
    }
}