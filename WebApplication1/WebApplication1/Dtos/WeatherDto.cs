using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Dtos
{
    public record WeatherDto
    {
        public Guid id { get; init; }

        public string cityName { get; init; }

        public string country { get; init; }

        public decimal windSpeed { get; init; }

        public decimal tempertureC { get; init; }

        public decimal tempertureF { get; init; }

        public decimal tempertureFeels { get; init; }

    }
}
