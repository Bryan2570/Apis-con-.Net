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

    private static List<WeatherForecast> ListWeatherForecast =  new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        
        if(ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast =  Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    // [Route("get/weatherForecast")]
    // [Route("[action]")]  // toma el nombre del end point en la ruta
    public IEnumerable<WeatherForecast> Get1()
    {
        //Estos msj van a ser leidos por diferentes servicios cuando publiquemos la api en la nube
        //_logger.LogInformation("Retornando la lista");
        return ListWeatherForecast;
    }

    [HttpPost]

    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);

        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        ListWeatherForecast.RemoveAt(index);
        return Ok();
    }
}
