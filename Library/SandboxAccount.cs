using System.ComponentModel;

namespace MLPosteDeliveryExpress
{
    public sealed class SandboxAccount : ISandboxAccount
    {
        [DisplayName("Client ID")]
        public string ClientID { get => "980a6661-cd8c-43c4-b6a1-d8f2a5593994"; }

        [DisplayName("Client Secret")]
        public string ClientSecret { get => "3TW8Q~zWspadrQUNUKhFiu4eCoogittm~ZFK8bv6"; }

        [DisplayName("Cost Center Code")]
        public string CostCenterCode { get => "CDC-00070964"; }

        internal SandboxAccount()
        {
        }
    }
}