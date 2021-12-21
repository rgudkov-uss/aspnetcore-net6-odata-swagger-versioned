using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using WebApiTest6.Models.V2;

namespace WebApiTest6.Controllers.V2;

[Produces("application/json")]
[ODataRouteComponent("api/v2")]
public class WeatherForecastController : ODataController
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Get weather forecast for N days
    /// </summary>
    /// <param name="days">Days to get forecast for</param>
    /// <returns></returns>
    [HttpGet]
    [EnableQuery]
    public ActionResult<IQueryable<WeatherForecast>> Get(int days = 5)
    {
        var items = Enumerable.Range(1, days)
            .Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Source = new Source { Name1 = "Test name 1" }
            })
            .AsQueryable();
        return Ok(items);
    }
}
