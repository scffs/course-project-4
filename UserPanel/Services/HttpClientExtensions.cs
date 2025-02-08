namespace UserPanel.Services;
public static class HttpClientExtensions
{
  public static void AddApiHttpClient<TClient>(this IServiceCollection services, string baseAddress)
    where TClient : class
  {
    services.AddHttpClient<TClient>(client => { client.BaseAddress = new Uri(baseAddress); });
  }
}