using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace specflow_demo
{
	[ApiController]
	[Route("[controller]")]
	public class EmptyController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			return Ok();
		}
	}
}
