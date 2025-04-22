namespace MLPosteDeliveryExpress.DeliveryPoint.Response
{
    public class Exception : System.Exception
    {
        public readonly uint Code;

        public Exception(uint code)
            : base(Exception.DescribeCode(code))
        {
            this.Code = code;
        }

        private static string DescribeCode(uint code)
        {
            if (code >= 100 && code < 200)
            {
                return "Formal error";
            }
            if (code >= 200 && code < 300)
            {
                return "Business error";
            }
            if (code == 999)
            {
                return "Generic error";
            }
            return "Unknown error";
        }
    }
}