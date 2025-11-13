namespace VexServices.DTO
{
    public class TituloDto
    {
        public string? Prefixo { get; set; }
        public int? NTitulo { get; set; }
        public int? Parcela { get; set; } = 001;
        public string? Tipo { get; set; }
        public int? NaturezaId { get; set; }
        public int? FornecedorId { get; set; }
        public DateTime? DTEmissao { get; set; }
        public DateTime? VenctoReal { get; set; }
        public decimal? ValorTitulo { get; set; }
    }
}
