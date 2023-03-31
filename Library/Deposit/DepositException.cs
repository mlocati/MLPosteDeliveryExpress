using System;

namespace MLPosteDeliveryExpress.Deposit
{
    public class DepositException : Exception
    {
        /// <summary>
        /// Cliente Obbligatorio.
        /// </summary>
        public const string ERRORCODE_MISSING_CUSTOMER = "E0001";

        /// <summary>
        /// Limite inferiore superiore a limite superiore.
        /// </summary>
        public const string ERRORCODE_LOWERLIMIT_GREATERTHAN_UPPERLIMIT = "E0002";

        /// <summary>
        /// Per i parametri inseriti nessun dato estratto.
        /// </summary>
        public const string ERRORCODE_NO_DATA_EXTRACTED = "E0003";

        /// <summary>
        /// Range date troppo ampio (limitare a 10 gg).
        /// </summary>
        public const string ERRORCODE_DATE_RANGE_TOO_WIDE = "E0004";

        /// <summary>
        /// Delimitare la ricerca.
        /// </summary>
        public const string ERRORCODE_DEFINE_SEARCH = "E0018";

        /// <summary>
        /// May be the value of one of the ERRORCODE_... constants above.
        /// </summary>
        public readonly string ErrorCode;

        public DepositException(string errorCode, string message)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}