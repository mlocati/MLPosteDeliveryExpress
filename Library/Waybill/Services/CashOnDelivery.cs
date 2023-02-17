using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class CashOnDelivery : ServiceWithStringParameters<CashOnDelivery>, IService
    {
        public enum PaymentModes
        {
            /// <summary>
            /// Contanti
            /// </summary>
            Cash,

            /// <summary>
            /// Assegno circolare intestato al mittente.
            /// </summary>
            CashiersCheck,

            /// <summary>
            /// Assegno bancario intestato al mittente.
            /// </summary>
            BackCheck,
        }

        public string Code => "APT000918";

        public string Name => "Contrassegno";

        public ServiceFlags Flags => ServiceFlags.InWaybill;

        public readonly decimal Amount;

        public readonly PaymentModes PaymentMode;

        internal CashOnDelivery() : this(123.45M, PaymentModes.Cash)
        { }

        public CashOnDelivery(decimal amount, PaymentModes paymentMode)
        {
            if (amount != Math.Round(amount, 2))
            {
                throw new ArgumentException("The amount must have up to 2 decimal digits", nameof(amount));
            }
            this.Amount = amount;
            this.PaymentMode = paymentMode;
        }

        public void Serialize(Utf8JsonWriter writer, JsonSerializerOptions options)
        {
            this.WriteDictionary(
                writer,
                new KeyValuePair<string, string>("amount", this.Amount.ToString("0.00", CultureInfo.InvariantCulture)),
                new KeyValuePair<string, string>("paymentMode", EncodePaymentMode(this.PaymentMode))
            );
        }

        public static CashOnDelivery Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var dictionary = ReadDictionary(ref reader, options);
            if (!decimal.TryParse(dictionary.Pop("amount"), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal amount))
            {
                throw new InvalidDataException();
            }
            var paymentMode = DecodePaymentMode(dictionary.Pop("paymentMode"));
            dictionary.CheckEmpty();
            return new(amount, paymentMode);
        }

        public bool Equals(IService? other)
        {
            if (other is not CashOnDelivery sameClassOther)
            {
                return false;
            }
            return sameClassOther.Amount == this.Amount
                && sameClassOther.PaymentMode == this.PaymentMode
            ;
        }

        private static string EncodePaymentMode(PaymentModes paymentMode)
        {
            return paymentMode switch
            {
                PaymentModes.Cash => "CON",
                PaymentModes.CashiersCheck => "ACM",
                PaymentModes.BackCheck => "ABM",
                _ => throw new ArgumentOutOfRangeException(nameof(paymentMode)),
            };
        }

        private static PaymentModes DecodePaymentMode(string str)
        {
            return str switch
            {
                "CON" => PaymentModes.Cash,
                "ACM" => PaymentModes.CashiersCheck,
                "ABM" => PaymentModes.BackCheck,
                _ => throw new InvalidDataException(),
            };
        }
    }
}