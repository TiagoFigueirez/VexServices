
using System.Text.Json.Serialization;

namespace VexServices.Models.Vexpense
{
    public class ExpenseTypeWapper
    {
        [JsonPropertyName("data")]
        public ExpenseType? Data { get; set; }
    }
}
