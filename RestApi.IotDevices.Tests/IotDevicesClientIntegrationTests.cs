using System.Threading.Tasks;
using NUnit.Framework;

namespace RestApi.IotDevices.Tests;

public class IotDevicesClientIntegrationTests
{
    private IotDevicesRestClient _restClient = new IotDevicesRestClient();
    [SetUp]
    public void Setup()
    {
        _restClient = new IotDevicesRestClient
        {
            IotDeviceDeserializer = new IotDeviceDeserializer(),
            Logger = new TestLogger(),
        };
    }

        [Test]
        [TestCase("WrongStatus", 1, "11111-111", ExpectedResult = 0)]
        [TestCase("STOPPED", 2, "04-2019", ExpectedResult = 2)]
        public async Task<int> T01_CheckIotDevicesNumber(string statusQuery, int threshold, string dateStr) => await _restClient.GetIotDevicesAsync(statusQuery, threshold, dateStr);
}