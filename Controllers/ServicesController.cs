using cb_agent.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using cb_agent.Services.Interfaces.Controller;
namespace cb_agent.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ServicesController : ControllerBase
{   
    private readonly ILogger<ServicesController> _logger;
    private readonly IServiceController _controller;

    public ServicesController(ILogger<ServicesController> logger, IServiceController controller)
    {
        _logger = logger;
        _controller = controller;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return _controller.Get();
    }

    [HttpPost]
    public IActionResult Post([FromBody] Service service)
    {
        return _controller.Post(service);
    }
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(int id)
    {
        return _controller.Delete(id);
        
    }

    [HttpPatch]
    [Route("{id}")]
    public IActionResult Patch(int id, Service service)
    {
        return _controller.Patch(id, service);
    }
    [HttpPost]
    [Route("/api/v1/services/executar/{id}")]
    public IActionResult Execute(int id)
    {
        return _controller.Execute(id);
    }
}
