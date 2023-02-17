using System;

namespace MLPosteDeliveryExpress
{
    public class Options
    {
        public static event EventHandler<string>? VerboseOutput;

        public static bool Sandbox { get; set; }

        static Options()
        {
#if DEBUG
            Sandbox = true;
#else
            Sandbox = false;
#endif
        }

        internal static void OnVerboseOutput(object sender, string message)
        {
            Options.VerboseOutput?.Invoke(sender, message);
        }

        internal static void OnVerboseOutput(object sender, Lazy<string> messageCreator)
        {
            Options.VerboseOutput?.Invoke(sender, messageCreator.Value);
        }
    }
}