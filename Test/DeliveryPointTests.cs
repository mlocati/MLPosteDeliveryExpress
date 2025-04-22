using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLPosteDeliveryExpress;

namespace Test
{
    [TestClass]
    public class DeliveryPointTests
    {
        [TestMethod]
        public void FinderWorks()
        {
            var zipCode = "00144";
            var deliveryPointType = MLPosteDeliveryExpress.DeliveryPoint.ServiceType.PuntoPoste;
            var deliveryPoints = MLPosteDeliveryExpress.DeliveryPoint.Finder.FindAsync(Account.Sandbox, zipCode, deliveryPointType).ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.IsNotNull(deliveryPoints);
            var deliveryPoint = deliveryPoints.Count > 0 ? deliveryPoints[0] : null;
            Assert.IsNotNull(deliveryPoint, "Should return at least one delivery point");
            Assert.IsTrue(deliveryPoint.OfficeCode.Length > 0, "Delivery point code must not be empty");
        }
    }
}