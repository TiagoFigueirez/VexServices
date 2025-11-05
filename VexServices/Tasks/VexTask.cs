using VexServices.Services;
using VexServices.Services.Interfaces;

namespace VexServices.Tasks
{
    public class VexTask : BackgroundService
    {
        private readonly ICronJobService _cronService;
        private readonly ILogger<VexTask> _logger;
        private readonly IServiceProvider _serviceProvider;

        public VexTask( ILogger<VexTask> logger, IConfiguration config, IServiceProvider
            serviceProvider, ICronJobFactory cronFactory)
        {
            
            _logger = logger;
            _serviceProvider = serviceProvider;
            var cronExpression = config["CronJobs:VexTask"];
            _cronService = cronFactory.Create(cronExpression);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("{JobName} iniciado", GetType().Name);
                    var scope = _serviceProvider.CreateScope();
                    var vexService = scope.ServiceProvider.GetService<IVexService>();

                    //if (_cronService.VerificyNextRun())
                    //{
                        var dataVex = await vexService.GetReportsVex();
                    //}

                    //await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
                }
                catch(Exception ex)
                {
                    _logger.LogError("Falha ao executar tarefa", ex.Message);
                }
            }
        }
    }
}
