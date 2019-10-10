using System.Text.Json;

namespace Airport.API.Json
{
    public static class DefaultJsonSerializerOptions
    {
        public static JsonSerializerOptions Options => new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreNullValues = true
        };
    }
}
