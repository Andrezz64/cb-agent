using cb_agent.Services.Interfaces;
using cb_agent.Modules;
using Microsoft.AspNetCore.Mvc;
using cb_agent.Repository.Interfaces;
using cb_agent.Utils;
using cb_agent.Models.DTO;
using cb_agent.Services.Interfaces.Controller;

namespace cb_agent.Services.Classes.Controllers;
public class ServiceControllerService : ControllerBase, IServiceController
{
    private readonly IService _service;
    private readonly OSManager _os = new();
    private readonly ILogs _log;
    private readonly ErrorHandler _errorHandler = new();

    public ServiceControllerService(IService service, ILogs log)
    {
        _service = service;
        _log = log;
    }
    public IActionResult Delete(int id)
    {
        try
        {

            _service.Delete(id);
            return StatusCode(204, new { });
        }
        catch (Exception ex)
        {
            return _errorHandler.InvokeError(ex);
        }
    }

    public IActionResult Execute(int id)
    {
        try
        {
            Service ServiceDB = _service.ReadOneById(id);
            bool execIsSucess = _os.StartExe(ServiceDB.Exe_path, ServiceDB.Params);
            if (execIsSucess != true)
            {
                _log.Critical("Service Start Failed: "+ServiceDB.Name, "An Error occurred at the application start", id);
                return StatusCode(500, new { Status = "Error", msg = "Service Start Failed: "+ServiceDB.Name});
            }
            _log.Information("Application "+ServiceDB.Name+" Started", "The passed application started successfully", id);
            return Ok(new
            {
                Status = "Sucess",
                AppName = ServiceDB.Name
            });

        }
        catch (Exception ex)
        {
           return _errorHandler.InvokeError(ex);
        }

    }

    public IActionResult Get()
    {
        try
        {
            return Ok(_service.ReadAll());

        }
        catch (Exception ex)
        {
            return _errorHandler.InvokeError(ex);
        }
    }
    public IActionResult Patch(int id, Service service)
    {
        if (id != service.Service_id)
        {
            return BadRequest(new
            {
                status = "Error",
                msg = "The Body ID and URL param have to be equal."

            });
        }
        try
        {
            service.Service_id = id;
            _service.Update(service);
            return StatusCode(201, new { });
        }
        catch (Exception ex)
        {
            return _errorHandler.InvokeError(ex);
        }

    }
    public IActionResult Post(Service service)
    {
        try
        {
            service.Status = "Pausado";
            _service.Create(service);
            return Ok(service);

        }
        catch (Exception ex)
        {
            return _errorHandler.InvokeError(ex);
        }
    }
}