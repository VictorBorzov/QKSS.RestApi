using System;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("RestApi.IotDevices.Tests")]
namespace RestApi.IotDevices
{

    /// <summary>
    /// Rest client, it makes requests and deserializes responses.
    /// </summary>
    internal class IotDevicesRestClient
    {
        private const string ApiUrl = "https://jsonmock.hackerrank.com/api/iot_devices/search";

        private static readonly HttpClient Client = new HttpClient();

        public IIotDeviceDeserializer? IotDeviceDeserializer { get; set; }

        public ILogger? Logger { get; set; }

        private static (int? month, int? year) ParseDate(string date)
        {
            const char delimiter = '-';
            var data = date.Split(delimiter);
            if (data.Length == 2 && int.TryParse(data[0], out var month) && int.TryParse(data[1], out var year))
                return (month, year);

            return (null, null);
        }
        public async Task<int> GetIotDevicesAsync(string statusQuery, int threshold, string dateStr)
        {
            var (month, year) = ParseDate(dateStr);
            if (month == null || year == null)
                return 0;
                
            Client.DefaultRequestHeaders.Accept.Clear();

            var stringTask = Client.GetStringAsync($"{ApiUrl}?status={statusQuery}");

            IotDeviceResponse? iotDeviceResponse;
            var msg = await stringTask;
            Logger?.Info($"Message received {msg}");
            try
            {
                iotDeviceResponse = IotDeviceDeserializer?.Deserialize(msg);
            }
            catch (Exception e)
            {
                Logger?.Error($"Deserialization error {e.Message}");
                throw;
            }

            if (iotDeviceResponse is null)
                Logger?.Warn($"Couldn't map message to {nameof(IotDeviceResponse)}");

            if (iotDeviceResponse?.Data == null || iotDeviceResponse.Data?.Length == 0)
            {
                Logger?.Warn("Data is empty.");
                return 0;
            }

            var result = iotDeviceResponse.Data!
                .Where(i => i.DateTimeOffset.Month == month && i.DateTimeOffset.Year == year)
                .Count(i => i.OperatingParams?.RootThreshold >= threshold);

            return result;
        }
    }
}