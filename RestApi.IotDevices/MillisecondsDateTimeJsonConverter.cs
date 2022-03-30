using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestApi.IotDevices
{
    public class MillisecondsDateTimeJsonConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(reader.GetInt64());
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateTimeOffset dateTimeOffset,
            JsonSerializerOptions options)
        {
            writer.WriteNumberValue(dateTimeOffset.ToUnixTimeMilliseconds());
        }
    }
}