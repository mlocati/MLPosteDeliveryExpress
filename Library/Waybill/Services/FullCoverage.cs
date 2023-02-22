using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public abstract class FullCoverage<T> : ServiceWithStringParameters<T> where T : class, IService
    {
        public readonly decimal Amount;

        protected FullCoverage(decimal amount)
        {
            if (amount != Math.Round(amount, 2))
            {
                throw new ArgumentException("The amount must have up to 2 decimal digits", nameof(amount));
            }
            this.Amount = amount;
        }

#pragma warning disable IDE0060 // Remove unused parameter
        public void Serialize(Utf8JsonWriter writer, JsonSerializerOptions options)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            this.WriteDictionary(
                writer,
                new KeyValuePair<string, string>("amount", this.Amount.ToString("0.00", CultureInfo.InvariantCulture))
            );
        }

        protected static decimal UnserializeValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var dictionary = ReadDictionary(ref reader, options);
            if (!decimal.TryParse(dictionary.Pop("amount"), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal amount))
            {
                throw new InvalidDataException();
            }
            dictionary.CheckEmpty();
            return amount;
        }

        public abstract bool Equals(T other);

        public bool Equals(IService? other)
        {
            if (other is not T sameClassOther)
            {
                return false;
            }
            return this.Equals(sameClassOther);
        }
    }
}