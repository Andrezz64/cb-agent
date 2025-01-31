using cb_agent.Repository;
using cb_agent.Repository.Classes;
using cb_agent.Repository.Interfaces;
using cb_agent.Services.Classes;
using cb_agent.Services.Classes.Controllers;
using cb_agent.Services.Interfaces;
using cb_agent.Services.Interfaces.Controller;

public class ServicesBuilders
{
    public static void InjectCustomServicesAsDependency(IServiceCollection services)
    {
        services.AddScoped<IServiceController,ServiceControllerService>();
        services.AddScoped<IService,ServiceRepository>();
        services.AddScoped<ILog,LogRepository>();
        services.AddScoped<ILogs,Logs>();
        services.AddScoped<ILogController,LogControllerService>();
        services.AddScoped<ISqlLiteDbContext,SqlLiteDbContext>();
        services.AddScoped<IProcessController,ProcessControllerService>();
        services.AddScoped<IServiceHandlerService,ServiceHandlerService>();
    }
}