using cb_agent.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using cb_agent.Services.Interfaces.Controller;

namespace cb_agent.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]

public class LogsController
{
    private readonly ILogController _controller;
    public LogsController(ILogController controller)
    {
        _controller = controller;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return _controller.Get();
    }

    [HttpPost]
    public IActionResult Post([FromBody] Log log)
    {
        log.Date = DateTime.Now;
        return _controller.Post(log);
    }
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id)
    {
        return _controller.Delete(id);

    }

    [HttpPatch]
    [Route("{id}")]
    public IActionResult Patch(int id, Log log)
    {
        return _controller.Patch(id, log);
    }
}