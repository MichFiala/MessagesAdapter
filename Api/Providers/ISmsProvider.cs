namespace Api.Providers
{
	public interface ISmsProvider
     {
		bool Send(string phone, string content);
	}
}