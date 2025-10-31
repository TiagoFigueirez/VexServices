namespace VexServices.Services.Interfaces
{
    public interface IApiCommunicationService<T> where T : class
    {
        public Task<T> GetAsync(string url, string token);
    }
}
