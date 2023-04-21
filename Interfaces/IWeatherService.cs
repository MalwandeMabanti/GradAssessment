namespace TestingTesting.Interface
{
    public interface IWeatherService
    {

        Task<HttpResponseMessage> SendGetRequestAsync();

        Task<string> ReadResponseContentAsync();
    }
}
