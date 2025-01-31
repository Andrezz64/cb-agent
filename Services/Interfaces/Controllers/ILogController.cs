using Microsoft.AspNetCore.Mvc;

namespace cb_agent.Services.Interfaces.Controller;
public interface ILogController
{
    public IActionResult Get();
    public IActionResult Post(Log log);
    public IActionResult Delete(int id);
    public IActionResult Patch(int id,Log log);
}