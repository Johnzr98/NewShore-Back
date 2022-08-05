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

        [HttpGet("GetFlights/{category}")]
        public IList<Flight> Get(int category)
        {
            return this.baseFlights.GetFlightsByCategory(category);
        }
    }
}
