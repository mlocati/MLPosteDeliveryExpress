using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLPosteDeliveryExpress;
using MLPosteDeliveryExpress.DeliveryPoint;

namespace Test
{
    [TestClass]
    public class DeliveryPointTests
    {
        [TestMethod]
        [DataRow(ServiceType.PuntoPoste)]
        [DataRow(ServiceType.Fermoposta)]
        public void FindDeliveryPoints(ServiceType serviceType)
        {
            var zipCode = "00144";
            var deliveryPoints = Finder.FindAsync(Account.Sandbox, zipCode, serviceType).ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.IsNotNull(deliveryPoints);
            var deliveryPoint = deliveryPoints.Count > 0 ? deliveryPoints[0] : null;
            Assert.IsNotNull(deliveryPoint, "Should return at least one delivery point");
            Assert.IsTrue(deliveryPoint.OfficeCode.Length > 0, "Delivery point code must not be empty");
            Assert.AreEqual(serviceType, deliveryPoint.ServiceType);
        }
    }
}