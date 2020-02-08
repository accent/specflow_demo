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
			context = injectedContext;
		}

		[Given(@"Weather forecast (.*)")]
		public void GivenWeatherForecastUrl(string url)
		{
			ScenarioContext.Current.Pending();
		}
		
		[When(@"I request the forecast")]
		public void WhenIRequestTheForecast()
		{
			ScenarioContext.Current.Pending();
		}

		[Then(@"the result should be the weather forecast for next (.*) days")]
		public void ThenTheResultShouldBeTheWeatherForecastForNextFiveDays(int days)
		{
			ScenarioContext.Current.Pending();
		}

	}
}
