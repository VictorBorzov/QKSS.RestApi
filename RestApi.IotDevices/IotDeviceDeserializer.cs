using System.Text.Json;

namespace RestApi.IotDevices
{
    internal class IotDeviceDeserializer : IIotDeviceDeserializer
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public IotDeviceResponse? Deserialize(string msg)
        {
            var result = JsonSerializer.Deserialize<IotDeviceResponse>(msg, _jsonSerializerOptions);
            return result;
        }

        public IotDeviceDeserializer()
        {
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }
    }
}