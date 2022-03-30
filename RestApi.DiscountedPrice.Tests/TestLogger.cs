using NUnit.Framework;

namespace RestApi.DiscountedPrice.Tests
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