using System.Text.Json.Serialization;

namespace VexServices.Models.Vexpense
{
    public class ExpenseType
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("integration_id")]
        public int IntegrationId { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("on")]
        public bool On { get; set; }
    }
}
