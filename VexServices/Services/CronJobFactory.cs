using VexServices.Services.Interfaces;

namespace VexServices.Services
{
    public class CronJobFactory : ICronJobFactory
    {
        public ICronJobService Create(string cronExpression)
        {
            return new CronJobService(cronExpression);
        }
    }
}
