using VexServices.Models.Vexpense;

namespace VexServices.Services.Interfaces
{
    public interface ICronJobService
    {
        public bool VerificyNextRun();
    }
}
