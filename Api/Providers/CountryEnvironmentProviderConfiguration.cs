namespace Api.Providers
{
	public record CountryEnvironmentProviderConfiguration(string Country, string Enviroment, string Provider, MessageType MessageType, object Configuration);
}