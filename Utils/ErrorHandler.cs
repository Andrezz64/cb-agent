using Microsoft.AspNetCore.Mvc;

namespace cb_agent.Utils;
public class ErrorHandler : ControllerBase
{
    public IActionResult InvokeError(Exception ex)
    {
        string runningMode = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")??"Production";
        if(runningMode == "Development")
        {
             return StatusCode(500,new {status="Error",
             data =new {
                Error = ex.Message,
                Inner = ex.InnerException,
                Stack = ex.StackTrace
             }});
        }
        return StatusCode(500,new {status="Error",
             data =new {
                Error = ex.Message,
             }});
    }
}