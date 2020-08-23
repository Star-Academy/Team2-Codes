using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Learning.Model
{
    public class CustomDateFormat : JsonConverter<DateTime>
    {
        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
            DateTime.ParseExact(reader.GetString(),
                "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);

        public override void Write(
            Utf8JsonWriter writer,
            DateTime dateTime,
            JsonSerializerOptions options) =>
            writer.WriteStringValue(dateTime.ToString(
                "MM/dd/yyyy", CultureInfo.InvariantCulture));
    }
}