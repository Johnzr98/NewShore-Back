using Entities;
using System.Collections.Generic;

namespace BusinessLayer.Common
{
    public interface IBaseFlights
    {
        IList<Flight> GetFlightsByCategory(int category);
    }
}
