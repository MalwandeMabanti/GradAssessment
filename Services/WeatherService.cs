

namespace TestingTesting.Services
{
    using System.Net.Http;
    using TestingTesting.Interface;

    public class WeatherService : IWeatherService
    {

        private readonly HttpClient _httpClient;


        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> SendGetRequestAsync()
        {
            return await _httpClient.GetAsync("http://api.weatherapi.com/v1/current.json?key=7b62b2c73b3c49f1a5e104336231404&q=Johannesburg&aqi=no");
        }

        public async Task<string> ReadResponseContentAsync()
        {
            var response = await this.SendGetRequestAsync();

            string content = "";

            //SuccessCode = response.IsSuccessStatusCode;

            if(response.IsSuccessStatusCode) 
            {
                content = await response.Content.ReadAsStringAsync();
            }
            return content;
        }
    }
}
