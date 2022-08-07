namespace BusinessLayer
{
    using BusinessLayer.Common;
    using BusinessLayer.Validation;
    using DataLayer;
    using Entities;
    using System.Collections.Generic;

    public class BaseFlights : BaseRepository, IBaseFlights
    {
        public IList<Route> GetFlightsByCategory(int category)
        {
            return GetFlights<Route>(category);
        }

        public Journey GetFlightsByParams(int category, Route route)
        {
            Route routeMapper = ValidationMapper.DataMapper(route);

            if (routeMapper == null) return null;

            IList<Flight> flightsResponse = GetFlights<Flight>(category);

            var nonStopFlight = TypeOfFlight.NonStopFlight(flightsResponse, routeMapper);

            if (nonStopFlight.Count >= 1) return ValidationMapper.JourneyMapper(route, nonStopFlight);

            var twoFlights = TypeOfFlight.TwoFlights(flightsResponse, routeMapper);

            if (twoFlights.Count >= 1) return ValidationMapper.JourneyMapper(route, twoFlights);

            return null;
        }
    }
}
