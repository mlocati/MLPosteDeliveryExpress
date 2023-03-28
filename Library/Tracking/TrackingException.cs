using System;

namespace MLPosteDeliveryExpress.Tracking
{
    public class TrackingException : Exception
    {
        /// <summary>
        /// 0 = OK
        /// 100 - 199 = Errore formale
        /// 200 - 299 = Errore di business
        /// 999 = Errore generico
        /// </summary>

        public readonly int ErrorCode;

        public TrackingException(int errorCode, string message)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}