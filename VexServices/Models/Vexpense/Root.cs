
using System.Text.Json.Serialization;

namespace VexServices.Models.Vexpense
{
    public class Root
    {
        [JsonPropertyName("request")]
        public string? Request { get; set; }
        [JsonPropertyName("method")]
        public string? Method { get; set; }
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        [JsonPropertyName("data")]
        public List<Report>? Data { get; set; }
    }
}
