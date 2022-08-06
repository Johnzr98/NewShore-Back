using Entities;
using System.Collections.Generic;

namespace BusinessLayer.Common
{
    public interface IBaseFlights
    {
        IList<Route> GetFlightsByCategory(int category);
        IList<Flight> GetFlightsByParams(int category, Route data);
    }
}
