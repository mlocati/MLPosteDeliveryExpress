using System.ComponentModel;

namespace MLPosteDeliveryExpress
{
    public sealed class SandboxAccount : ISandboxAccount
    {
        [DisplayName("Client ID")]
        public string ClientID { get => "611c9cb0-deff-44b8-8337-b5fe2b3297fc"; }

        [DisplayName("Client Secret")]
        public string ClientSecret { get => "aSn8Q~5LbgHtdwqr~DYJ14z5UBTowLBqMPMonbG."; }

        [DisplayName("Cost Center Code")]
        public string CostCenterCode { get => "CDC-00070964"; }

        internal SandboxAccount()
        {
        }
    }
}