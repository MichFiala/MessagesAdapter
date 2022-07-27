using Api.Providers.AnotherSmsProvider;
using Api.Providers.SimpleSmsProvider;

namespace Api.Providers
{
	public static class ProviderFactory
    {
        public static ISmsProvider? GetSmsProvider(string country, string environment, List<CountryEnvironmentProviderConfiguration> orchestration)
        {
			// Application can support multiple countries with multiple environments on multiple providers
			var configurationOrchestration = orchestration
			 .Single(
				x => x.Country == country &&
				x.Enviroment == environment &&
				x.MessageType == MessageType.Sms);
            // Needs just more clever mechanism to choose provider based on configuration
			switch(configurationOrchestration.Provider)
            {
                case "SimpleSmsProvider": 
                    return new SimpleSmsProvider.SimpleSmsProvider((SimpleSmsProviderConfiguration)configurationOrchestration.Configuration);
                case "AnotherSmsProvider":
					return new AnotherSmsProvider.AnotherSmsProvider((AnotherSmsProviderConfiguration)configurationOrchestration.Configuration);
                default:
					throw new NotImplementedException("Provider not found");
			}
        }
    }
}