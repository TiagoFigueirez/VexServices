using VexServices.Services.Interfaces;
using VexServices.Services;
using VexServices.Tasks;

var builder = Host.CreateApplicationBuilder(args);

//Services
builder.Services.AddTransient<IVexService, VexService>();
builder.Services.AddTransient(typeof(IApiCommunicationService<>), typeof(ApiCommunicationService<>));
builder.Services.AddSingleton<ICronJobFactory, CronJobFactory>();
builder.Services.AddHttpClient();
builder.Services.AddHostedService<VexTask>();


var host = builder.Build();
host.Run();
