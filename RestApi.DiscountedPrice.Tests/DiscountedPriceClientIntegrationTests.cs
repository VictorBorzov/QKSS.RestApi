using System.Threading.Tasks;
using NUnit.Framework;

namespace RestApi.DiscountedPrice.Tests
{
    public class DiscountedPriceClientIntegrationTests
    {
        private DiscountedPricesRestClient _restClient = new DiscountedPricesRestClient();

        [SetUp]
        public void Setup()
        {
             _restClient = new DiscountedPricesRestClient
            {
                PriceDeserializer = new PriceDeserializer(),
                Logger = new TestLogger(),
            };

        }

        [Test]
        [TestCase(1, ExpectedResult = -1)]
        [TestCase(74002314, ExpectedResult = 2964)]
        public async Task<int> T01_CheckDiscountedPrice(int barcode) => await _restClient.GetDiscountedPriceAsync(barcode);
    }
}