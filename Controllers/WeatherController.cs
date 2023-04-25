using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TestingTesting.Interface;
using TestingTesting.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;

namespace DevExtreme.NETCore.Demos.Controllers {


    public class WeatherController : Controller {

       
       
        //private readonly IMemoryCache memoryCache;
        private readonly IWeatherService weatherService;
        private readonly IValidator<WeatherModel> validator;

        public WeatherController(IWeatherService weatherService, IValidator<WeatherModel> validator)
        {
            this.weatherService = weatherService;
            this.validator = validator;

        }

        public ActionResult Overview() {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<WeatherModel?>> Get(DataSourceLoadOptions loadOptions)
        {
            List<string> cityDetails = await this.weatherService.ReadResponseContentAsync();

            List<WeatherModel> forecasts = new List<WeatherModel>();

            foreach (var city in cityDetails) 
            {
                var model = JsonConvert.DeserializeObject<WeatherModel>(city);
                if (model == null) 
                {
                    this.ModelState.AddModelError("all", "1 one or more properties malformed");
                    return this.BadRequest(this.ModelState);

                }
                var results = validator.Validate(model, _ => _.IncludeRuleSets("Get"));

                if (!results.IsValid) 
                {
                    results.AddToModelState(this.ModelState);

                    return this.BadRequest(this.ModelState);
                }


                forecasts.Add(model);
            }
            
            return Ok(forecasts);


            //if (true)
            //{
            //    //var model = JsonConvert.DeserializeObject<WeatherModel>(s);

            //    var forecast = new List<WeatherModel>
            //    {
            //        model,
            //    };

            //    //forecast = this.memoryCache.Get<List<WeatherModel>>("weather");

            //    //if (forecast is null)
            //    //{
            //    //    Location location = new Location();
            //    //    Current current = new Current();

            //    //    location.country = "South Africa";
            //    //    location.region = "KwaZulu Natal";
            //    //    location.name = "Durban";
            //    //    location.lon = (decimal)-29.85;
            //    //    location.lat = (decimal)-29.85;
            //    //    current.temp_c = 20;




            //    //    forecast.Add(model);

            //    //    this.memoryCache.Set("weather", forecast, TimeSpan.FromMinutes(30));

            //    //}

            //    return Ok(forecast);
            //}
            //else

            //{
            //    // Handle error response
            //    return View("Error");
            //}
        }
    }
}