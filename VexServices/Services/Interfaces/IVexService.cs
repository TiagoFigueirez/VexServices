using VexServices.Models.Vexpense;

namespace VexServices.Services.Interfaces
{
    public interface IVexService
    {
        public Task<bool> GetReportsVex();
    }
}
