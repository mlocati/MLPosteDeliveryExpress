using System;

namespace MLPosteDeliveryExpress.Deposit
{
    public class ActionException : Exception
    {
        /// <summary>
        /// Cliente Obbligatorio.
        /// </summary>
        public const string ERRORCODE_MISSING_CUSTOMER = "E0001";

        /// <summary>
        /// Per i parametri inseriti nessun dato estratto.
        /// </summary>
        public const string ERRORCODE_NO_DATA_EXTRACTED = "E0003";

        /// <summary>
        /// Indicare almeno un Barcode.
        /// </summary>
        public const string ERRORCODE_MISSING_BARCODE = "E0005";

        /// <summary>
        /// Il contratto non prevede lo svincolo.
        /// </summary>
        public const string ERRORCODE_RELEASE_NOT_INCLUDED_IN_CONTRACT = "E0006";

        /// <summary>
        /// La data non consente più lo svincolo.
        /// </summary>
        public const string ERRORCODE_EXPIRED = "E0007";

        /// <summary>
        /// Lo stato non consente lo svincolo.
        /// </summary>
        public const string ERRORCODE_UNAPPLICABLE = "E0008";

        /// <summary>
        /// Già svincolata.
        /// </summary>
        public const string ERRORCODE_ALREADY_RELEASED = "E0009";

        /// <summary>
        /// Nessuna azione di svincolo ammessa.
        /// </summary>
        public const string ERRORCODE_RELEASE_NOT_ALLOWED = "E0010";

        /// <summary>
        /// Frazionario obbligatorio.
        /// </summary>
        public const string ERRORCODE_FRACTIONAL_MANDATORY = "E0020";

        /// <summary>
        /// Indirizzo abbligatorio.
        /// </summary>
        public const string ERRORCODE_MISSING_ADDRESS = "E0024";

        /// <summary>
        /// Unknown.
        /// </summary>
        public const string ERRORCODE_UNKNOWN = "E0099";

        /// <summary>
        /// May be the value of one of the ERRORCODE_... constants above.
        /// </summary>
        public readonly string ErrorCode;

        public ActionException(string errorCode, string message)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}