using System.Text.Json.Serialization;

namespace VexServices.Models.Vexpense
{
    public class Report
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("external_id")]
        public int? ExternalId { get; set; }
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
        [JsonPropertyName("device_id")]
        public int? DeviceId { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("status")]
        public string? Status { get; set; }
        [JsonPropertyName("approval_stage_id")]
        public int ApprovalStageId { get; set; }
        [JsonPropertyName("approval_user_id")]
        public int? ApprovalUserId { get; set; }
        [JsonPropertyName("approval_date")]
        public DateTime ApprovalDate { get; set; }
        [JsonPropertyName("payment_date")]
        public DateTime? PaymentDate { get; set; }
        [JsonPropertyName("payment_method_id")]
        public int PaymentMethodId { get; set; }
        [JsonPropertyName("observation")]
        public string? Observation { get; set; }
        [JsonPropertyName("paying_company_id")]
        public int PayingCompanyId { get; set; }
        [JsonPropertyName("on")]
        public bool On { get; set; }
        [JsonPropertyName("justification")]
        public string? Justification { get; set; }
        [JsonPropertyName("pdf_link")]
        public string? PdfLink { get; set; }
        [JsonPropertyName("excel_link")]
        public string? ExcekLink { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }
        [JsonPropertyName("updated_at")]
        public DateTime? UpdateAt { get; set; }
        [JsonPropertyName("expenses")]
        ExpensesWapper? Expenses { get; set; }
    }
}
