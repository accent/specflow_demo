using System;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace specflow_demo.tests
{
	[Binding]
	public class HttpRequestStepDefinitions
	{
		private readonly ScenarioContext context;

		public HttpRequestStepDefinitions(ScenarioContext injectedContext)
		{
			this.context = injectedContext;
		}

		[Given(@"Server URL (.*)")]
		public void GivenServiceUrl(string baseUrl)
		{
			this.context.Add("baseUrl", baseUrl);
		}

		[When(@"I request the GET data from (.*)")]
		public async Task WhenISendRequestToServer(string requestUrl)
		{
			var httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(this.context["baseUrl"].ToString());
			this.context.Add("response", await httpClient.GetAsync(requestUrl));
		}
	}
}
