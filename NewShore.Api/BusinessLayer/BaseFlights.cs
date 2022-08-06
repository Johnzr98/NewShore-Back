

namespace BusinessLayer
{
    using BusinessLayer.Common;
    using BusinessLayer.Validation;
    using DataLayer;
    using DataLayer.Common;
    using Entities;
    using System.Collections.Generic;
    using System.Linq;

    public class BaseFlights : BaseRepository, IBaseFlights 
    {
        public IList<Route> GetFlightsByCategory(int category)
        {
            return GetFlights<Route>(category);
        } 
        
        public IList<Flight> GetFlightsByParams(int category, Route flight)
        {
            Route dataMapper = ValidationMapper.DataMapper(flight);

            if (dataMapper == null) return new List<Flight>();

            return GetFlights<Flight>(category).Where(f => f.arrivalStation == dataMapper.arrivalStation && f.departureStation == dataMapper.departureStation).ToList();
        }
    }
}
