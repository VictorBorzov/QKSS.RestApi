using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApi.IotDevices
{
    public static class Program
    {
        public static async Task  Main(string[] args)
        {
            var (statusQuery, threshold, dateStr) = ParseArgs(args);

            var client = new IotDevicesRestClient
            {
                IotDeviceDeserializer = new IotDeviceDeserializer(),
                Logger = new ConsoleLogger(),
            };

            var result = await client.GetIotDevicesAsync(statusQuery, threshold, dateStr);

            Console.WriteLine(result);
        }

        private static (string statusQuery, int threshold, string dateStr) ParseArgs(IReadOnlyList<string> args)
        {
            if (args.Count >= 3 && int.TryParse(args[1], out var threshold))
                return (args[0], threshold, args[2]);

            throw new ArgumentException("Couldn't parse status query, threshold, and date string.");
        }
    }
}