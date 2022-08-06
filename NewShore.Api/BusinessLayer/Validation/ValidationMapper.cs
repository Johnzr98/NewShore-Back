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
    }
}
