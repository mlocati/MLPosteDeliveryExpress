namespace MLPosteDeliveryExpress.Service
{
    public class Message
    {
        public enum MessageType
        {
            TokenRequestJson,
            TokenResponseJson,
            RequestJson,
            ResponseJson,
        }

        public readonly MessageType Type;

        public readonly string Data;

        public Message(MessageType type, string data)
        {
            this.Type = type;
            this.Data = data;
        }
    }
}