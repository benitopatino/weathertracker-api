using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace weatherapp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet("temperature/{city}")]
        public IActionResult GetTemperature(string city)
        {
            return Ok("City " + city);
        }

    }
}
