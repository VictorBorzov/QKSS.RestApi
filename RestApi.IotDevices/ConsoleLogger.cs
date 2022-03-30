using System;

namespace RestApi.IotDevices
{
    internal class ConsoleLogger : ILogger
    {
        public void Error(string msg)
        {
            var tmp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine(msg);
            Console.ForegroundColor = tmp;
        }

        public void Warn(string msg)
        {
            var tmp = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Out.WriteLine(msg);
            Console.ForegroundColor = tmp;
        }

        public void Info(string msg)
        {
            Console.Out.WriteLine(msg);
        }
    }
}