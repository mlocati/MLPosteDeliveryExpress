using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLPosteDeliveryExpress.Waybill.Request;
using System.Text.Json;
using Services = MLPosteDeliveryExpress.Waybill.Services;

namespace Test
{
    [TestClass]
    public class WaybillDataServicesTests
    {
        [TestMethod]
        public void SerializationWorks()
        {
            var timeOnly1 = new TimeOnly(8, 30);
            var timeOnly2 = new TimeOnly(14, 59);
            var dateOnly = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
            var originalServices = new WaybillDataServices();
            originalServices.Add(
                new Services.TimeDefiniteH9(),
                new Services.TimeDefiniteH10(),
                new Services.TimeDefiniteH12(),
                new Services.DeliveryOnAppointment(),
                new Services.ScheduledDelivery(new Services.ScheduledDelivery.Day(friday: Services.ScheduledDelivery.Hour.Afternoon), "ciao"),
                new Services.DeliveryOnSaturnday(),
                new Services.DeliveryInTheEvening(),
                new Services.FixedDayDelivery(7, 3, Services.FixedDayDelivery.TimeSlot.Afternoon),
                new Services.DeliveryToTheFloor(true),
                new Services.DeliveryToTheNeighbour("Mario Rossi"),
                new Services.CollectByAppointment(),
                new Services.CollectOnTheFloor(true),
                new Services.CashOnDelivery(789456.89M, Services.CashOnDelivery.PaymentModes.BankCheck),
                new Services.FullCoverageItaly(741.99M),
                new Services.ReverseAtHome(),
                new Services.RoundTrip(),
                new Services.ReturnToSender(Services.ReturnToSender.Reasons.SendBack),
                new Services.DeliveryToLockerInternational("1234", "Name of the locker"),
                new Services.MultiPack(),
                new Services.AtHome(),
                new Services.PuntoPoste("4321", "Name of the post office"),
                new Services.DeliveryToLockerItaly("12345", "Nome del locker"),
                new Services.PostalOffice("11223", "Ufficio postale / post office"),
                new Services.FullCoverageInternational1500(1500),
                new Services.FullCoverageInternational50000(50000),
                new Services.DeliveryToPointInternational("22220", "Dest point International"),
                new Services.InternationalReverse(),
                new Services.CustomCharges(Services.CustomCharges.Payers.Recipient),
                new Services.PuntoPosteReverse(),
                new Services.PuntoPosteLockerReverse(),
                new Services.PostalOfficeReverse(),
                new Services.ScheduledDay4(timeOnly1, timeOnly2, dateOnly),
                new Services.ScheduledDay3(timeOnly1, timeOnly2, dateOnly),
                new Services.ScheduledDay2(timeOnly1, timeOnly2, dateOnly),
                new Services.ScheduledDay90(timeOnly1, timeOnly2, dateOnly),
                new Services.ScheduledDay60(timeOnly1, timeOnly2, dateOnly),
                new Services.ScheduledDay30(timeOnly1, timeOnly2, dateOnly),
                new Services.ScheduledDayAnyTime(timeOnly1, timeOnly2, dateOnly),
                new Services.ScheduledNight4(timeOnly1, timeOnly2, dateOnly),
                new Services.ScheduledNight3(timeOnly1, timeOnly2, dateOnly),
                new Services.ScheduledNight2(timeOnly1, timeOnly2, dateOnly),
                new Services.ScheduledNight90(timeOnly1, timeOnly2, dateOnly),
                new Services.ScheduledNight60(timeOnly1, timeOnly2, dateOnly),
                new Services.ScheduledNight30(timeOnly1, timeOnly2, dateOnly),
                new Services.ScheduledNight15(timeOnly1, timeOnly2, dateOnly),
                new Services.SameDay4(timeOnly1, timeOnly2, dateOnly),
                new Services.SameDay3(timeOnly1, timeOnly2, dateOnly),
                new Services.SameDay2(timeOnly1, timeOnly2, dateOnly),
                new Services.SameDay90(timeOnly1, timeOnly2, dateOnly),
                new Services.SameDay60(timeOnly1, timeOnly2, dateOnly),
                new Services.SameDay30(timeOnly1, timeOnly2, dateOnly),
                new Services.Instant1(timeOnly1, timeOnly2, dateOnly),
                new Services.Instant2(timeOnly1, timeOnly2, dateOnly),
                new Services.Instant3(timeOnly1, timeOnly2, dateOnly)
            );
            var json = JsonSerializer.Serialize(originalServices, new JsonSerializerOptions()
            {
                WriteIndented = true,
            });
            var unserializedServices = JsonSerializer.Deserialize<WaybillDataServices>(json);
            Assert.IsTrue(originalServices.Equals(unserializedServices));
        }
    }
}