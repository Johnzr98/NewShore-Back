using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public static class TypeOfFlight
    {
        public static IList<Flight> NonStopFlight(IList<Flight> flights, Route route)
        {
            return flights.Where(f => f.departureStation == route.departureStation && f.arrivalStation == route.arrivalStation).ToList();
        }

        public static IList<Flight> TwoFlights(IList<Flight> flights, Route route)
        {
            List<Flight> flightsComplete = new List<Flight>();

            List<Flight> flightsStr = flights.Where(f => f.departureStation == route.departureStation).ToList();
            List<Flight> flightsEnd = flights.Where(f => f.arrivalStation == route.arrivalStation).ToList();

            foreach (var flightE in flightsEnd)
            {
                Flight flightsOne = flightsStr.Where(f => f.arrivalStation == flightE.departureStation).FirstOrDefault();

                if (flightsOne != null)
                {
                    Flight flightsTwo = flightsEnd.Where(f => f.departureStation == flightsOne.arrivalStation).FirstOrDefault();

                    if (flightsTwo != null)
                    {
                        flightsComplete.Add(flightsOne);
                        flightsComplete.Add(flightsTwo);

                        return flightsComplete;
                    }
                }
            }

            return new List<Flight>();
        }
    }
}
