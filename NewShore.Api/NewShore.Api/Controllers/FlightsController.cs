using BusinessLayer.Common;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace NewShore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IBaseFlights baseFlights;
        private readonly ILogger<FlightsController> _logger;

        public FlightsController(IBaseFlights baseFlights, ILogger<FlightsController> logger)
        {
            _logger = logger;
            this.baseFlights = baseFlights;
        }

        [HttpPost("GetAllFlights/{category}")]
        public ActionResult GetAllFlights(int category, Route data)
        {
            IList<Flight> flights = this.baseFlights.GetFlightsByParams(category, data);

            if (flights.Count > 0)
            {
                return Ok(flights);
            }

            return NotFound();
        }

        [HttpGet("GetFlightsRoutes/{category}")]
        public ActionResult GetFlightsRoutes(int category)
        {
            IList<Route> flights = this.baseFlights.GetFlightsByCategory(category);

            if (flights.Count > 0)
            {
                return Ok(flights);
            }

            return NotFound();
        }
    }
}
