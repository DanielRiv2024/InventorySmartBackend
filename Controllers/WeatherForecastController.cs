using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace InventorySmart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IConfiguration configuration, ILogger<WeatherForecastController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var name = _configuration["OracleInventoryUser"];
            _logger.LogInformation("Environment variable value: {Name}", name);

            if (!string.IsNullOrEmpty(name))
            {
                // Devuelve solo el nombre como resultado
                return Ok(new { OracleInventoryUser = name });
            }
            else
            {
                // En caso de que la variable de entorno no tenga un valor
                return BadRequest("La variable de entorno OracleInventoryUser no está configurada.");
            }
        }
    }
}
