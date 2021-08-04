using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1
{
    public static class Extensions
    {
        public static WeatherDto AsDto(this Weather item)
        {
            return new WeatherDto
            {
                id = item.id,
                cityName = item.cityName,
                country = item.country,
                windSpeed = item.windSpeed,
                tempertureC = item.tempertureC,
                tempertureF = item.tempertureF,
                tempertureFeels = item.tempertureFeels
            };
        }
    }
}
