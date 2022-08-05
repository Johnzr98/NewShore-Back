using Entities;
using System.Collections.Generic;

namespace DataLayer.Common
{
    public interface IBaseRepository
    {
        IList<Flight> GetFlights(int category);
    }
}
