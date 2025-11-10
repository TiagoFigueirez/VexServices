using System.Text.Json.Serialization;

namespace VexServices.Models.Vexpense
{
    public class ExpensesWapper
    {
        [JsonPropertyName("data")]
        public List<Expense>? Data { get; set; }
    }
}
