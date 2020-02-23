using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using specflow_demo.data;

namespace specflow_demo.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private LocalDbContext dbContext;
		private readonly ILogger<WeatherForecastController> logger;

		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		public WeatherForecastController(ILogger<WeatherForecastController> logger, LocalDbContext dbContext)
		{
			this.logger = logger;
			this.dbContext = dbContext;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}

		[HttpGet("get-db")]
		public IEnumerable<Weather> GetFromDb()
		{
			return this.dbContext.Weathers.Take(5);
		}
	}
}
