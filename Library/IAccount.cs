namespace MLPosteDeliveryExpress
{
    public interface IAccount
    {
        public string ClientID { get; }

        public string ClientSecret { get; }

        public string CostCenterCode { get; }
    }
}