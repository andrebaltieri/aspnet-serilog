using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AspNetSerilogTests.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult Get()
    {
        // Log.Error("Deu algum erro");
        throw new Exception("Eu causei esta exceção!");
        return Ok(new {message = "Tudo bem!"});
    }
}