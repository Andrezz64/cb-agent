using Microsoft.AspNetCore.Mvc;

namespace cb_agent.Services.Interfaces.Controller;

public interface IProcessController
{
    public IActionResult GetRunningProcessFromMachine();
}