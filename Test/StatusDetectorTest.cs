using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLPosteDeliveryExpress.Service;

namespace Test
{
    [TestClass]
    public class StatusDetectorTest
    {
        [TestMethod]
        public void DetectStatus()
        {
            try
            {
                StatusDetector.IsWebServiceAvailableAsync(false).ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch (Exception x)
            {
                Assert.Fail("StatusDetector shouldn't throw an exception, but we had " + x.ToString());
            }
            try
            {
                StatusDetector.IsWebServiceAvailableAsync(true).ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch (Exception x)
            {
                Assert.Fail("StatusDetector shouldn't throw an exception, but we had " + x.ToString());
            }
        }
    }
}