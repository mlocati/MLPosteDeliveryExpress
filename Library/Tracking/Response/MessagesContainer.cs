using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.Tracking.Response
{
    internal class MessagesContainer
    {
        [JsonPropertyName("messages")]
        public List<Message> Messages { get; set; } = new();
    }
}