using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MLPosteDeliveryExpress.PickupBooking
{
    public enum Status
    {
        [EnumMember(Value = "IN_ESECUZIONE")]
        [Display(Name = "In progress")]
        InProgress,

        [EnumMember(Value = "NON_EFFETTUATO")]
        [Display(Name = "Not carried out")]
        NotDone,

        [EnumMember(Value = "RITIRO_ANNULLATO")]
        [Display(Name = "Cancelled")]
        Cancelled,

        [EnumMember(Value = "INSERITO")]
        [Display(Name = "Inserted")]
        Inserted,

        [EnumMember(Value = "RITIRO_LAV_MAN")]
        [Display(Name = "In charge of operator")]
        InChargeOfOperator,

        [EnumMember(Value = "EFFETTUATO")]
        [Display(Name = "Done")]
        Done,

        [EnumMember(Value = "PRENOTATO")]
        [Display(Name = "Booked")]
        Booked,
    }
}