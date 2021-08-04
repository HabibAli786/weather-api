using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Repository;
using WebApplication1.Entities;
using System.Net.Http;
using System.Net;
using WebApplication1.Dtos;
using WebApplication1;


// GET City weather data
// POST Create another city weather data
// PUT Edit city weather data
// DELETE a city and the weather data from list

namespace weatherapi.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherController : ControllerBase
    {
        private readonly IweatherRepository repository;

        public WeatherController(IweatherRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<WeatherDto> getWeather()
        {
            var weatherItems = repository.GetWeather().Select(item => item.AsDto());
            return weatherItems;
        }

        [HttpGet("{city}")]
        public ActionResult<WeatherDto> getWeatherOfCity(string city)
        {
            var result = repository.GetCityWeather(city).AsDto();

            if(result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public ActionResult<Weather> addNewCity(Weather cityObject)
        {
            repository.AddNewCity(cityObject);

            return CreatedAtAction(nameof(getWeather), cityObject.cityName);
        }

        [HttpPut]
        public ActionResult<Weather> editCityWeather(Weather cityObject)
        {
            var itemToEdit = repository.GetCityWeather(cityObject.cityName);


            if(itemToEdit == null)
            {
                return NotFound($"Could not find city with name: {cityObject.cityName}");
            }

            repository.editCityWeather(cityObject);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult<Weather> removeCity(string cityName)
        {
            var item = repository.GetCityWeather(cityName);

            if(item == null)
            {
                return NotFound($"Could not find city with name: {cityName}");
            }

            repository.deleteCity(cityName);

            return NoContent();
        }
    }
}