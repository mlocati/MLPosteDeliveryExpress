using System.ComponentModel;

namespace MLPosteDeliveryExpress
{
    public sealed class SandboxAccount : IAccount
    {
        [DisplayName("Client ID")]
        public string ClientID { get => "c7cd7028-0f4c-4623-99b2-a0c088947be5"; }

        [DisplayName("Client Secret")]
        public string ClientSecret { get => "7yh_PwK3Q9X.d_T4-U.YG_S04gyEBcY.36"; }

        [DisplayName("Cost Center Code")]
        public string CostCenterCode { get => "CDC-00070964"; }

        internal SandboxAccount()
        {
        }
    }
}