namespace RestApi.DiscountedPrice
{
    public interface ILogger
    {
        void Error(string msg);

        void Warn(string msg);

        void Info(string msg);
    }
}