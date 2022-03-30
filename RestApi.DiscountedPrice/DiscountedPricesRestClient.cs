using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("RestApi.DiscountedPrice.Tests")]
namespace RestApi.DiscountedPrice
{

    /// <summary>
    /// Rest client, it makes requests and deserializes responses.
    /// </summary>
    internal class DiscountedPricesRestClient
    {
        private const string ApiUrl = "https://jsonmock.hackerrank.com/api/inventory";

        private static readonly HttpClient Client = new HttpClient();

        public IPriceDeserializer? PriceDeserializer { get; set; }

        public ILogger? Logger { get; set; }

        public async Task<int> GetDiscountedPriceAsync(int barcode)
        {
            Client.DefaultRequestHeaders.Accept.Clear();

            var stringTask = Client.GetStringAsync($"{ApiUrl}?barcode={barcode}");

            PriceResponse? priceResponse;
            var msg = await stringTask;
            Logger?.Info($"Message received {msg}");
            try
            {
                priceResponse = PriceDeserializer?.Deserialize(msg);
            }
            catch (Exception e)
            {
                Logger?.Error($"Deserialization error {e.Message}");
                throw;
            }

            if (priceResponse is null)
                Logger?.Warn($"Couldn't map message to {nameof(PriceResponse)}");

            if (priceResponse?.Data == null || priceResponse.Data?.Length == 0)
            {
                Logger?.Warn("Data is empty.");
                return -1;
            }

            var price = priceResponse.Data![0].Price;
            var discount = priceResponse.Data[0].Discount;
            var discountedPrice = price - discount / 100f * price;
            return (int)Math.Round(discountedPrice);
        }
    }
}