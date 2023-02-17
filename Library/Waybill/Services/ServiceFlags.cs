using System;

namespace MLPosteDeliveryExpress.Waybill.Services
{
    [Flags]
    public enum ServiceFlags
    {
        None = 0b0,
        InWaybill = 0b1,
        NotInWaybill = 0b10,
        OnlyForItalianShipments = 0b100,
        OnlyForInternationalShipments = 0b1000,
        OnlyUPS = 0b10000,
        OnlyOnePackage = 0b100000,
        InwaybillOnlyTriplet = 0b1000000,
    }
}