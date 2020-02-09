using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace specflow_demo.tests
{
	[Binding]
	public sealed class StepDefinition
	{
		// For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

		private readonly ScenarioContext context;

		public StepDefinition(ScenarioContext injectedContext)
		{
			this.context = injectedContext;
		}

		[Given(@"Weather forecast (.*)")]
		public void GivenWeatherForecastUrl(string baseUrl)
		{
			this.context.Add("baseUrl", baseUrl);
		}

		[When(@"I request the forecast (.*)")]
		public async Task WhenIRequestTheForecast(string requestUrl)
		{
			var httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(this.context["baseUrl"].ToString());
			this.context.Add("response", await httpClient.GetAsync(requestUrl));
		}

		[Then(@"the result should be the weather forecast for next (.*) days")]
		public async Task ThenTheResultShouldBeTheWeatherForecastForNextFiveDays(int days)
		{
			var response = this.context["response"] as HttpResponseMessage;
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
			var responseContent = await response.Content.ReadAsStringAsync();
			var receivedDays = JsonConvert.DeserializeObject<List<WeatherForecastModel>>(responseContent).Count;
			Assert.AreEqual(days, receivedDays);
		}

		private class WeatherForecastModel
		{
			public DateTime Date { get; set; }

			public int TemperatureC { get; set; }

			public int TemperatureF { get; set; }

			public string Summary { get; set; }
		}
	}
}
