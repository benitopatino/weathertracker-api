using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using weatherapp_api.Models;

namespace weatherapp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet("temperature/{city}")]
        public IActionResult GetTemperature(string city)
        {
            var payload = GeneratePayload(city);
            
            if(payload.IsRaining)
            {
                // call azure functino and send alert 
            }

            return Ok(payload);
        }


        private CityInfo GeneratePayload(string city)
        {
            var random = new Random();
            decimal temp = random.Next(30, 120);

            bool isRaining = random.Next(0, 2) == 1;

            return new CityInfo(city, temp, isRaining);
        }

    }
}
