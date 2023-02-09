using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking
{
    public abstract class ItemsContainer<T> where T : new()
    {
        [JsonPropertyName("item")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T[] Items { get; set; } = new T[] { new T() };

        [JsonIgnore]
        protected T Item
        {
            get
            {
                if (Items.Length == 0)
                {
                    lock (this)
                    {
                        if (Items.Length == 0)
                        {
                            Items = new T[] { new T() };
                        }
                    }
                }
                return Items[0];
            }
            set
            {
                if (Items.Length == 0)
                {
                    lock (this)
                    {
                        if (Items.Length == 0)
                        {
                            Items = new T[] { new T() };
                        }
                    }
                }
                Items[0] = value;
            }
        }
    }
}