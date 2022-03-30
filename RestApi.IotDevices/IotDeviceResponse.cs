using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace RestApi.IotDevices
{
    /// <summary>
    /// Response for <see cref="IotDevicesRestClient.ApiUrl"/>.
    /// </summary>
    [DataContract]
    internal class IotDeviceResponse
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
        public IotDeviceData[]? Data { get; set; }
    }

    /// <summary>
    /// Data of price with specific barcode.
    /// </summary>
    [DataContract]
    public class IotDeviceData
    {
        [DataMember]
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [DataMember]
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(MillisecondsDateTimeJsonConverter))]
        public DateTimeOffset DateTimeOffset { get; set; }

        [DataMember]
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [DataMember]
        [JsonPropertyName("operatingParams")]
        public OperatingParams? OperatingParams { get; set; }

        [DataMember]
        [JsonPropertyName("asset")]
        public Asset? Asset { get; set; }
        
        [DataMember]
        [JsonPropertyName("parent")]
        public Asset? Parent { get; set; }
    }

    [DataContract]
    public class Asset
    {
        [DataMember]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [DataMember]
        [JsonPropertyName("alias")]
        public string? Alias { get; set; }
    }

    [DataContract]
    public class OperatingParams
    {
        [DataMember]
        [JsonPropertyName("rotorSpeed")]
        public int RotorSpeed { get; set; }

        [DataMember]
        [JsonPropertyName("slack")]
        public int Slack { get; set; }

        [DataMember]
        [JsonPropertyName("rootThreshold")]
        public float RootThreshold { get; set; }
    }
}