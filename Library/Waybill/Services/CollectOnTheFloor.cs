using System.IO;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class CollectOnTheFloor : ServiceWithStringParameters<CollectOnTheFloor>, IService
    {
        public string Code => "APT000917";
        public string Name => "Ritiro al piano";
        public ServiceFlags Flags => ServiceFlags.InWaybill;

        public readonly bool ElevatorExists;

        internal CollectOnTheFloor() : this(false)
        {
        }

        public CollectOnTheFloor(bool elevatorExists)
        {
            this.ElevatorExists = elevatorExists;
        }

        public void Serialize(Utf8JsonWriter writer, JsonSerializerOptions options)
        {
            this.WriteDictionary(
                writer,
                new System.Collections.Generic.KeyValuePair<string, string>("note", this.ElevatorExists ? "ASCENSORE" : "")
            );
        }

        public static CollectOnTheFloor Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var dictionary = ReadDictionary(ref reader, options);
            var elevatorExists = dictionary.Pop("note") switch
            {
                "" => false,
                "ASCENSORE" => true,
                _ => throw new InvalidDataException(),
            };
            dictionary.CheckEmpty();
            return new(elevatorExists);
        }

        public bool Equals(IService? other)
        {
            if (other is not CollectOnTheFloor sameClassOther)
            {
                return false;
            }
            return sameClassOther.ElevatorExists == this.ElevatorExists;
        }
    }
}