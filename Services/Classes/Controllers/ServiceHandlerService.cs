using cb_agent.Modules;
using cb_agent.Repository.Interfaces;
using cb_agent.Services.Interfaces;
using cb_agent.Services.Interfaces.Controller;

namespace cb_agent.Services.Classes;

public class ServiceHandlerService : IServiceHandlerService
{
    private readonly IService _repository;
    private readonly OSManager _os = new();
    private ILogs _logs;

    public ServiceHandlerService(IService repository,ILogs logs)
    {
        _repository = repository;
        _logs = logs;
    }
    public void AutoStartServices()
    {
        // List all the services at the local DB
        List<Service> services = _repository.ReadAllAutoStart();
        // Start every service which have the Autostart equals 1
        foreach (var service in services)
        {

             bool result = _os.StartExe(service.Exe_path,service.Params);
             if(!result)
             {
                _logs.Warning("AutoStart Failed",$"Error while tryng to start service {service.Name}({service.Service_id})",service.Service_id);
             }
            
        }
    }
}