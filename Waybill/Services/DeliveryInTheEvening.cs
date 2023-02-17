﻿using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class DeliveryInTheEvening : ServiceWithoutParameters<DeliveryInTheEvening>, IService
    {
        public bool? DataInWaybill => true;
        public string Code => "APT000911";
        public string Name => "Consegna di Sera";

        public DeliveryInTheEvening()
        {
        }

        public static DeliveryInTheEvening Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            CheckNoParameters(ref reader, options);
            return new();
        }
    }
}