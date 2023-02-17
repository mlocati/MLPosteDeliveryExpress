using System.IO;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class DeliveryToTheFloor : ServiceWithStringParameters<DeliveryToTheFloor>, IService
    {
        public bool? DataInWaybill => true;
        public string Code => "APT000913";
        public string Name => "Consegna al piano";

        public readonly bool ElevatorExists;

        internal DeliveryToTheFloor() : this(false)
        {
        }

        public DeliveryToTheFloor(bool elevatorExists)
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

        public static DeliveryToTheFloor Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
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
            if (other is not DeliveryToTheFloor sameClassOther)
            {
                return false;
            }
            return sameClassOther.ElevatorExists == this.ElevatorExists;
        }
    }
}