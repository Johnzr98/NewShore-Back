using Entities;
using System.Collections.Generic;

namespace BusinessLayer.Common
{
    public interface IBaseFlights
    {
        IList<Route> GetFlightsByCategory(int category);
        Journey GetFlightsByParams(int category, Route data);
    }
}
