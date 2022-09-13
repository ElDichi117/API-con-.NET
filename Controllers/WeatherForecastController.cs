using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();


    //Constructor del controlador
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if(ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }
    //aQUÍ LO QUE SE PUEDE VER ES COMO HACER DISTINTAS RUTAS
    [HttpGet(Name = "GetWeatherForecast")]
    [Route("GET/weatherforecast")]
    [Route("GET/weatherforecast2")]
    [Route("[action]")]//permite usar el nombre del método que estamos usando 
    public IEnumerable<WeatherForecast> Get()
    {
        return ListWeatherForecast;
    }

    [HttpPost]

    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);

        return Ok();
    }
    //Se colocoa index para que el método delete sepa que dentro de la url viene un idex y este ayudara para eliminar un eleme nto
    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        ListWeatherForecast.RemoveAt(index);

        return Ok();
    }
}
