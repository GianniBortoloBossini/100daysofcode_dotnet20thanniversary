using Microsoft.AspNetCore.Mvc;

namespace mvc_api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet()]
    public IEnumerable<WeatherForecast> Get([FromServices] WeatherForecastService service)
        => service.Get();
}
