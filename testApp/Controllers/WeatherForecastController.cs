using Microsoft.AspNetCore.Mvc;

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

    // Получение всех записей
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _context.WeatherForecasts.ToList();
    }

    // Получение записи по ID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var forecast = _context.WeatherForecasts.FirstOrDefault(f => f.Id == id);
        if (forecast == null)
        {
            return NotFound();
        }
        return Ok(forecast);
    }

    // Создание новой записи
    [HttpPost]
    public IActionResult Post(WeatherForecast forecast)
    {
        _context.WeatherForecasts.Add(forecast);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = forecast.Id }, forecast);
    }

    // Обновление записи
    [HttpPut("{id}")]
    public IActionResult Put(int id, WeatherForecast updatedForecast)
    {
        var forecast = _context.WeatherForecasts.FirstOrDefault(f => f.Id == id);
        if (forecast == null)
        {
            return NotFound();
        }

        forecast.Date = updatedForecast.Date;
        forecast.TemperatureC = updatedForecast.TemperatureC;
        forecast.Summary = updatedForecast.Summary;

        // Добавление новых полей, если они есть
        forecast.Location = updatedForecast.Location;
        forecast.Humidity = updatedForecast.Humidity;
        forecast.WindSpeed = updatedForecast.WindSpeed;

        _context.SaveChanges();
        return NoContent();
    }

    // Удаление записи
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var forecast = _context.WeatherForecasts.FirstOrDefault(f => f.Id == id);
        if (forecast == null)
        {
            return NotFound();
        }

        _context.WeatherForecasts.Remove(forecast);
        _context.SaveChanges();
        return NoContent();
    }
}
