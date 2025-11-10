using System.Text.Json.Serialization;

namespace VexServices.Models.Vexpense
{
    public class Expense
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("user_id")]
        public int? UserId { get; set; }
        [JsonPropertyName("expense_id")]
        public int? ExpenseId { get; set; }
        [JsonPropertyName("report_id")]
        public int? ReportId { get; set; }
        [JsonPropertyName("device_id")]
        public int? DeviceId { get; set; }
        [JsonPropertyName("integration_id")]
        public int? IntegrationId { get; set; }
        [JsonPropertyName("external_id")]
        public int? ExternalId { get; set; }
        [JsonPropertyName("expense_type_id")]
        public int? ExpenseTypeId { get; set; }
        [JsonPropertyName("payment_method_id")]
        public int? PaymentMethodId { get; set; }
        [JsonPropertyName("paying_company_id")]
        public int? PayingCompanyId { get; set; }
        [JsonPropertyName("route_id")]
        public int? RouteId { get; set; }
        [JsonPropertyName("receipt_url")]
        public string? ReceiptUrl { get; set; }
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }
        [JsonPropertyName("value")]
        public decimal? Value { get; set; }
        [JsonPropertyName("course_id")]
        public int? CourseId { get; set; }
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("validate")]
        public string? Validate { get; set; }
        [JsonPropertyName("observation")]
        public string? Observation { get; set; }
        [JsonPropertyName("rejected")]
        public int? Rejected { get; set; }
        [JsonPropertyName("on")]
        public bool On { get; set; }
        [JsonPropertyName("reimbursable")]
        public bool Reimbursable { get; set; }
        [JsonPropertyName("mileage")]
        public string? Mileage { get; set; }
        [JsonPropertyName("mileage_value")]
        public string? MileageValue { get; set; }
        [JsonPropertyName("original_currency_iso")]
        public string? OriginalCurrencyIso { get; set; }
        [JsonPropertyName("exchange_rate")]
        public decimal? ExchangeRate { get; set; }
        [JsonPropertyName("converted_value")]
        public decimal? ConvertedValue { get; set; }
        [JsonPropertyName("converted_currency_iso")]
        public string? ConvertedCurrencyIso { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }
        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [JsonPropertyName("expense_type")]
        public ExpenseTypeWapper? ExpenseType { get; set; }
    }
}
