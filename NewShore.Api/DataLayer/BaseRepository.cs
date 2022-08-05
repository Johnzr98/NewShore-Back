using DataLayer.Common;
using Entities;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace DataLayer
{
    public class BaseRepository : IBaseRepository
    {
        private static string flightsUrl;

        public BaseRepository(string flightUrl)
        {
            flightsUrl = flightUrl;
        }
        public BaseRepository()
        {
        }

        public IList<Flight> GetFlights(int category)
        {
            List<Flight> flights = new List<Flight>();

            var client = new RestClient($"{flightsUrl}/flights/{category}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                flights = JsonConvert.DeserializeObject<List<Flight>>(response.Content);
            }

            return flights;
        }
    }
}
