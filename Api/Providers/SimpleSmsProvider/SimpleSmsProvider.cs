namespace Api.Providers.SimpleSmsProvider
{
	public class SimpleSmsProvider : ISmsProvider
	{
		private readonly SimpleSmsProviderConfiguration configuration;		
		public SimpleSmsProvider(SimpleSmsProviderConfiguration configuration)
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