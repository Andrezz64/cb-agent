namespace cb_agent.Services.Interfaces.Controller;
using cb_agent;
using Microsoft.AspNetCore.Mvc;

public interface IServiceController
{
    public IActionResult Get();
    public IActionResult Post(Service service);
    public IActionResult Delete(int id);
    public IActionResult Patch(int id,Service service);
    public IActionResult Execute(int id);
}