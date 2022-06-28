using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private static readonly string[] Students = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    /*
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Students[Random.Shared.Next(Students.Length)]
            })
            .ToArray();
    }*/
}