namespace RestApi.DiscountedPrice
{
    internal interface IPriceDeserializer
    {
        PriceResponse? Deserialize(string msg);
    }
}