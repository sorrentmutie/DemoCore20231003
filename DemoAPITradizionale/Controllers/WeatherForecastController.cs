using Microsoft.AspNetCore.Mvc;

namespace DemoAPITradizionale.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEnumerable<IService> services;
       // private readonly IOptions<MyJwtOptions> options;
        private MyJwtOptions? myJwtOptions;
        private readonly Features? personalize;
        private readonly Features? recommender;

        // private readonly IConfiguration configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IEnumerable<IService> services,
            //IConfiguration configuration,
            //IOptions<MyJwtOptions> options,
            IOptionsSnapshot<MyJwtOptions> options,
            IOptionsSnapshot<Features> features
            )
        {
            _logger = logger;
            this.services = services;
            //this.options = options;
            myJwtOptions = options.Value;
            //this.configuration = configuration;

            personalize = features.Get(Features.Personalize);
            recommender = features.Get(Features.Recommender);

        }

        [HttpGet("config")]
        public IActionResult Config()
        {
            // var result = myJwtOptions is null ? "null" : myJwtOptions.SecretKey;
            var result = recommender?.ApiKey;

            return Ok(result);
           // return Ok(configuration["Jwt:Issuer"]);
        }   


        [HttpGet("example")]
        public IActionResult Example()
        {
            return Ok(services.Select(s => s.GetType().Name));
           // return Ok(service.GetType().Name);
        }



        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}