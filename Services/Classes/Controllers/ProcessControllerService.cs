using Microsoft.AspNetCore.Mvc;
using cb_agent.Modules;
using cb_agent.Services.Interfaces.Controller;
using cb_agent.Utils;

namespace cb_agent.Services.Classes.Controllers;

public class ProcessControllerService : ControllerBase, IProcessController
{
    private readonly OSManager _os = new();
    private readonly ErrorHandler _error = new();
    public IActionResult GetRunningProcessFromMachine()
    {
       try
       {
         return Ok(_os.ListRunningProcesses());
       }
       catch (Exception ex)
       {    
        return _error.InvokeError(ex);
       }
    }
}