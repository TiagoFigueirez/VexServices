using VexServices.DTO;
using VexServices.Extensions;
using VexServices.Models.Vexpense;
using VexServices.Repository.Interface;
using VexServices.Services.Interfaces;

namespace VexServices.Services
{public class VexService : IVexService
    {
        private readonly IApiCommunicationService<Root>? _apiCommunicationService;
        private readonly IConfiguration _configuration;
        private readonly IVexRepository _vexRepository;

        public VexService(IApiCommunicationService<Root>? apiCommunicationService, IConfiguration configuration, 
                          IVexRepository vexRepository)
        {
            _apiCommunicationService = apiCommunicationService;
            _configuration = configuration;
            _vexRepository = vexRepository;
        }

        public async Task<bool> GetReportsVex()
        {
            var atualDate = DateTime.Now;
            var token = _configuration["Vexpense:VexTokken"];
            var urlInital = _configuration["Vexpense:URL"];
            var ListTitulo = new List<TituloDto>();

            var url = urlInital
                      .Replace("{initialDate}", "2025-09-01")
                      .Replace("{finalDate}", DateTime.Now.ToString("yyyy-MM-dd"));

            Root ApiJsonDeserialize = await _apiCommunicationService.GetAsync(url, token);

            foreach (var report in ApiJsonDeserialize.Data)
            {
                var ExpensesReport = report.Expenses?.Data ?? new List<Expense>();

                foreach (var expense in ExpensesReport)
                {
                    var expenseType = expense.ExpenseType?.Data;

                    TituloDto expenseDto = new TituloDto()
                    {
                        Prefixo = "VEX",
                        NTitulo = report.Id,
                        Tipo = "PA",
                        NaturezaId = Convert.ToInt32(expenseType?.Description?.GetValueBetweenParentheses()),
                        FornecedorId = report.UserId,
                        DTEmissao = report.ApprovalDate ?? DateTime.MinValue,
                        VenctoReal = report.ApprovalDate ?? DateTime.MinValue,
                        ValorTitulo = expense.Value
                    };

                    ListTitulo.Add(expenseDto);
                }
            }
            
            return _vexRepository.InsertDB(ListTitulo);
        }
    }
}
