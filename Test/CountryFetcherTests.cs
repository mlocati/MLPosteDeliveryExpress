using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLPosteDeliveryExpress;
using MLPosteDeliveryExpress.Country;

namespace Test
{
    [TestClass]
    public class CountryFetcherTests
    {
        private static IList<Country>? Countries = null;

        [ClassInitialize]
        public static void FetchCountries(TestContext context)
        {
            Options.Sandbox = true;
            var account = new Account("my-client-it", "my-client-secret", Account.SANDBOX_COST_CENTER_CODE);
            CountryFetcherTests.Countries = Fetcher.FetchAsync(account).GetAwaiter().GetResult().Countries;
        }

        [TestMethod]
        public void CountriesContainsItaly()
        {
            Assert.IsNotNull(CountryFetcherTests.Countries);
            var countries = from country in CountryFetcherTests.Countries
                            where country.ISO2 == "IT"
                            select country;
            Assert.IsTrue(countries.ToArray().Length == 1);
            var italy = countries.First();
            Assert.AreEqual("ITA1", italy.ISO4);
            Assert.IsNotNull(italy.States);
            Assert.IsTrue(italy.States.Count > 50 && italy.States.Count < 500);
            var states = from state in italy.States
                         where state.Code == "CO"
                         select state;
            Assert.IsTrue(states.ToArray().Length == 1);
            var como = states.First();
            Assert.AreEqual("Como", como.Name);
        }

        [TestMethod]
        public void CountriesContainsCanada()
        {
            Assert.IsNotNull(CountryFetcherTests.Countries);
            var countries = from country in CountryFetcherTests.Countries
                            where country.ISO4 == "CAN1"
                            select country;
            Assert.IsTrue(countries.ToArray().Length == 1);
            var canada = countries.First();
            Assert.AreEqual("CA", canada.ISO2);
            Assert.IsNotNull(canada.States);
            Assert.IsTrue(canada.States.Count > 2 && canada.States.Count < 500);
        }
    }
}