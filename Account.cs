namespace MLPosteDeliveryExpress
{
    public class Account
    {
        public string DisplayName { get; set; }

        public string ClientID { get; set; }

        public string ClientSecret { get; set; }

        public string CostCenterCode { get; set; }

        public Account(string displayName, string clientID, string clientSecret, string costCenterCode)
        {
            this.DisplayName = displayName;
            this.ClientID = clientID;
            this.ClientSecret = clientSecret;
            this.CostCenterCode = costCenterCode;
        }
    }
}