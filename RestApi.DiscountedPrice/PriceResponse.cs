using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace RestApi.DiscountedPrice
{
    /// <summary>
    /// Response for <see cref="DiscountedPricesRestClient.ApiUrl"/>.
    /// </summary>
    [DataContract]
    internal class PriceResponse
    {
        [DataMember]
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [DataMember]
        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [DataMember]
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [DataMember]
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [DataMember]
        [JsonPropertyName("data")]
        public PriceResponseData[]? Data { get; set; }
    }

    /// <summary>
    /// Data of price with specific barcode.
    /// </summary>
    [DataContract]
    public class PriceResponseData
    {
        [DataMember]
        [JsonPropertyName("barcode")]
        public string? Barcode { get; set; }

        [DataMember]
        [JsonPropertyName("item")]
        public string? Item { get; set; }

        [DataMember]
        [JsonPropertyName("price")]
        public int Price { get; set; }

        [DataMember]
        [JsonPropertyName("discount")]
        public int Discount { get; set; }
    }
}