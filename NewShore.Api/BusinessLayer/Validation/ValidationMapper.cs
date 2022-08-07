using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public static class ValidationMapper
    {
        public static Route DataMapper(Route route)
        {
            if (string.IsNullOrEmpty(route.departureStation) || route.departureStation.Length > 3)
            {
                return null;
            }

            if (string.IsNullOrEmpty(route.arrivalStation) || route.arrivalStation.Length > 3)
            {
                return null;
            }

            route.arrivalStation = route.arrivalStation.ToUpper();
            route.departureStation = route.departureStation.ToUpper();

            return route;
        }

        public static Journey JourneyMapper(Route route, IList<Flight> flights)
        {
            Journey journey = new Journey();
            journey.flights = new List<JourneyFlight>();
            decimal price = 0;

            journey.origin = route.departureStation;
            journey.destination = route.arrivalStation;

            foreach (var flight in flights)
            {
                price += flight.price;

                var journeyFlight = new JourneyFlight
                {
                    origin = flight.departureStation,
                    destination = flight.arrivalStation,
                    price = flight.price,
                    transport = new JourneyTransport
                    {
                        flightCarrier = flight.flightCarrier,
                        flightNumber = flight.flightNumber,
                    }
                };

                journey.flights.Add(journeyFlight);
            }

            journey.price = price;

            return journey;
        }
    }
}
