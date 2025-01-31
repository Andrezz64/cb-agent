using cb_agent.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using cb_agent.Services.Interfaces.Controller;
namespace cb_agent.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ProcessController : ControllerBase
{   
    private readonly ILogger<ProcessController> _logger;
    private readonly IProcessController _controller;

    public ProcessController(ILogger<ProcessController> logger, IProcessController controller)
    {
        _logger = logger;
        _controller = controller;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return _controller.GetRunningProcessFromMachine();
    }

}
