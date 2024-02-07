using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EncryptionWithEF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //Develop Commit1
    public class WeatherForecastController : ControllerBase
    {
        private readonly AppDbContext applicationDbContext;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext applicationDbContext)
        {
            _logger = logger;
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            applicationDbContext.Add(new User
            {
                Email = "info@bugeto.net",
                Name = "Ehsan",
                LastName = "Babaei",
                Password = "123",
                PhoneNumber = "09120000000"
            });
            applicationDbContext.SaveChanges();
            var firstUser = applicationDbContext.User.First();
            Console.WriteLine($"Name:{firstUser.Name}  {firstUser.LastName}");
            Console.WriteLine($"Email:{firstUser.Email}  ");
            Console.WriteLine($"PhoneNumber :{firstUser.PhoneNumber}  ");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
    //Master
}
