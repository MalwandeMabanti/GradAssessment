using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;

namespace DevExtreme.NETCore.Demos.Controllers {


    public class WeatherController : Controller {

        private readonly HttpClient _httpClient;

        public WeatherController(HttpClient httpClient)
        {

                _httpClient = httpClient;
        }

        public ActionResult Overview() {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<WeatherModel?>> Get(DataSourceLoadOptions loadOptions)
        {
      
            var response = await _httpClient.GetAsync("http://api.weatherapi.com/v1/current.json?key=7b62b2c73b3c49f1a5e104336231404&q=Durban&aqi=no");

            if (response.IsSuccessStatusCode)
            {
                var s = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<WeatherModel>(s);

                var forecast = new List<WeatherModel>
                {
                    model,
                };

                return Ok(forecast);
            }
            else
            {
                // Handle error response
                return View("Error");
            }
        }
    }
}