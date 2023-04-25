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

        public async Task<List<HttpResponseMessage>> SendGetRequestAsync()
        {
            List<HttpResponseMessage> cityResponse = new List<HttpResponseMessage>();

            foreach(var city in this.cities()) 
            {
                cityResponse.Add(await _httpClient.GetAsync("http://api.weatherapi.com/v1/current.json?key=7b62b2c73b3c49f1a5e104336231404&q=" + city + "&aqi=no"));
            }
            return cityResponse;
        }

        public async Task<List<string>> ReadResponseContentAsync()
        {
            var responses = await this.SendGetRequestAsync();

            List<string> cityStrings = new List<string>(); 


            foreach(var response in responses) 
            {
                string content = "";
                if (response.IsSuccessStatusCode) 
                {
                    content = await response.Content.ReadAsStringAsync();
                }
                cityStrings.Add(content);
            }
            return cityStrings;
        }

        private List<string> cities()
        {
            List<string> cities = new List<string>()
            {
                "Durban",
                "Johannesburg",
                "Pretoria"
            };

            return cities;

        }
    }
}
