using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class CustomCharges : ServiceWithStringParameters<CustomCharges>, IService
    {
        public enum Payers
        {
            /// <summary>
            /// Mittente
            /// </summary>
            Sender,

            /// <summary>
            /// Destinatario
            /// </summary>
            Recipient,
        }

        public string Code => "APT000972";

        public string Name => "Opzione oneri doganali al mittente";

        public ServiceFlags Flags => ServiceFlags.InWaybill;

        public readonly Payers Payer;

        public CustomCharges() : this(Payers.Recipient)
        { }

        public CustomCharges(Payers payer)
        {
            this.Payer = payer;
        }

        public void Serialize(Utf8JsonWriter writer, JsonSerializerOptions options)
        {
            this.WriteDictionary(
                writer,
                new KeyValuePair<string, string>("custPayer", EncodePayer(this.Payer))
            );
        }

        public static CustomCharges Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var dictionary = ReadDictionary(ref reader, options);
            var step = DecodePayer(dictionary.Pop("custPayer"));
            dictionary.CheckEmpty();
            return new(step);
        }

        public bool Equals(IService? other)
        {
            if (other is not CustomCharges sameClassOther)
            {
                return false;
            }
            return sameClassOther.Payer == this.Payer;
        }

        private static string EncodePayer(Payers step)
        {
            return step switch
            {
                Payers.Sender => "M",
                Payers.Recipient => "D",
                _ => throw new ArgumentOutOfRangeException(nameof(step)),
            };
        }

        private static Payers DecodePayer(string str)
        {
            return str switch
            {
                "M" => Payers.Sender,
                "D" => Payers.Recipient,
                _ => throw new InvalidDataException(),
            };
        }
    }
}