namespace RestApi.IotDevices
{
    internal interface IIotDeviceDeserializer
    {
        IotDeviceResponse? Deserialize(string msg);
    }
}