using System;

namespace MLPosteDeliveryExpress.PickupBooking
{
    public class BookingException : Exception
    {
        /// <summary>
        /// Pickup data is mandatory.
        /// </summary>
        public const string ERRORCODE_MISSING_PICKUPDATA = "E0013";

        /// <summary>
        /// Booking type is incorrect.
        /// </summary>
        public const string ERRORCODE_WRONG_BOOKINGTYPE = "E0014";

        /// <summary>
        /// For Paperless booking type, the shipment ID is mandatory
        /// </summary>
        public const string ERRORCODE_MISSING_SHIPMENTID = "E0015";

        /// <summary>
        /// There is already a pickup for the same shipment.
        /// </summary>
        public const string ERRORCODE_DUPLICATED_PICKUP_1 = "E0016";

        /// <summary>
        /// Container type is incorrect.
        /// </summary>
        public const string ERRORCODE_WRONG_CONTAINERTYPE = "E0017";

        /// <summary>
        /// The address data is mandatory.
        /// </summary>
        public const string ERRORCODE_MISSING_ADDRESS = "E0024";

        /// <summary>
        /// Operation is incorrect.
        /// </summary>
        public const string ERRORCODE_WRONG_OPERATION = "E0028";

        /// <summary>
        /// There is already a pickup for the same data.
        /// </summary>
        public const string ERRORCODE_DUPLICATED_PICKUP_2 = "E0029";

        /// <summary>
        /// The shipment ID is incorrect.
        /// </summary>
        public const string ERRORCODE_WRONG_SHIPMENTID_1 = "E0030";

        /// <summary>
        /// The shipment ID is incorrect.
        /// </summary>
        public const string ERRORCODE_WRONG_SHIPMENTID_2 = "E0031";

        /// <summary>
        /// Cancellation is not possible.
        /// </summary>
        public const string ERRORCODE_CANCELLATION_UNAVAILABLE = "E0033";

        /// <summary>
        /// The shipment ID is incorrect.
        /// </summary>
        public const string ERRORCODE_WRONG_SHIPMENTID_3 = "E0034";

        /// <summary>
        /// The time slot is not compatible with today date.
        /// </summary>
        public const string ERRORCODE_INCOMPATIBLE_TIMESLOT = "E0035";

        /// <summary>
        /// The shipment ID is incorrect.
        /// </summary>
        public const string ERRORCODE_WRONG_SHIPMENTID_4 = "E0036";

        /// <summary>
        /// Shipment ID is accepted, but pickup booking is not possible.
        /// </summary>
        public const string ERRORCODE_BOOKING_UNAVAILABLE = "E0037";

        /// <summary>
        /// The pickup date must occur in the future.
        /// </summary>
        public const string ERRORCODE_WRONG_PICKUPDATE = "E0038";

        /// <summary>
        /// There is already a pickup for the same shipment.
        /// </summary>
        public const string ERRORCODE_DUPLICATED_PICKUP_3 = "E0039";

        /// <summary>
        /// Generic error.
        /// <summary>
        public const string ERRORCODE_GENERIC_ERROR = "E0999";

        /// <summary>
        /// May be the value of one of the ERRORCODE_... constants above.
        /// </summary>
        public readonly string ErrorCode;

        public BookingException(string errorCode, string message)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}