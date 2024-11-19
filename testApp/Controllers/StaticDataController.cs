using Microsoft.AspNetCore.Mvc;

namespace testApp.Controllers;

[ApiController]
[Route("[controller]")]
public class StaticDataController : ControllerBase
{
    // Статические данные
    private static readonly List<object> StaticItems = new List<object>
    {
        new { Id = 1, Name = "Static Item 1", Description = "This is the first static item." },
        new { Id = 2, Name = "Static Item 2", Description = "This is the second static item." },
        new { Id = 3, Name = "Static Item 3", Description = "This is the third static item." }
    };

    // Получить все статические элементы
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(StaticItems);
    }
}