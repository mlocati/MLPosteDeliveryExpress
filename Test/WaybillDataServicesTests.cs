using MLPosteDeliveryExpress.Waybill.Request;
using MLPosteDeliveryExpress.Waybill.Services;
using System.Text.Json;

namespace Test
{
    [TestClass]
    public class WaybillDataServicesTests
    {
        [TestMethod]
        public void SerializationWorks()
        {
            var originalServices = new WaybillDataServices();
            originalServices.Add(
                new TimeDefiniteH9(),
                new TimeDefiniteH10(),
                new TimeDefiniteH12(),
                new DeliveryOnAppointment(),
                new ScheduledDelivery(new ScheduledDelivery.Day(friday: ScheduledDelivery.Hour.Afternoon), "ciao"),
                new DeliveryOnSaturnday(),
                new DeliveryInTheEvening(),
                new FixedDayDelivery(7, 3, FixedDayDelivery.TimeSlot.Afternoon),
                new DeliveryToTheFloor(true),
                new DeliveryToTheNeighbour("Mario Rossi"),
                new CollectByAppointment(),
                new CollectOnTheFloor(true)
            );
            var json = JsonSerializer.Serialize(originalServices, new JsonSerializerOptions()
            {
                WriteIndented = true,
            });
            var unserializedServices = JsonSerializer.Deserialize<WaybillDataServices>(json);
            Assert.IsTrue(originalServices.Equals(unserializedServices));
        }

        private static string NormalizeJson(string json)
        {
            return json.Trim().Replace("\r\n", "\n").Replace('\r', '\n');
        }
    }
}