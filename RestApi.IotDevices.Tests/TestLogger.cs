using NUnit.Framework;

namespace RestApi.IotDevices.Tests
{
    public class TestLogger : ILogger
    {
        public void Error(string msg)
        {
            TestContext.Progress.WriteLine(msg);
        }

        public void Warn(string msg)
        {
            TestContext.Progress.WriteLine(msg);
        }

        public void Info(string msg)
        {
            TestContext.Progress.WriteLine(msg);
        }
    }
}