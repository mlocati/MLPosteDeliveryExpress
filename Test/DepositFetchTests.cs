using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLPosteDeliveryExpress;
using MLPosteDeliveryExpress.Deposit;
using Filter = MLPosteDeliveryExpress.Deposit.Request.Filter;

namespace Test
{
    [TestClass]
    public class DepositFetchTests
    {
        [TestMethod]
        public void FetchingWorks()
        {
            var filter = new Filter()
            {
                DateFrom = DateOnly.FromDateTime(DateTime.Today.AddDays(-10)),
                DateTo = DateOnly.FromDateTime(DateTime.Today)
            };
            var response = Finder.SubmitAsync(Account.Sandbox, filter).ConfigureAwait(false).GetAwaiter().GetResult();
            List<Status> expectedStatuses = new(Enum.GetValues<Status>());
            expectedStatuses.Sort();
            List<Status> receivedStatuses = new(response.Statuses.StatusList.Count);
            foreach (var item in response.Statuses.StatusList)
            {
                receivedStatuses.Add(item.Status);
            }
            receivedStatuses.Sort();
            CollectionAssert.AreEqual(expectedStatuses, receivedStatuses);

            List<Reason> expectedReasons = new(Enum.GetValues<Reason>());
            expectedReasons.Sort();
            List<Reason> receivedReasons = new(response.Reasons.ReasonList.Count);
            foreach (var item in response.Reasons.ReasonList)
            {
                receivedReasons.Add(item.Reason);
            }
            receivedReasons.Sort();
            CollectionAssert.AreEqual(expectedReasons, receivedReasons);
        }
    }
}