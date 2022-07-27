namespace Api.Providers.AnotherSmsProvider
{
	public class AnotherSmsProvider : ISmsProvider
	{
		private readonly AnotherSmsProviderConfiguration configuration;

		public AnotherSmsProvider(AnotherSmsProviderConfiguration configuration)
		{
			this.configuration = configuration;
		}
		public bool Send(string phone, string content)
		{
            // Sms provider action
			return true;
		}
	}
}