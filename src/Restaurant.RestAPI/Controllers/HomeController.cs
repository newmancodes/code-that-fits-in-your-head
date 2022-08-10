using Microsoft.AspNetCore.Mvc;

namespace Restaurant.RestAPI.Controllers;

[Route("")]
public class HomeController : ControllerBase
{
    public IActionResult Get()
    {
        return Ok(new { message = "Hello, World!" });
    }
}