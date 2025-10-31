using NCrontab;
using VexServices.Services.Interfaces;

namespace VexServices.Services
{
    public class CronJobService : ICronJobService
    {

        private CrontabSchedule _schedule;
        private DateTime _nextRun;

        public CronJobService(string cronExpression)
        {
            if (string.IsNullOrEmpty(cronExpression))
                throw new ArgumentNullException(nameof(cronExpression));
            
            _schedule = CrontabSchedule.Parse(cronExpression);
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
        }

        public bool VerificyNextRun()
        {
            var now = DateTime.Now;
            if (now > _nextRun)
            {
                return true;
            }

            return false;
        }
    }
}
