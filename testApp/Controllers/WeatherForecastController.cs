using Microsoft.AspNetCore.Mvc;
using testApp.Data;

namespace testApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly AppDbContext _context;

    public WeatherForecastController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _context.WeatherForecasts.ToList();
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast forecast)
    {
        _context.WeatherForecasts.Add(forecast);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = forecast.Date }, forecast);
    }
}