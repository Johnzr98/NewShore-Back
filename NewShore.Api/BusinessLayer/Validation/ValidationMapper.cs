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
            if (string.IsNullOrEmpty(route.departureStation))
            {
                return null;
            }

            if (string.IsNullOrEmpty(route.arrivalStation))
            {
                return null;
            }

            route.arrivalStation = route.arrivalStation.ToUpper();
            route.departureStation = route.departureStation.ToUpper();

            return route;
        }
    }
}
