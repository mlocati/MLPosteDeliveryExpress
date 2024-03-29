﻿using System.Text.Json;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    public class TimeDefiniteH12 : ServiceWithoutParameters<TimeDefiniteH12>, IService
    {
        public string Code => "APT000907";
        public string Name => "Time Definite Ore 12";
        public ServiceFlags Flags => ServiceFlags.InWaybill;

        public TimeDefiniteH12()
        {
        }

        public static TimeDefiniteH12 Unserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            CheckNoParameters(ref reader, options);
            return new();
        }
    }
}