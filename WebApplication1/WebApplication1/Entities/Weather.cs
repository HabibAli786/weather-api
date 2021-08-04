using System;

namespace WebApplication1.Entities
{
    public record Weather
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