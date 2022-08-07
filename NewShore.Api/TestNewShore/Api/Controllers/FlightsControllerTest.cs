using BusinessLayer.Common;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewShore.Api.Controllers;
using System.Collections.Generic;
using System.Net;

namespace TestNewShore.Api.Controllers
{
    [TestClass]
    public class FlightsControllerTest
    {
        private readonly Mock<IBaseFlights> mockServicesBaseFlights;
        private readonly ILogger<FlightsController> mockIlogger;

        public FlightsControllerTest()
        {
            this.mockServicesBaseFlights = new Mock<IBaseFlights>();
        }

        [TestMethod]
        public void MethodReturnOkToConsultFlightsRoutes()
        {
            List<Route> routes = new List<Route>
            {
                new Route
                {
                    arrivalStation = "MDE",
                    departureStation = "BOG"
                }
            };

            this.mockServicesBaseFlights.Setup(x => x.GetFlightsByCategory(0)).Returns(routes);

            var controller = new FlightsController(this.mockServicesBaseFlights.Object, this.mockIlogger);
            var response = controller.GetFlightsRoutes(0) as ObjectResult;
            
            Assert.AreEqual(200, response?.StatusCode);
        }

        [TestMethod]
        public void MethodReturnNullToConsultFlightsRoutes()
        {
            List<Route> routes = new List<Route>();

            this.mockServicesBaseFlights.Setup(x => x.GetFlightsByCategory(0)).Returns(routes);

            var controller = new FlightsController(this.mockServicesBaseFlights.Object, this.mockIlogger);
            var response = controller.GetFlightsRoutes(0) as ObjectResult;

            Assert.IsNull(response);
        }
    }
}
