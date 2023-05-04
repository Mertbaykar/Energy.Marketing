using System.Text.Json.Serialization;
using System.Text.Json;

namespace JSONConverters
{
    public class DateTimeCustomConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                if (string.IsNullOrEmpty(reader.GetString()))
                {

                }
                if (DateTimeOffset.TryParse(reader.GetString(), out DateTimeOffset result))
                {
                    return new DateTime(result.Year, result.Month, result.Day);
                }
                if (DateTime.TryParse(reader.GetString(), out DateTime dateResult))
                {
                    return new DateTime(dateResult.Year, dateResult.Month, dateResult.Day);
                }
               
                return DateTime.MinValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}