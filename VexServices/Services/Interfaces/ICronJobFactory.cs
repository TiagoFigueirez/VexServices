namespace VexServices.Services.Interfaces
{
    public interface ICronJobFactory
    {
        public ICronJobService Create(string cronExpression);
    }
}
