

namespace BusinessLayer
{
    using BusinessLayer.Common;
    using DataLayer;
    using DataLayer.Common;
    using Entities;
    using System.Collections.Generic;

    public class BaseFlights : BaseRepository, IBaseFlights
    {
        public IList<Flight> GetFlightsByCategory(int category)
        {
            return GetFlights(category);
        }
    }
}
