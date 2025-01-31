using cb_agent.Repository.Interfaces;
using cb_agent.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using cb_agent.Services.Interfaces.Controller;

namespace cb_agent.Services.Classes.Controllers;


public class LogControllerService : ControllerBase, ILogController
{
    private readonly ILog _repository;
    public LogControllerService(ILog repository)
    {
        _repository = repository;
    }
    public IActionResult Delete(int id)
    {
       _repository.Delete(id);
       return StatusCode(204, new {});
    }

    public IActionResult Get()
    {
        return Ok(new { Status = "Ok", data = _repository.ReadAll()});
    }

    public IActionResult Patch(int id, Log log)
    {
        if(log.Log_id != id)
        {
            return BadRequest(new {Status="Ok",msg="The passed ID for log do not match with the LogId in body"});
        }
        log.Log_id = id;
        _repository.Update(log);
        return StatusCode(204,new {});
    }

    public IActionResult Post(Log log)
    {
        _repository.Create(log);
        return Ok();
    }
}