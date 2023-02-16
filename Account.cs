using System.ComponentModel;

namespace MLPosteDeliveryExpress
{
    public class Account
    {
        public const string SANDBOX_COST_CENTER_CODE = "CDC-00070964";

        [DisplayName("Client ID")]
        public string ClientID { get; set; }

        [DisplayName("Client Secret")]
        public string ClientSecret { get; set; }

        [DisplayName("Cost Center Code")]
        public string CostCenterCode { get; set; }

        public Account(string clientID, string clientSecret, string costCenterCode)
        {
            this.ClientID = clientID;
            this.ClientSecret = clientSecret;
            this.CostCenterCode = costCenterCode;
        }
    }
}