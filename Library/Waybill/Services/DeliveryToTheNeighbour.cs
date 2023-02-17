using System;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class DeliveryToTheNeighbour : ServiceWithStringParameters<DeliveryToTheNeighbour>, IService
    {
        public string Code => "APT000914";
        public string Name => "Consegna al vicino";
        public ServiceFlags Flags => ServiceFlags.None;

        public readonly string NeighbourName;

        internal DeliveryToTheNeighbour() : this("Nome del vicino")
        {
        }

        public DeliveryToTheNeighbour(string neighbourName)
        {
            if (neighbourName.Trim().Length == 0)
            {
                throw new ArgumentNullException(nameof(neighbourName));
            }
            this.NeighbourName = neighbourName;
        }

        public void Serialize(Utf8JsonWriter writer, JsonSerializerOptions options)
        {
            this.WriteDictionary(
                writer,
                new System.Collections.Generic.KeyValuePair<string, string>("neighbourName", this.NeighbourName)
            );
        }

        public static DeliveryToTheNeighbour Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var dictionary = ReadDictionary(ref reader, options);
            var neighbourName = dictionary.Pop("neighbourName");
            dictionary.CheckEmpty();
            return new(neighbourName);
        }

        public bool Equals(IService? other)
        {
            if (other is not DeliveryToTheNeighbour sameClassOther)
            {
                return false;
            }
            return sameClassOther.NeighbourName == this.NeighbourName;
        }
    }
}