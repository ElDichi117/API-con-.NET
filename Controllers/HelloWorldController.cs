using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController:  ControllerBase
{
    //Dependencia
    IHelloWorldService helloWorldService;

    //Implementando loggin
    private readonly ILogger<HelloWorldController> _logger;

    //Aquí se recibe la dependencia
    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger)
    {
        _logger = logger;
        helloWorldService = helloWorld;
    }

    public IActionResult Get()
    {
        _logger.LogDebug("Logging from Get(). Hi!");
        return Ok(helloWorldService.GetHelloWorld());
    }
}