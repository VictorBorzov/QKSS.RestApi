using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApi.DiscountedPrice
{
    public static class Program
    {
        public static async Task  Main(string[] args)
        {
            var barcode = ParseBarcode(args);

            
            var client = new DiscountedPricesRestClient
            {
                PriceDeserializer = new PriceDeserializer(),
                Logger = new ConsoleLogger(),
            };

            var result = await client.GetDiscountedPriceAsync(barcode);
            Console.WriteLine(result);
        }

        private static int ParseBarcode(IEnumerable<string> args)
        {
            foreach (var s in args)
            {
                if (int.TryParse(s, out var result))
                    return result;
            }

            throw new ArgumentException("Couldn't parse barcode.");
        }
    }
}