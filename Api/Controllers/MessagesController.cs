using Api.Providers;
using Api.Providers.AnotherSmsProvider;
using Api.Providers.SimpleSmsProvider;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
	public class MessagesController : ControllerBase
	{
		private readonly List<CountryEnvironmentProviderConfiguration> orchestration;
		public MessagesController()
		{
			// Loaded configurations from config file
			var anotherConfig = new AnotherSmsProviderConfiguration("www.google.com", "superSecret");
			var simpleConfig = new SimpleSmsProviderConfiguration("www.google.com", "superSimpleSecret", "token");

			// Orchestration from config file
			this.orchestration = new List<CountryEnvironmentProviderConfiguration>()
		    {
			    new CountryEnvironmentProviderConfiguration("CZ", "Dev", "SimpleSmsProvider", MessageType.Sms, simpleConfig),
			    new CountryEnvironmentProviderConfiguration("CZ", "Uat", "AnotherSmsProvider",  MessageType.Sms, anotherConfig),
		    };

		}
        [HttpGet("SendSms/{country}/{environment}/{phone}/{content}")]
		public IActionResult SendSms(string country, string environment, string phone, string content)
		{
			var provider = ProviderFactory.GetSmsProvider(country, environment, orchestration);

			provider.Send(phone, content);

			return Ok(provider);
		}
	}
}