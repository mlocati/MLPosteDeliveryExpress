using System;
using System.Net.Http;

namespace MLPosteDeliveryExpress
{
    public class Options
    {
        public static event EventHandler<HttpClient>? HttpClientInitialization;

        public static event EventHandler<Service.Message>? VerboseOutput;

        internal static void OnHttpClientInitialization(object? sender, HttpClient httpClient)
        {
            Options.HttpClientInitialization?.Invoke(sender, httpClient);
        }

        internal static void OnVerboseOutput(object? sender, Service.Message message)
        {
            Options.VerboseOutput?.Invoke(sender, message);
        }

        internal static void OnVerboseOutput(object? sender, Lazy<Service.Message> messageCreator)
        {
            Options.VerboseOutput?.Invoke(sender, messageCreator.Value);
        }
    }
}