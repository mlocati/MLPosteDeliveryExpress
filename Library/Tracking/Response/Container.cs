using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Tracking.Response
{
    internal class Container
    {
        [JsonPropertyName("return")]
        public Return? Return { get; set; } = null;
    }
}