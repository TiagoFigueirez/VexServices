using System.Text.Json;
using VexServices.Services.Interfaces;

namespace VexServices.Services
{
    public class ApiCommunicationService<T> : IApiCommunicationService<T> where T : class
    {
        private readonly HttpClient _httpClient;

        public ApiCommunicationService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            
        }

        public async Task<T> GetAsync(string url, string token)
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    _httpClient.DefaultRequestHeaders.Remove("Authorization");
                    _httpClient.DefaultRequestHeaders.Add("Authorization", token);
                }

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao acessar API: {ex.Message}");
                throw;
            }
        }
    }
}
