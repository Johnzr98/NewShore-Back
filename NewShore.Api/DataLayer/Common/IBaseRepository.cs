using Entities;
using System.Collections.Generic;

namespace DataLayer.Common
{
    public interface IBaseRepository
    {
        IList<T> GetFlights<T>(int category);
    }
}
