using VexServices.Models.Vexpense;
using VexServices.Services.Interfaces;

namespace VexServices.Services
{public class VexService : IVexService
    {
        private readonly IApiCommunicationService<Root>? _apiCommunicationService;
        private readonly IConfiguration _configuration;

        public VexService(IApiCommunicationService<Root>? apiCommunicationService, IConfiguration configuration)
        {
            _apiCommunicationService = apiCommunicationService;
            _configuration = configuration;
        }

        public async Task<Root> GetReportsVex()
        {
            var atualDate = DateTime.Now;
            var token = _configuration["Vexpense:VexTokken"];
            var urlInital = _configuration["Vexpense:URL"];

            var url = urlInital
                      .Replace("{initialDate}", "2025-09-01")
                      .Replace("{finalDate}", DateTime.Now.ToString("yyyy-MM-dd"));

            Root ApiJsonDeserialize = await _apiCommunicationService.GetAsync(url, token);
            
            return ApiJsonDeserialize;
        }
    }
}
