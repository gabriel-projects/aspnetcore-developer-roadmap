using aspnetcore_developer_roadmap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace aspnetcore_developer_roadmap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        private readonly AutorOptions AutorOptions;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration, IOptions<AutorOptions> options)
        {
            _logger = logger;
            Configuration = configuration;
            AutorOptions = options.Value;
        }

        [HttpGet("AutorsFromConfiguration")]
        public ActionResult<AutorOptions> GetAutors()
        {
            var autorOpionts = new AutorOptions();
            Configuration.GetSection(AutorOptions.Name).Bind(autorOpionts);

            return autorOpionts;
        }

        [HttpGet("AutorsFromOptions")]
        public ActionResult<AutorOptions> GetAutorsFromOptions()
        {
            //uso combinado com services.Configure<AutorOptions>(Configuration.GetSection(AutorOptions.Name)); na startup
            return AutorOptions;
        }
    }
}