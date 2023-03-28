using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Tracking.Response
{
    public class Message
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = "";

        [JsonPropertyName("field")]
        public string Field { get; set; } = "";

        [JsonPropertyName("message")]
        public string Text { get; set; } = "";

        [JsonPropertyName("objectName")]
        public string ObjectName { get; set; } = "";

        [JsonPropertyName("severity")]
        public int Severity { get; set; } = 0;
    }
}