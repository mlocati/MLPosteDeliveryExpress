using System;

namespace MLPosteDeliveryExpress.Service
{
    public class InvalidAuthorizationException : Exception
    {
        public InvalidAuthorizationException(string responseMessage) : base(responseMessage)
        {
        }
    }
}