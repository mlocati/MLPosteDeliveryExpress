using System.IO;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class CollectOnTheFloor : ServiceWithStringParameters<CollectOnTheFloor>, IService
    {
        public bool? DataInWaybill => true;
        public string Code => "APT000917";
        public string Name => "Ritiro al piano";

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
    }
}