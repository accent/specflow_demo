using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace specflow_demo.tests
{
	[Binding]
	public sealed class AssertionStepDefinitions
	{
		// For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

		private readonly ScenarioContext context;

		public AssertionStepDefinitions(ScenarioContext injectedContext)
		{
			this.context = injectedContext;
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

		[Then(@"The result should be (.*)")]
		public void ThenTheResultShouldBe(int httpStatusCode)
		{
			var response = this.context["response"] as HttpResponseMessage;
			Assert.AreEqual(httpStatusCode, (int)response.StatusCode);
		}
	}
}
