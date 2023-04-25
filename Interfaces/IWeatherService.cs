namespace TestingTesting.Interface
{
    public interface IWeatherService
    {

        Task<List<HttpResponseMessage>> SendGetRequestAsync();

        Task<List<string>> ReadResponseContentAsync();
    }
}
