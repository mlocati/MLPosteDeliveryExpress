using System;
using System.ComponentModel;

namespace MLPosteDeliveryExpress
{
    public class Account : IAccount, ICloneable
    {
        public static readonly SandboxAccount Sandbox = new();

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

        public object Clone()
        {
            return new Account(this.ClientID, this.ClientSecret, this.CostCenterCode);
        }
    }
}