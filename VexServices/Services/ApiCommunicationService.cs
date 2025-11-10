using System.Text.Json;
using VexServices.Converters;
using VexServices.Services.Interfaces;

namespace VexServices.Services
{
    public class ApiCommunicationService<T> : IApiCommunicationService<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ApiCommunicationService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            _jsonOptions.Converters.Add(new DateTimeJsonConverter());
        }

        public async Task<T?> GetAsync(string url, string token)
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

                return JsonSerializer.Deserialize<T>(json, _jsonOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao acessar API: {ex.Message}");
                throw;
            }
        }
    }
}
