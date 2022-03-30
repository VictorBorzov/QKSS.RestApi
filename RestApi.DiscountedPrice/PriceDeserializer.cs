using System.Text.Json;

namespace RestApi.DiscountedPrice
{
    internal class PriceDeserializer : IPriceDeserializer
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public PriceResponse? Deserialize(string msg)
        {
            var result = JsonSerializer.Deserialize<PriceResponse>(msg, _jsonSerializerOptions);
            return result;
        }

        public PriceDeserializer()
        {
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }
    }
}