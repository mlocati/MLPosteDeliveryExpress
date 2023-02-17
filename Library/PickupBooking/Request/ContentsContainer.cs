using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking.Request
{
    public class ContentsContainer : ItemsContainer<Contents>
    {
        [JsonIgnore]
        public Contents Contents
        {
            get => this.Item;
            set => this.Item = value;
        }
    }
}